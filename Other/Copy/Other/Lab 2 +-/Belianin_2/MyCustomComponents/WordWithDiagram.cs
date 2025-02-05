using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Drawing.Wordprocessing;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml;
using MyCustomComponents.Helpers;
using MyCustomComponents.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Wordprocessing;

namespace MyCustomComponents
{
	public partial class WordWithDiagram : Component
	{
		// Хранит документ Word
		private Document _document = null;

		// Хранит тело документа Word
		private Body _body = null;

		// Хранит диаграмму (график), которая будет добавлена в документ
		private DocumentFormat.OpenXml.Drawing.Charts.Chart _chart;

		// Свойство для создания или получения документа
		private Document Document
		{
			get
			{
				if (_document == null)
				{
					_document = new Document();
				}

				return _document;
			}
		}

		// Свойство для создания или получения тела документа
		private Body Body
		{
			get
			{
				if (_body == null)
				{
					_body = Document.AppendChild(new Body());
				}

				return _body;
			}
		}

		// Конструктор по умолчанию
		public WordWithDiagram()
		{
			InitializeComponent();
		}

		// Конструктор с контейнером для компонентов
		public WordWithDiagram(IContainer container)
		{
			container.Add(this);
			InitializeComponent();
		}

		public void CreateDoc(WordWithDiagramConfig config)
		{
			config.CheckFields();

			// Создание заголовка
			DocumentFormat.OpenXml.Wordprocessing.Paragraph paragraph = Body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());
			DocumentFormat.OpenXml.Wordprocessing.Run run = paragraph.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Run());

			run.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.RunProperties(new Bold()));
			run.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Text(config.Header));

			// Создание диаграммы
			_chart = CreatorDiagram.GeneratePieChart(config);

			// Сохранение в файл
			if (config.FilePath.IsEmpty())
			{
				throw new ArgumentNullException("Имя файла не задано");
			}

			if (_document == null || _body == null)
			{
				throw new ArgumentNullException("Документ не сформирован, сохранять нечего");
			}

			using WordprocessingDocument wordprocessingDocument = WordprocessingDocument.Create(config.FilePath, WordprocessingDocumentType.Document);
			MainDocumentPart mainDocumentPart = wordprocessingDocument.AddMainDocumentPart();
			mainDocumentPart.Document = Document;

			if (_chart != null)
			{
				ChartPart chartPart = mainDocumentPart.AddNewPart<ChartPart>("rId110");
				ChartSpace chartSpace = new ChartSpace();
				chartSpace.Append(new EditingLanguage
				{
					Val = (StringValue)"en-us"
				});

				chartSpace.Append(_chart);
				ChartShapeProperties chartShapeProperties = new ChartShapeProperties();
				DocumentFormat.OpenXml.Drawing.Outline outline = new DocumentFormat.OpenXml.Drawing.Outline();

				outline.Append(new NoFill());
				chartShapeProperties.Append(outline);
				chartSpace.Append(chartShapeProperties);
				chartPart.ChartSpace = chartSpace;

				paragraph = new DocumentFormat.OpenXml.Wordprocessing.Paragraph
				{
					RsidParagraphAddition = (HexBinaryValue)"00C75AEB",
					RsidRunAdditionDefault = (HexBinaryValue)"000F3EFF"
				};

				run = new DocumentFormat.OpenXml.Wordprocessing.Run();
				Drawing drawing = new Drawing();
				Inline inline = new Inline();

				inline.Append(new Extent
				{
					Cx = (Int64Value)5274310L,
					Cy = (Int64Value)3076575L
				});

				DocProperties docProperties = new DocProperties
				{
					Id = (UInt32Value)1u,
					Name = (StringValue)"Chart 1"
				};

				inline.Append(docProperties);
				Graphic graphic = new Graphic();

				GraphicData graphicData = new GraphicData
				{
					Uri = (StringValue)"http://schemas.openxmlformats.org/drawingml/2006/chart"
				};

				ChartReference chartReference = new ChartReference
				{
					Id = (StringValue)"rId110"
				};

				graphicData.Append(chartReference);
				graphic.Append(graphicData);
				inline.Append(graphic);
				drawing.Append(inline);

				run.Append(drawing);
				paragraph.Append(run);
				mainDocumentPart.Document.Body!.Append(paragraph);
			}
		}
	}
}

using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml;
using MyCustomComponents.Models;
using System;
using DocumentFormat.OpenXml.Drawing.Wordprocessing;
using DocumentFormat.OpenXml.Wordprocessing;

namespace MyCustomComponents.Helpers
{
	public class DiagramService
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

		public DiagramService()
		{
			_document = new Document();
			_body = _document.AppendChild(new Body());
		}

		// Метод для создания документа с диаграммой
		public void CreateHeader(string header)
		{
			DocumentFormat.OpenXml.Wordprocessing.Paragraph paragraph = Body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());
			DocumentFormat.OpenXml.Wordprocessing.Run run = paragraph.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Run());

			run.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.RunProperties(new Bold()));
			run.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Text(header));
		}

		public void SaveDoc(string filepath)
		{
			if (filepath.IsEmpty())
			{
				throw new ArgumentNullException("Имя файла не задано");
			}

			if (_document == null || _body == null)
			{
				throw new ArgumentNullException("Документ не сформирован, сохранять нечего");
			}

			using WordprocessingDocument wordprocessingDocument = WordprocessingDocument.Create(filepath, WordprocessingDocumentType.Document);
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
				
				GeneratePartContent(mainDocumentPart);
			}
		}

		private static void GeneratePartContent(MainDocumentPart mainPart)
		{
			DocumentFormat.OpenXml.Wordprocessing.Paragraph paragraph = new DocumentFormat.OpenXml.Wordprocessing.Paragraph
			{
				RsidParagraphAddition = (HexBinaryValue)"00C75AEB",
				RsidRunAdditionDefault = (HexBinaryValue)"000F3EFF"
			};

			DocumentFormat.OpenXml.Wordprocessing.Run run = new DocumentFormat.OpenXml.Wordprocessing.Run();
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
			mainPart.Document.Body!.Append(paragraph);
		}

		public void CreatePieChart(WordWithDiagramConfig config)
		{
			_chart = CreatorDiagram.GeneratePieChart(config);
		}
	}
}

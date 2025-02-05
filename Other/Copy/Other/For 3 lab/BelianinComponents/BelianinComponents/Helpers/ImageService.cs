using DocumentFormat.OpenXml.Drawing.Wordprocessing;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace BelianinComponents.Helpers
{
	public class ImageService
	{
		// Хранит документ Word
		private Document _document = null;

		// Хранит тело документа Word
		private Body _body = null;

		// Список байтовых массивов для изображений
		private List<byte[]> _images = null;

		// Свойство для получения или создания документа Word
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

		// Свойство для получения или создания тела документа Word
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

		// Свойство для получения списка изображений
		private List<byte[]> Images
		{
			get
			{
				// Если список изображений еще не создан, инициализируем его
				if (_images == null)
				{
					_images = new List<byte[]>();
				}

				return _images;
			}
		}

		public void CreateHeader(string header)
		{
			DocumentFormat.OpenXml.Wordprocessing.Paragraph paragraph = Body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());
			DocumentFormat.OpenXml.Wordprocessing.Run run = paragraph.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Run());
			run.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.RunProperties(new Bold()));
			run.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Text(header));
		}

		public void CreateImage(byte[] image)
		{
			if (image == null || image.Length == 0)
			{
				throw new ArgumentNullException("Картинка не загружена");
			}

			Images.Add(image);
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
			if (_images != null)
			{
				int num = 0;
				foreach (byte[] image in _images)
				{
					ImagePart imagePart = mainDocumentPart.AddImagePart(ImagePartType.Jpeg);
					using (MemoryStream memoryStream = new MemoryStream(image))
					{
						memoryStream.Position = 0L;
						imagePart.FeedData(memoryStream);
					}

					AddImageToBody(mainDocumentPart.GetIdOfPart(imagePart), ++num);
				}
			}
		}

			private void AddImageToBody(string relationshipId, int index)
		{
			OpenXmlElement[] array = new OpenXmlElement[1];
			OpenXmlElement[] obj = new OpenXmlElement[5]
			{
				new Extent
				{
					Cx = (Int64Value)3000000L,
					Cy = (Int64Value)3000000L
				},
				new EffectExtent
				{
					LeftEdge = (Int64Value)0L,
					TopEdge = (Int64Value)0L,
					RightEdge = (Int64Value)0L,
					BottomEdge = (Int64Value)0L
				},
				null,
				null,
				null
			};
			DocProperties obj2 = new DocProperties
			{
				Id = (UInt32Value)1u
			};
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(8, 1);
			defaultInterpolatedStringHandler.AppendLiteral("Picture ");
			defaultInterpolatedStringHandler.AppendFormatted(index);
			obj2.Name = (StringValue)defaultInterpolatedStringHandler.ToStringAndClear();
			obj[2] = obj2;
			obj[3] = new DocumentFormat.OpenXml.Drawing.Wordprocessing.NonVisualGraphicFrameDrawingProperties(new GraphicFrameLocks
			{
				NoChangeAspect = (BooleanValue)true
			});
			OpenXmlElement[] array2 = new OpenXmlElement[1];
			OpenXmlElement[] array3 = new OpenXmlElement[1];
			OpenXmlElement[] array4 = new OpenXmlElement[3];
			OpenXmlElement[] array5 = new OpenXmlElement[2];
			DocumentFormat.OpenXml.Drawing.Pictures.NonVisualDrawingProperties obj3 = new DocumentFormat.OpenXml.Drawing.Pictures.NonVisualDrawingProperties
			{
				Id = (UInt32Value)0u
			};
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(16, 1);
			defaultInterpolatedStringHandler.AppendLiteral("New Picture ");
			defaultInterpolatedStringHandler.AppendFormatted(index);
			defaultInterpolatedStringHandler.AppendLiteral(".jpg");
			obj3.Name = (StringValue)defaultInterpolatedStringHandler.ToStringAndClear();
			array5[0] = obj3;
			array5[1] = new DocumentFormat.OpenXml.Drawing.Pictures.NonVisualPictureDrawingProperties();
			array4[0] = new DocumentFormat.OpenXml.Drawing.Pictures.NonVisualPictureProperties(array5);
			array4[1] = new DocumentFormat.OpenXml.Drawing.Pictures.BlipFill(new Blip(new BlipExtensionList(new BlipExtension
			{
				Uri = (StringValue)"{28A0092B-C50C-407E-A947-70E740481C1C}"
			}))
			{
				Embed = (StringValue)relationshipId,
				CompressionState = (EnumValue<BlipCompressionValues>)BlipCompressionValues.Print
			}, new Stretch(new FillRectangle()));
			array4[2] = new DocumentFormat.OpenXml.Drawing.Pictures.ShapeProperties(new Transform2D(new Offset
			{
				X = (Int64Value)0L,
				Y = (Int64Value)0L
			}, new Extents
			{
				Cx = (Int64Value)990000L,
				Cy = (Int64Value)792000L
			}), new PresetGeometry(new AdjustValueList())
			{
				Preset = (EnumValue<ShapeTypeValues>)ShapeTypeValues.Rectangle
			});
			array3[0] = new DocumentFormat.OpenXml.Drawing.Pictures.Picture(array4);
			array2[0] = new GraphicData(array3)
			{
				Uri = (StringValue)"http://schemas.openxmlformats.org/drawingml/2006/picture"
			};
			obj[4] = new Graphic(array2);
			array[0] = new Inline(obj)
			{
				DistanceFromTop = (UInt32Value)0u,
				DistanceFromBottom = (UInt32Value)0u,
				DistanceFromLeft = (UInt32Value)0u,
				DistanceFromRight = (UInt32Value)0u,
				EditId = (HexBinaryValue)"50D07946"
			};

			Drawing drawing = new Drawing(array);
			Body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new DocumentFormat.OpenXml.Wordprocessing.Run(drawing)));
		}

	}
}

using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml;
using MyCustomComponents.Helpers;
using MyCustomComponents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCustomComponents.Helpers
{
	public class TableService
	{
		private Document _document = null;

		private Body _body = null;

		private DocumentFormat.OpenXml.Wordprocessing.Table _table = null;

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

		// Свойство для создания или получения содержимого (Body) документа
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

		// Свойство для создания или получения таблицы
		private DocumentFormat.OpenXml.Wordprocessing.Table Table
		{
			get
			{
				if (_table == null)
				{
					_table = new DocumentFormat.OpenXml.Wordprocessing.Table();
				}

				return _table;
			}
		}

		// Метод для сохранения документа
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

			if (_table != null)
			{
				Body.Append(Table);
			}

			using WordprocessingDocument wordprocessingDocument = WordprocessingDocument.Create(filepath, WordprocessingDocumentType.Document);
			MainDocumentPart mainDocumentPart = wordprocessingDocument.AddMainDocumentPart();
			mainDocumentPart.Document = Document;

		}

		// Метод для загрузки данных в таблицу
		public void LoadDataToTableWithColumnHeader(string[,] data)
		{
			for (int i = 0; i < data.GetLength(0); i++)
			{
				DocumentFormat.OpenXml.Wordprocessing.TableRow tableRow = Table.Elements<DocumentFormat.OpenXml.Wordprocessing.TableRow>().ElementAt(i);

				for (int j = 0; j < data.GetLength(1); j++)
				{
					DocumentFormat.OpenXml.Wordprocessing.TableCell tableCell = new DocumentFormat.OpenXml.Wordprocessing.TableCell();
					tableCell.Append(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new DocumentFormat.OpenXml.Wordprocessing.Run(new DocumentFormat.OpenXml.Wordprocessing.Text(data[i, j]))));
					tableRow.Append(tableCell);
				}
			}
		}

		// Метод для добавления заголовка с объединением колонок
		private void AddColumnHeaderCellMergeByCols(string header, int rowHeight)
		{
			DocumentFormat.OpenXml.Wordprocessing.TableRow tableRow = new DocumentFormat.OpenXml.Wordprocessing.TableRow();
			int? rowHeight2 = rowHeight;

			DocumentFormat.OpenXml.Wordprocessing.TableCell tableCell = CreateCell(header, null, rowHeight2);
			tableCell.Append(new HorizontalMerge
			{
				Val = (EnumValue<MergedCellValues>)MergedCellValues.Restart
			});

			tableRow.Append(tableCell);
			tableCell = new DocumentFormat.OpenXml.Wordprocessing.TableCell(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());
			tableCell.Append(new HorizontalMerge
			{
				Val = (EnumValue<MergedCellValues>)MergedCellValues.Continue
			});

			tableRow.Append(tableCell);
			Table.Append(tableRow);
		}

		// Метод для создания ячейки таблицы
		private static DocumentFormat.OpenXml.Wordprocessing.TableCell CreateCell(string header, int? columnWidth = null, int? rowHeight = null)
		{
			DocumentFormat.OpenXml.Wordprocessing.TableCell tableCell = new DocumentFormat.OpenXml.Wordprocessing.TableCell();
			DocumentFormat.OpenXml.Wordprocessing.TableCellProperties tableCellProperties = new DocumentFormat.OpenXml.Wordprocessing.TableCellProperties();

			// Задание высоты строки, если указана
			if (rowHeight.HasValue)
			{
				tableCellProperties.Append(new TableRowHeight
				{
					Val = (UInt32Value)Convert.ToUInt32(rowHeight)
				});
			}

			// Задание ширины колонки, если указана
			if (columnWidth.HasValue)
			{
				tableCellProperties.Append(new TableCellWidth
				{
					Width = (StringValue)columnWidth.Value.ToString()
				});
			}

			tableCellProperties.Append(new TableCellVerticalAlignment
			{
				Val = (EnumValue<TableVerticalAlignmentValues>)TableVerticalAlignmentValues.Center
			});

			tableCell.Append(tableCellProperties);
			DocumentFormat.OpenXml.Wordprocessing.Paragraph paragraph = new DocumentFormat.OpenXml.Wordprocessing.Paragraph();
			DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties paragraphProperties = new DocumentFormat.OpenXml.Wordprocessing.ParagraphProperties();

			paragraphProperties.Append(new Justification
			{
				Val = (EnumValue<JustificationValues>)JustificationValues.Center
			});

			paragraph.Append(paragraphProperties);

			if (header.HaveText())
			{
				DocumentFormat.OpenXml.Wordprocessing.Run run = new DocumentFormat.OpenXml.Wordprocessing.Run();
				run.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.RunProperties(new Bold()));
				run.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Text(header));
				paragraph.Append(run);
			}

			tableCell.Append(paragraph);
			return tableCell;
		}

		// Метод для создания заголовков колонок
		public void CreateColumnHeader(WordWithTableConfig config)
		{
			// Логика создания заголовков таблицы с объединением ячеек
			int k;
			for (k = 0; k < config.ColumnUnion[0].StartIndex; k++)
			{
				AddColumnHeaderCellMergeByCols(config.Headers.FirstOrDefault<(int, int, string, string)>(((int ColumnIndex, int RowIndex, string Header, string PropertyName) x) => x.ColumnIndex == k).Item3, config.ColumnsRowsWidth[k].Row);
			}

			int j;
			for (j = 0; j < config.ColumnUnion.Count; j++)
			{
				int l;
				for (l = config.ColumnUnion[j].StartIndex; l < config.ColumnUnion[j].StartIndex + config.ColumnUnion[j].Count; l++)
				{
					DocumentFormat.OpenXml.Wordprocessing.TableRow tableRow = new DocumentFormat.OpenXml.Wordprocessing.TableRow();

					if (l == config.ColumnUnion[j].StartIndex)
					{
						DocumentFormat.OpenXml.Wordprocessing.TableCell tableCell = CreateCell(config.Headers.FirstOrDefault<(int, int, string, string)>(((int ColumnIndex, int RowIndex, string Header, string PropertyName) x) => x.ColumnIndex == l && x.RowIndex == 0).Item3);

						tableCell.Append(new VerticalMerge
						{
							Val = (EnumValue<MergedCellValues>)MergedCellValues.Restart
						});

						tableRow.Append(tableCell);
					}
					else
					{
						DocumentFormat.OpenXml.Wordprocessing.TableCell tableCell2 = new DocumentFormat.OpenXml.Wordprocessing.TableCell(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());

						tableCell2.Append(new VerticalMerge
						{
							Val = (EnumValue<MergedCellValues>)MergedCellValues.Continue
						});

						tableRow.Append(tableCell2);
					}

					OpenXmlElement[] array = new OpenXmlElement[1];
					string item = config.Headers.FirstOrDefault<(int, int, string, string)>(((int ColumnIndex, int RowIndex, string Header, string PropertyName) x) => x.ColumnIndex == l && x.RowIndex == 1).Item3;
					int? rowHeight = config.ColumnsRowsWidth[l].Row;

					array[0] = CreateCell(item, null, rowHeight);
					tableRow.Append(array);
					Table.Append(tableRow);
				}

				if (j >= config.ColumnUnion.Count - 1)
				{
					continue;
				}

				for (int m = config.ColumnUnion[j].StartIndex + config.ColumnUnion[j].Count; m < config.ColumnUnion[j + 1].StartIndex; m++)
				{
					AddColumnHeaderCellMergeByCols(config.Headers.FirstOrDefault<(int, int, string, string)>(((int ColumnIndex, int RowIndex, string Header, string PropertyName) x) => x.ColumnIndex == j).Item3, config.ColumnsRowsWidth[j].Row);
				}
			}

			int i;
			for (i = config.ColumnUnion[config.ColumnUnion.Count - 1].StartIndex + config.ColumnUnion[config.ColumnUnion.Count - 1].Count; i < config.ColumnsRowsWidth.Count; i++)
			{
				AddColumnHeaderCellMergeByCols(config.Headers.FirstOrDefault<(int, int, string, string)>(((int ColumnIndex, int RowIndex, string Header, string PropertyName) x) => x.ColumnIndex == i).Item3, config.ColumnsRowsWidth[i].Row);
			}
		}

		// Метод для создания таблицы с заголовком
		public void CreateTableWithHeader()
		{
			Table.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.TableProperties(new TableBorders(new DocumentFormat.OpenXml.Wordprocessing.TopBorder
			{
				Val = new EnumValue<BorderValues>(BorderValues.Single),
				Size = (UInt32Value)12u
			}, new DocumentFormat.OpenXml.Wordprocessing.BottomBorder
			{
				Val = new EnumValue<BorderValues>(BorderValues.Single),
				Size = (UInt32Value)12u
			}, new DocumentFormat.OpenXml.Wordprocessing.LeftBorder
			{
				Val = new EnumValue<BorderValues>(BorderValues.Single),
				Size = (UInt32Value)12u
			}, new DocumentFormat.OpenXml.Wordprocessing.RightBorder
			{
				Val = new EnumValue<BorderValues>(BorderValues.Single),
				Size = (UInt32Value)12u
			}, new DocumentFormat.OpenXml.Wordprocessing.InsideHorizontalBorder
			{
				Val = new EnumValue<BorderValues>(BorderValues.Single),
				Size = (UInt32Value)12u
			}, new DocumentFormat.OpenXml.Wordprocessing.InsideVerticalBorder
			{
				Val = new EnumValue<BorderValues>(BorderValues.Single),
				Size = (UInt32Value)12u
			})));
		}

		// Метод для создания заголовка документа
		public void CreateHeader(string header)
		{
			DocumentFormat.OpenXml.Wordprocessing.Paragraph paragraph = Body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());
			DocumentFormat.OpenXml.Wordprocessing.Run run = paragraph.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Run());

			run.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.RunProperties(new Bold()));
			run.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Text(header));
		}
	}
}

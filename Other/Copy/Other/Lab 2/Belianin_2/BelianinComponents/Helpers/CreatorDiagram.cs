using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Drawing.Charts;
using BelianinComponents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelianinComponents.Helpers
{
	// Класс CreatorDiagram отвечает за создание диаграмм
	public class CreatorDiagram
	{
		// Порядок и индекс используются для нумерации серий на диаграмме
		private static uint order = 0u;

		private static uint index = 1u;

		// Метод GeneratePieChart генерирует круговую диаграмму на основе конфигурации
		public static DocumentFormat.OpenXml.Drawing.Charts.Chart GeneratePieChart(WordWithDiagramConfig config)
		{
			// Создаем объект PieChart
			PieChart pieChart = new PieChart();

			// Добавляем первую серию данных в диаграмму
			pieChart.Append(GeneratePieChartSeries(config.Data.First().Key, config.Data.First().Value));

			// Создаем область построения (PlotArea) для диаграммы
			// Добавляем макет для более гибкого управления размещением элементов. Добавляем круговую диаграмму в область построения
			PlotArea plotArea = new PlotArea();
			plotArea.Append(new Layout());
			plotArea.Append(pieChart);

			// Возвращаем объект диаграммы с заголовком и расположением легенды
			return GenerateChart(config.ChartTitle, plotArea, config.LegendLocation);
		}

		private static DocumentFormat.OpenXml.Drawing.Charts.Chart GenerateChart(string titleText, PlotArea plotArea, Location legendLocation)
		{
			DocumentFormat.OpenXml.Drawing.Charts.Chart chart = new DocumentFormat.OpenXml.Drawing.Charts.Chart();

			// Проверяем текст заголовка и добавляем его
			if (titleText.HaveText())
			{
				chart.Append(GenerateTitle(titleText));
			}
			else
			{
				chart.Append(new AutoTitleDeleted
				{
					Val = (BooleanValue)true
				});
			}

			// Определяем позицию легенды на основе переданного значения
			LegendPositionValues position = legendLocation switch
			{
				Location.Top => LegendPositionValues.Top,
				Location.Right => LegendPositionValues.Right,
				Location.Left => LegendPositionValues.Left,
				_ => LegendPositionValues.Bottom,
			};

			// Добавляем область построения и легенду к диаграмме
			chart.Append(plotArea);
			chart.Append(GenerateLegend(position));

			// Устанавливаем видимость только для отображаемых данных
			chart.Append(new PlotVisibleOnly
			{
				Val = (BooleanValue)true
			});

			return chart;
		}

		// Метод создает объект легенды для диаграммы
		private static Legend GenerateLegend(LegendPositionValues position)
		{
			// Свойства текста для легенды
			ParagraphProperties paragraphProperties = new ParagraphProperties();
			paragraphProperties.Append(new DefaultRunProperties());

			Paragraph paragraph = new Paragraph();
			paragraph.Append(paragraphProperties);
			paragraph.Append(new EndParagraphRunProperties());

			TextProperties textProperties = new TextProperties();
			textProperties.Append(new BodyProperties());
			textProperties.Append(new ListStyle());
			textProperties.Append(paragraph);

			// Создаем объект легенды с заданной позицией
			Legend legend = new Legend();
			legend.Append(new LegendPosition
			{
				Val = (EnumValue<LegendPositionValues>)position
			});

			legend.Append(new Layout());
			legend.Append(new Overlay
			{
				Val = (BooleanValue)false
			});

			// Добавляем свойства текста к легенде
			legend.Append(textProperties);

			return legend;
		}

		// Метод создает объект заголовка для диаграммы
		private static Title GenerateTitle(string titleText)
		{
			// Создаем объект Run для текста заголовка
			Run run = new Run();
			run.Append(new RunProperties
			{
				FontSize = (Int32Value)1100
			});

			run.Append(new Text(titleText)); // Добавялем текст заголовка

			// Свойства абзаца для заголовка
			ParagraphProperties paragraphProperties = new ParagraphProperties();
			paragraphProperties.Append(new DefaultRunProperties
			{
				FontSize = (Int32Value)1100
			});

			Paragraph paragraph = new Paragraph();
			paragraph.Append(paragraphProperties);
			paragraph.Append(run);

			// Создаем RichText, чтобы включить заголовок в диаграмму
			RichText richText = new RichText();
			richText.Append(new BodyProperties());
			richText.Append(new ListStyle());
			richText.Append(paragraph);

			ChartText chartText = new ChartText();
			chartText.Append(richText);

			// Создаем объект Title, содержащий текст заголовка
			Title title = new Title();
			title.Append(chartText);
			title.Append(new Layout());	// Добавляем макет

			// Производим наложение
			title.Append(new Overlay
			{
				Val = (BooleanValue)false
			});

			return title;
		}

		// Метод создает текст для серий данных
		private static SeriesText GenerateSeriesText(string seriesName)
		{
			StringPoint stringPoint = new StringPoint
			{
				Index = (UInt32Value)0u
			};

			stringPoint.Append(new NumericValue
			{
				Text = seriesName
			});

			// Кэш строковых значений
			StringCache stringCache = new StringCache();
			stringCache.Append(new PointCount
			{
				Val = (UInt32Value)1u
			});

			stringCache.Append(stringPoint);

			StringReference stringReference = new StringReference();
			stringReference.Append(stringCache);

			SeriesText seriesText = new SeriesText();
			seriesText.Append(stringReference);

			return seriesText;
		}

		// Метод создает данные оси категорий
		private static CategoryAxisData GenerateCategoryAxisData(string[] data)
		{
			uint number = (uint)data.Length;
			NumberingCache numberingCache = GenerateNumberingCache(number);

			for (uint number2 = 0u; number2 < number; number2++)
			{
				numberingCache.Append(GenerateNumericPoint(number2, data[number2].ToString()));
			}

			NumberReference numberReference = new NumberReference();
			numberReference.Append(numberingCache);

			CategoryAxisData categoryAxisData = new CategoryAxisData();
			categoryAxisData.Append(numberReference);

			return categoryAxisData;
		}

		// Метод создает объект значений для диаграммы
		private static Values GenerateValues(double[] data)
		{
			uint number = (uint)data.Length;
			NumberingCache numberingCache = GenerateNumberingCache(number);

			for (uint number2 = 0u; number2 < number; number2++)
			{
				numberingCache.Append(GenerateNumericPoint(number2, data[number2].ToString()));
			}

			NumberReference numberReference = new NumberReference();
			numberReference.Append(numberingCache);

			Values values = new Values();
			values.Append(numberReference);

			return values;
		}

		// Метод создает кэш для числовых данных
		private static NumberingCache GenerateNumberingCache(uint numberPoints)
		{
			NumberingCache numberingCache = new NumberingCache();
			numberingCache.Append(new FormatCode
			{
				Text = "General"
			});

			numberingCache.Append(new PointCount
			{
				Val = (UInt32Value)numberPoints
			});

			return numberingCache;
		}

		// Метод создает числовую точку данных
		private static NumericPoint GenerateNumericPoint(UInt32Value idx, string text)
		{
			NumericPoint numericPoint = new NumericPoint
			{
				Index = idx
			};
			numericPoint.Append(new NumericValue
			{
				Text = text
			});

			return numericPoint;
		}

		// Метод создает серию данных для круговой диаграммы
		private static PieChartSeries GeneratePieChartSeries(string seriesName, List<(int Date, double Value)> data)
		{
			// Создаем объект серии для круговой диаграммы
			PieChartSeries pieChartSeries = new PieChartSeries();
			pieChartSeries.Append(new DocumentFormat.OpenXml.Drawing.Charts.Index
			{
				Val = (UInt32Value)index
			});
			pieChartSeries.Append(new Order
			{
				Val = (UInt32Value)order
			});

			// Добавляем текст серии, данные оси категорий и значения
			pieChartSeries.Append(GenerateSeriesText(seriesName));
			pieChartSeries.Append(GenerateCategoryAxisData(data.Select(((int Date, double Value) c) => c.Date.ToString()).ToArray()));
			pieChartSeries.Append(GenerateValues(data.Select(((int Date, double Value) v) => v.Value).ToArray()));

			index++;
			order++;

			return pieChartSeries;
		}

	}
}

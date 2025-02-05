using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Drawing.Wordprocessing;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml;
using BelianinComponents.Helpers;
using BelianinComponents.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Wordprocessing;

namespace BelianinComponents
{
	public partial class WordWithDiagram : Component
	{
		private DiagramService creator;

		// Конструктор по умолчанию
		public WordWithDiagram()
		{
			InitializeComponent();
			creator = new DiagramService();
		}

		// Конструктор с контейнером для компонентов
		public WordWithDiagram(IContainer container)
		{
			container.Add(this);

			InitializeComponent();
			creator = new DiagramService();
		}

		public void CreateDoc(WordWithDiagramConfig config)
		{
			config.CheckFields();

			// Создание заголовка
			creator.CreateHeader(config.Header);

			// Создание диаграммы
			creator.CreatePieChart(config);

			// Сохранение в файл
			creator.SaveDoc(config.FilePath);
		}
	}
}

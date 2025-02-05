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
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using System.Reflection;

namespace BelianinComponents
{
	public partial class WordWithImages : Component
	{
		private ImageService creator;

		// Конструктор по умолчанию
		public WordWithImages()
		{
			InitializeComponent();
			creator = new ImageService();
		}

		// Конструктор с контейнером для компонентов
		public WordWithImages(IContainer container)
		{
			container.Add(this);
			InitializeComponent();
			creator = new ImageService();
		}

		// Метод для создания документа Word с изображениями
		public void CreateDoc(WordWithImageConfig config)
		{
			config.CheckFields();

			// Создание заголовка
			creator.CreateHeader(config.Header);
			
			// Создание и добавление всех изображений
			foreach (byte[] image in config.Images)
			{
				creator.CreateImage(image);
			}

			// Сохранение файла
			creator.SaveDoc(config.FilePath);
		}
	}
}

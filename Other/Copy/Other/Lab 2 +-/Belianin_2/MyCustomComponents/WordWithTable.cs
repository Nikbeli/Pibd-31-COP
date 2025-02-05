using MyCustomComponents.Helpers;
using MyCustomComponents.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCustomComponents
{
	public partial class WordWithTable : Component
	{
		private TableService creator;

		// Конструктор
		public WordWithTable()
		{
			InitializeComponent();
			creator = new TableService();
		}

		// Конструктор с контейнером
		public WordWithTable(IContainer container)
		{
			container.Add(this);

			InitializeComponent();

			creator = new TableService();
		}

		// Метод для создания документа с таблицей
		public void CreateDoc<T>(WordWithTableDataConfig<T> config)
		{
			config.CheckFields();
			config.ColumnsRowsDataCount = (config.Data.Count + 2, config.ColumnsRowsWidth.Count);
			
			creator.CreateHeader(config.Header);    // Создание заголовка
			creator.CreateTableWithHeader();    // Создание таблицы с заголовком
			creator.CreateColumnHeader(config);		// Создание заголовков столбцов

			// Создание массива данных для таблицы
			string[,] array = new string[config.ColumnsRowsWidth.Count, config.Data.Count];
			for (int j = 0; j < config.Data.Count; j++)
			{
				int i;

				for (i = 0; i < config.ColumnsRowsWidth.Count; i++)
				{
					(int, int, string, string) tuple = config.Headers.FirstOrDefault<(int, int, string, string)>(((int ColumnIndex, int RowIndex, string Header, string PropertyName) x) => x.ColumnIndex == i && x.RowIndex == 1);
					if (tuple.Equals(default((int, int, string, string))))
					{
						tuple = config.Headers.FirstOrDefault<(int, int, string, string)>(((int ColumnIndex, int RowIndex, string Header, string PropertyName) x) => x.ColumnIndex == i && x.RowIndex == 0);
					}

					array[i, j] = config.Data[j].GetType().GetProperty(tuple.Item4)!.GetValue(config.Data[j], null)!.ToString();
				}
			}

			// Загрузка данных в таблицу и последующее сохранение документа
			creator.LoadDataToTableWithColumnHeader(array);
			creator.SaveDoc(config.FilePath);
		}
	}
}

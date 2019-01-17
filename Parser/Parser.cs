using System;
using System.Collections.Generic;
using System.Data;

namespace Parser
{
	public class Parser
	{
		/// <summary>
		/// Преобразует входной набор данных в DataTable
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public DataTable GetDataTable(List<FieldSet> data)
		{
			DataTable table = new DataTable();

			DataColumn user = new DataColumn("Пользователь", Type.GetType("System.String"));
			DataColumn date = new DataColumn("Дата", Type.GetType("System.String"));
			DataColumn quantity = new DataColumn("Количество", Type.GetType("System.String"));
			DataColumn real = new DataColumn("Реальная", Type.GetType("System.String"));
			DataColumn income = new DataColumn("Входная", Type.GetType("System.String"));
			DataColumn retail = new DataColumn("Розница", Type.GetType("System.String"));
			DataColumn corp = new DataColumn("Корп.", Type.GetType("System.String"));
			DataColumn provider = new DataColumn("Поставщик", Type.GetType("System.String"));

			table.Columns.Add(user);
			table.Columns.Add(date);
			table.Columns.Add(quantity);
			table.Columns.Add(real);
			table.Columns.Add(income);
			table.Columns.Add(retail);
			table.Columns.Add(corp);
			table.Columns.Add(provider);

			foreach (var i in data)
			{
				table.Rows.Add(new object[] {
					i.User,
					i.Date,
					i.Quantity,
					i.Real,
					i.Income,
					i.Retail,
					i.Corp,
					i.Provider
				});
			}

			return table;
		}
	}
}

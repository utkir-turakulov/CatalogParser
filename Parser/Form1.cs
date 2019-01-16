using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Parser
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			FileReader reader = new FileReader();
			string appPath = Directory.GetCurrentDirectory();
			string path = Path.GetFullPath(appPath + "\\pages\\test.txt");
			string page = reader.GetLines(path);

			var document = new HtmlParser().ParseDocument(page);

			Catalog catalog = new Catalog(document);

			var elements = catalog.GetElements();


			foreach(var el in elements)
			{
				richTextBox1.Text += el.Corp;
			}

		}
	}
}

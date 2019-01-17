using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Parser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

		/// <summary>
		/// Кнопка parse
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            FileReader reader = new FileReader();
            string appPath = Directory.GetCurrentDirectory();
            string path = Path.GetFullPath(appPath + "\\pages\\test.txt");
            string page = reader.GetLines(path);

            var document = new HtmlParser().ParseDocument(page);
            Catalog catalog = new Catalog(document);
			Parser parser = new Parser();

            dataGridView1.DataSource = parser.GetDataTable(catalog.GetElements());
        }

    }
}

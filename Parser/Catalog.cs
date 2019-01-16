using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using System;
using System.Collections.Generic;

namespace Parser
{
    public class Catalog
    {
        private string Table = "table tbody";
        private string Rows = "tr";
        private string Colls = "td";

        private IHtmlDocument _document = null;

        public Catalog(IHtmlDocument document)
        {
            _document = document;
        }

        public List<FieldSet> GetElements()
        {
            var table = _document.QuerySelector(Table);
            List<FieldSet> elements = new List<FieldSet>();
            FieldSet field = new FieldSet();

            if (table != null)
            {
                var rows = table.QuerySelectorAll(Rows);
                List<IElement> users = new List<IElement>();
                List<IElement> dates = new List<IElement>();
                List<IElement> quantity = new List<IElement>();
                List<IElement> real = new List<IElement>();
                List<IElement> incomes = new List<IElement>();
                List<IElement> retails = new List<IElement>();
                List<IElement> corps = new List<IElement>();
                List<IElement> providers = new List<IElement>();

                foreach (var i in rows)
                {
                    users.Add(i.QuerySelectorAll(Colls)[0]);
                    dates.Add(i.QuerySelectorAll(Colls)[1]);
                    quantity.Add(i.QuerySelectorAll(Colls)[2]);
                    real.Add(i.QuerySelectorAll(Colls)[3]);
                    incomes.Add(i.QuerySelectorAll(Colls)[4]);
                    retails.Add(i.QuerySelectorAll(Colls)[5]);
                    corps.Add(i.QuerySelectorAll(Colls)[6]);
                    providers.Add(i.QuerySelectorAll(Colls)[7]);
                }

                for (int i = 1; i < users.Count; i++)
                {
                    elements.Add(new FieldSet()
                    {
                        User = users[i].InnerHtml,
                        Date = dates[i].InnerHtml,
                        Quantity = BeautifyQuantity(quantity[i].InnerHtml),
                        Real = real[i].InnerHtml,
                        Income = incomes[i].InnerHtml,
                        Retail = retails[i].InnerHtml,
                        Corp = corps[i].InnerHtml,
                        Provider = DeleteTags(providers[i].InnerHtml)
                    });
                }
            }
            return elements;
        }


        /// <summary>
        /// Очистить поле от тегов
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string DeleteTags(string text)
        {
            try
            {
                if (text != null)
                {
                    string answer = "";
                    int index = text.IndexOf("<");

                    while (index >= 0)
                    {
                        int closingBracets = text.IndexOf(">");

                        if (index > 0)
                        {
                            answer += text.Remove(index, text.Length - index);
                            answer += text.Remove(0, closingBracets + 1);
                            text = answer;
                            answer = "";
                        }
                        if (index == 0)
                        {
                            answer += text.Remove(0, closingBracets + 1);
                            text = answer;
                            answer = "";
                        }
                        index = text.IndexOf("<");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("В методе BeautifyProductName {0}", e.Message);
            }

            return text;
        }

        /// <summary>
        /// Заменяем спец. символ на знак >
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
		private string BeautifyQuantity(string text)
        {
            try
            {
                if (text != null)
                {
                    if (text.Contains("&gt;"))
                    {
                        int index = text.IndexOf("&gt;");
                        text = text.Remove(index, 4);
                        text = text.Insert(index, ">");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("В методе BeautifyQuantity {0}", e.Message);
            }

            return text;
        }

    }
}

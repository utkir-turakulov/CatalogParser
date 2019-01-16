using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    class FileReader
    {
        public string GetLines(string path)
        {
			// List<string> lines = new List<string>();
			StringBuilder builder = new StringBuilder();

            using (StreamReader reader = new StreamReader(path))
            {
                string line = null;

                while ((line = reader.ReadLine()) != null)
                {
                    builder.Append(line);
                }
            }
            return builder.ToString();
        }

    }
}

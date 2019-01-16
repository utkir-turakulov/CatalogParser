using System.IO;
using System.Text;

namespace Parser
{
    class FileReader
    {
        public string GetLines(string path)
        {
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

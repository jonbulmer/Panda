using System;
using System.Net;
using System.IO;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Panda.Public.Data.Reader
{
    public class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddSingleton<IPublicDataReader, PublicDataReader>()
                .AddSingleton<IPublicJsonDataReader, PublicJsonDataReader>()
                .BuildServiceProvider();


            var logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();
            logger.LogDebug("Starting application");

            //do the actual work here
            var json = serviceProvider.GetService<IPublicDataReader>();
            json.ReadData();

            logger.LogDebug("All done!");
        }
    }


    public interface IPublicDataReader
    {
        void ReadData();
    }

    public interface IPublicJsonDataReader
    {
        public string ReadJson(string country);
    }

    public class PublicDataReader : IPublicDataReader
    {
        private readonly IPublicJsonDataReader _publicJsonDataReader;
        public PublicDataReader(IPublicJsonDataReader publicJsonDataReader)
        {
            _publicJsonDataReader = publicJsonDataReader;
        }
        public void ReadData()
        {
            string thisJson = _publicJsonDataReader.ReadJson("BEL");
        }
    }

    public class PublicJsonDataReader : IPublicJsonDataReader
    {

        public string ReadJson(string county)
        {
            string readJson = "";
            WebClient client = new WebClient();
            Stream stream = client.OpenRead("https://raw.githubusercontent.com/owid/covid-19-data/master/public/data/owid-covid-data.json");
            StringBuilder sb = new StringBuilder();
            var doWriteJson = false;
            sb.Append("{");
            using (var reader = new StreamReader(stream))
            {
                while (!reader.EndOfStream)
                {
                    readJson = reader.ReadLine();
                    readJson = readJson.Replace("\"", "'");
                    if (readJson ==  "    '"+ county +"': {" || doWriteJson == true)
                    {
                        doWriteJson = true;
                        sb.Append(readJson);
                        //sb.Replace("    '" + county + "': {", "}");
                        if (readJson == "    },")
                        {
                            sb.Remove(sb.Length - 1, 1);
                            sb.Append("}");
                            readJson = sb.ToString();
                            return readJson;
                        } 
                    }
                }
            }
            readJson = sb.ToString();
            return readJson;
        }
    }
}

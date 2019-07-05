using System;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace FileCounter
{
    public class CsvFileReader : IReader
    {
        private readonly string path;

        public CsvFileReader(IConfiguration configuration)
        {
            path = configuration["Path"];
        }

        public string[] Read()
        {
            return ReadInputData().Split(";");
        }

        private string ReadInputData()
        {
            try
            {
                return System.IO.File.ReadLines(path, Encoding.Default).FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }
    }
}

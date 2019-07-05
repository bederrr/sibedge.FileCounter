using System;
using System.Collections.Generic;
using System.Linq;

namespace FileCounter
{
    public class Counter : ICounter
    {
        private readonly List<File> files;
        private readonly List<string> inputData;

        public Counter(IReader reader)
        {
            inputData = reader.Read().ToList();
            files = new List<File>();
        }

        public string Calculate()
        {
            var result = "";
            return result;
        }

        private void AddFile(string[] file)
        {
            if (file.Length > 1)
            {
                var i = files.FindIndex(x => x.Type == file[file.Length - 1].ToLower());

                if (i != 0)
                {
                    files[i].Count++;
                }
                else
                {
                    files.Add(new File
                    {
                        Type = file[file.Length - 1],
                        Count = 1
                    });
                }
            }
            else
            {
                if (files.FirstOrDefault(x => x.Type == "Undefined") == null)
                {
                    files.Add(new File { Type = "Undefined", Count = 1 });
                }
                else
                {
                    var index = files.FindIndex(x => x.Type == "Undefined");
                    files[index].Count++;
                }
            }
        }

        private void GetTypes()
        {
            inputData.ForEach(x =>
            {
                if (x.Length > 0)
                {
                    AddFile(x.Split("."));
                }
            });
        }
    }
}

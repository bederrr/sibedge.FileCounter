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
            inputData.ForEach(x =>
            {
                if (x.Length > 0)
                {
                    ProcessFile(x.Split("."));
                }
            });
        }

        private void ProcessFile(string[] file)
        {
            if (file.Length > 1)
            {
                AddFile(file[file.Length-1].ToLower());
            }
            else
            {
                AddUndefinedFile();
            }
        }

        private void AddFile(string type)
        {
            var i = files.FindIndex(x => x.Type == type);

            if (i >= 0)
            {
                files[i].Count++;
            }
            else
            {
                files.Add(new File
                {
                    Type = type,
                    Count = 1
                });
            }
        }

        private void AddUndefinedFile()
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
}

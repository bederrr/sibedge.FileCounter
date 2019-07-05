using System;
using System.Collections.Generic;
using System.Linq;

namespace FileCounter
{
    ///<inheritdoc/>
    public class Counter : ICounter
    {
        private readonly List<File> files;
        private readonly List<string> inputData;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="reader">Ридер.</param>
        public Counter(IReader reader)
        {
            inputData = reader.Read().ToList();
            files = new List<File>();
        }

        public List<File> Calculate()
        {
            inputData.ForEach(x =>
            {
                if (x.Length > 0)
                    ProcessFile(x.Split("."));
            });
            return files;
        }

        private void ProcessFile(string[] file)
        {
            if (file.Length > 1)
            {
                AddType(file[file.Length-1].ToLower());
            }
            else
            {
                AddUndefinedType();
            }
        }

        private void AddType(string type)
        {
            var i = files.FindIndex(x => x.Type == type);

            if (i > -1)
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

        private void AddUndefinedType()
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

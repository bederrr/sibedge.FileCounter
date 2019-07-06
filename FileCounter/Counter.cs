using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

namespace FileCounter
{
    ///<inheritdoc/>
    public class Counter : ICounter
    {
        private readonly IReader reader;

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="reader">Ридер.</param>
        public Counter(IReader reader)
        {
            this.reader = reader;
        }

        public List<File> Calculate()
        {
            return reader.Read()
                .Select(x => x.Split("."))
                .Select(x => x.Length >= 2 ? x[x.Length - 1].ToLower() : "Undefined")
                .GroupBy(x => x)
                .OrderByDescending(x => x.Count())
                .Select(x => new File { Type = x.Key, Count = x.Count() }).ToList();
        }
    }
}

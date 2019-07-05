using System;

namespace FileCounter
{
    /// <summary>
    /// Считыватель.
    /// </summary>
    public interface IReader
    {
        /// <summary>
        /// Считать.
        /// </summary>
        /// <returns>Массив файлов.</returns>
        string[] Read();
    }
}

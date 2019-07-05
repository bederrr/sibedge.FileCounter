using System;
using System.Collections.Generic;

namespace FileCounter
{
    /// <summary>
    /// Подсчет количества типов.
    /// </summary>
    public interface ICounter
    {
        /// <summary>
        /// Подсчитать.
        /// </summary>
        /// <returns></returns>
        List<File> Calculate();
    }
}

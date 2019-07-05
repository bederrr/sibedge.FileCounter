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
        /// Посчитать.
        /// </summary>
        /// <returns>Список типов.</returns>
        List<File> Calculate();
    }
}

using Beauty.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beauty.Data.Models
{
    /// <summary>
    /// Модель данных должности сотрудника
    /// </summary>
    public class Position
    {
        /// <summary>
        /// Возвращает или задает идентификатор должности
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Возвращает или задает должность
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Возвращает или задает список моделей данных сотрудников, связанных с должностью
        /// </summary>
        public ICollection<WorkerPosition> WorkerPositions { get; set; }

        public Position()
        {
            WorkerPositions = new List<WorkerPosition>();
        }
    }
}

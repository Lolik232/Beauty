using System.Collections.Generic;

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
        public IEnumerable<WorkerPosition> WorkerPositions { get; set; }

        public IEnumerable<PositionService> PositionServices { get; set; }

        /// <summary>
        /// Базовый конструктор
        /// </summary>
        public Position()
        {
            WorkerPositions = new List<WorkerPosition>();
            PositionServices = new List<PositionService>();
        }
    }
}

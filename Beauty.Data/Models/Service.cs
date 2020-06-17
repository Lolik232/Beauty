using System.Collections.Generic;

namespace Beauty.Data.Models
{
    /// <summary>
    /// Модель данных услуги
    /// </summary>
    public class Service
    {
        /// <summary>
        /// Идентификатор услуги
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название услуги
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Возвращает или задает список моделей данных записей, связанных с услугами
        /// </summary>
        public IEnumerable<EnrollmentWorkerService> EnrollmentWorkerServices { get; set; }

        public IEnumerable<PositionService> PositionServices { get; set; }

        /// <summary>
        /// Базовый конструктор
        /// </summary>
        public Service()
        {
            EnrollmentWorkerServices = new List<EnrollmentWorkerService>();
            PositionServices = new List<PositionService>();
        }
    }
}

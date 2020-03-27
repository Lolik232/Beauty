using System.Collections.Generic;

namespace Beauty.Data.Models
{
    /// <summary>
    /// Модель данных записи
    /// </summary>
    public class Enrollment
    {
        /// <summary>
        /// Возвращает или задает идентификатор записи
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Возвращает или задает имя клиента
        /// </summary>
        public string ClientFirstname { get; set; }

        /// <summary>
        /// Возвращает или задает номер телефона клиента
        /// </summary>
        public string ClientPhoneNumber { get; set; }

        /// <summary>
        /// Возвращает или задает примечание
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// Возвращает или задает идентификатор сотрудника, связанного с текущей записью
        /// </summary>
        public int WorkerId { get; set; }

        /// <summary>
        /// Возвращает или задает модель данных сотрудника, связанного с текущей записью
        /// </summary>
        public Worker Worker { get; set; }

        /// <summary>
        /// Возвращает или задает список моделей данных записей, связанных с услугами
        /// </summary>
        public IEnumerable<EnrollmentService> EnrollmentServices { get; set; }

        /// <summary>
        /// Базовый конструктор
        /// </summary>
        public Enrollment()
        {
            EnrollmentServices = new List<EnrollmentService>();
        }
    }
}

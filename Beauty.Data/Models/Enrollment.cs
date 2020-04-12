using System;
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
        /// Возвращает или задает дату и время на которое записан клиент
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Возвращает или задает дату и время создания заявки
        /// </summary>
        public DateTime CreationDateTime { get; set; }

        /// <summary>
        /// Возвращает или задает дату редактирования заявки
        /// </summary>
        public DateTime? EditDateTime { get; set; }

        /// <summary>
        /// Возвращает или задает список моделей данных записей, связанных с услугами
        /// </summary>
        public IEnumerable<EnrollmentWorkerService> EnrollmentWorkerServices { get; set; }

        /// <summary>
        /// Базовый конструктор
        /// </summary>
        public Enrollment()
        {
            EnrollmentWorkerServices = new List<EnrollmentWorkerService>();
        }
    }
}

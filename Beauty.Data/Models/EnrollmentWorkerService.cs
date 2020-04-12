using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beauty.Data.Models
{
    /// <summary>
    /// Модель данных конкретной записи и конкретной услуги, которую выполняет конкретный сотрудник
    /// </summary>
    public class EnrollmentWorkerService
    {
        /// <summary>
        /// Возвращает или задает идентификатор текущего экземпляра
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Возвращает или задает идентификатор записи
        /// </summary>
        public int EnrollmentId { get; set; }
        
        /// <summary>
        /// Возвращает или задает запись
        /// </summary>
        public Enrollment Enrollment { get; set; }

        /// <summary>
        /// Возвращает или задает идентификатор сотрудника
        /// </summary>
        public int WorkerId { get; set; }

        /// <summary>
        /// Возвращает или задает сотрудника
        /// </summary>
        public Worker Worker { get; set; }

        /// <summary>
        /// Возвращает или задает идентификатор услуги
        /// </summary>
        public int ServiceId { get; set; }

        /// <summary>
        /// Возвращает или задает услугу
        /// </summary>
        public Service Service { get; set; }
    }
}

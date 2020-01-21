using Beauty.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// Возвращает или задает фамилию клиента
        /// </summary>
        public string ClientLastname { get; set; }

        /// <summary>
        /// Возвращает или задает номер телефона клиента
        /// </summary>
        public string ClientPhoneNumber { get; set; }

        /// <summary>
        /// Возвращает или задает примечение
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// Возвращает или задает идентификатор сотрудника, связанного с текущей записью
        /// </summary>
        public int WorkerId { get; set; }

        /// <summary>
        /// Возвращает или задает модель данных сотрудника, связанного с текущей записью
        /// Данное свойство не обязательно для заполнения
        /// </summary>
        public Worker Worker { get; set; }
    }
}

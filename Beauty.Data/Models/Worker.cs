﻿using System.Collections.Generic;

namespace Beauty.Data.Models
{
    /// <summary>
    /// Модель данных сотрудника
    /// </summary>
    public class Worker
    {
        /// <summary>
        /// Возвращает или задает идентификатор сотрудника
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Возвращает или задает фамилию сотрудника 
        /// Данное свойство не обязательно для заполнения
        /// </summary>
        public string Lastname { get; set; }

        /// <summary>
        /// Возвращает или задает имя сотрудника
        /// </summary>
        public string Firstname { get; set; }

        /// <summary>
        /// Возвращает или задает отчество сотрудника
        /// Данное свойство не обязательно для заполнения
        /// </summary>
        public string Middlename { get; set; } 

        /// <summary>
        /// Возвращает или задает пароль сотрудника в MD5 шифровании
        /// </summary>
        public string PasswordHash { get; set; }

        /// <summary>
        /// Возвращает или задает номер телефона сотрудника
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Возвращает или задает список моделей данных должностей, связанных с сотрудником
        /// </summary>
        public IEnumerable<WorkerPosition> WorkerPositions { get; set; }

        /// <summary>
        /// Возвращает или задает список моделей данных записей, связанных с сотрудником
        /// </summary>
        public IEnumerable<Enrollment> Enrollments { get; set; }

        public IEnumerable<EnrollmentWorkerService> EnrollmentWorkerServices { get; set; }

        /// <summary>
        /// Базовый конструктор
        /// </summary>
        public Worker()
        {
            WorkerPositions = new List<WorkerPosition>();
            Enrollments = new List<Enrollment>();
            EnrollmentWorkerServices = new List<EnrollmentWorkerService>();
        }
    }
}

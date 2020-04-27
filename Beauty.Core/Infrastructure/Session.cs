using Beauty.Data.Models;
using System;

namespace Beauty.Core.Infrastructure
{
    /// <summary>
    /// Класс, представляющий текущую пользовательскую сессию
    /// </summary>
    public class Session
    {
        /// <summary>
        /// Экземпляр сессии
        /// </summary>
        private static Session session;

        /// <summary>
        /// Возвращает экземпляр сессии
        /// </summary>
        internal static Session GetSession()
        {
            if (session is null)
            {
                session = new Session();
            }

            return session;
        }

        /// <summary>
        /// Авторизовавшийся пользователь
        /// </summary>
        public Worker Worker { get; internal set; }

        /// <summary>
        /// Дата и время входа в систему
        /// </summary>
        public DateTime? LoginDateTime { get; internal set; }
        
        /// <summary>
        /// Дата и время выхода из системы
        /// </summary>
        public DateTime? LogoutDateTime { get; internal set; }
    }
}

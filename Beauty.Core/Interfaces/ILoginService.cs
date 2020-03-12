using System.Threading.Tasks;

namespace Beauty.Core.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса авторизации
    /// </summary>
    public interface ILoginService
    {
        /// <summary>
        /// Авторизует пользователя в системе
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <param name="password">Пароль, полученный от пользователя</param>
        Task<bool> LoginAsync(int userId, string password);

        /// <summary>
        /// Осуществляет выход из системы для авторизованного в данный момент пользователя 
        /// </summary>
        void Logout();
    }
}
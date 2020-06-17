using System.Security.Cryptography;

namespace Beauty.Core.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса криптографии
    /// </summary>
    public interface ICryptographyService
    {
        /// <summary>
        /// Реализации хэш-алгоритма
        /// </summary>
        HashAlgorithm HashAlgorithm { get; }
        
        /// <summary>
        /// Возвращает зашифрованную с помощью <see cref="HashAlgorithm"/> строку
        /// </summary>
        /// <param name="value">Значение, которое необходимо зашифровать</param>
        string GetHash(string value);
    }
}

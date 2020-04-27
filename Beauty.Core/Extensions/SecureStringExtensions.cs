using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Beauty.Core.Extensions
{
    /// <summary>
    /// Класс инкапсулирующий все методы расширения для <see cref="SecureString"/>
    /// </summary>
    public static class SecureStringExtensions
    {
        /// <summary>
        /// Получает расшифрованные данные из <see cref="SecureString"/>
        /// </summary>
        /// <param name="secureString">Зашифрованная строка</param>
        public static string Unsecure(this SecureString secureString)
        {
            if (secureString is null)
            {
                return string.Empty;
            }

            var unmanagedString = IntPtr.Zero;

            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                return Marshal.PtrToStringUni(unmanagedString);
            }

            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }
}
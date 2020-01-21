using Beauty.Core.Infrastructure;
using Beauty.Core.Interfaces;
using Beauty.Data.Interfaces;
using Beauty.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beauty.Core.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ICryptographyService cryptographyService;

        public LoginService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            cryptographyService = new CryptographyService();
        }

        public async Task<IOperationDetails> LoginAsync(Worker worker, string password)
        {
            var passwordHash = cryptographyService.ToMD5Hash(password);
            var isFailed = !worker.PasswordHash.Equals(passwordHash);

            return new LoginDetails(worker, DateTime.Now, isFailed);
        }
    }
}

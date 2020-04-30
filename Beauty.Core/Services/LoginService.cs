using Beauty.Core.Infrastructure;
using Beauty.Core.Interfaces;
using Beauty.Data.Interfaces;
using System;
using System.Threading.Tasks;

namespace Beauty.Core.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ICryptographyService cryptographyService;

        public LoginService(IUnitOfWork unitOfWork, ICryptographyService cryptographyService)
        {
            this.unitOfWork = unitOfWork;
            this.cryptographyService = cryptographyService;
        }

        public async Task<bool> LoginAsync(int workerId, string password)
        {
            var session = Session.GetSession();
            var worker = await unitOfWork.Workers.FindAsync(workerId);

            if (worker is null)
            {
                return false;
            }

            var passwordHash = cryptographyService.GetHash(password);
            var isPasswordsEquals = worker.PasswordHash.Equals(passwordHash);

            if (isPasswordsEquals)
            {
                session.Worker = worker;
                session.LoginDateTime = DateTime.Now;
            }

            return isPasswordsEquals;
        }

        public void Logout()
        {
            var session = Session.GetSession();
            session.Worker = null;
        }
    }
}
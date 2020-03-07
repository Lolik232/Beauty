using Beauty.Core.Infrastructure;
using Beauty.Core.Interfaces;
using Beauty.Data.Interfaces;
using Beauty.Data.Models;
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

            var passwordHash = cryptographyService.GetHash(password);
            var isAuthorized = worker.PasswordHash.Equals(passwordHash);

            if (isAuthorized)
            {
                session.Worker = worker;
                session.LoginDateTime = DateTime.Now;
            }

            return isAuthorized;
        }

        public void Logout()
        {
            var session = Session.GetSession();
            
            if (session.Worker != null)
            {
                session.Worker = null;
                session.LogoutDateTime = DateTime.Now;
            }
        }
    }
}
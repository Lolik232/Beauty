using Beauty.Core.Interfaces;
using Beauty.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beauty.Core.Infrastructure
{
    public class Session
    {
        private static Session session;

        public static Session GetSession()
        {
            if (session is null)
            {
                session = new Session();
            }

            return session;
        }

        public Worker Worker { get; internal set; }
        public DateTime? LoginDateTime { get; internal set; }
        public DateTime? LogoutDateTime { get; internal set; }
    }
}

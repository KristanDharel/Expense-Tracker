using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADCourseWork.Models;

namespace ADCourseWork.Services
{
    public class AuthentucationStateService
    {
        private User authenticatedUser;

        public User GetAuthenticatedUser()
        {
            return authenticatedUser;
        }

        public void SetAuthenticatedUser(User user)
        {
            authenticatedUser = user;
        }

        public bool IsAuthenticated()
        {
            if (authenticatedUser != null)
            {
                return true;
            }
            return false;
        }

        public void Logout()
        {
            authenticatedUser = null;
        }
    }
}

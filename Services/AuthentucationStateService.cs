/*using System;
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

*/
/*using ADCourseWork.Models;

public class AuthentucationStateService
{
    public User CurrentUser { get; private set; }
    public bool IsAuthenticated => CurrentUser != null;

    public void SetAuthenticatedUser(User user)
    {
        CurrentUser = user;
    }

    public void Logout()
    {
        CurrentUser = null;
    }
}
*/

using ADCourseWork.Models;
using System;

public class AuthentucationStateService
{
    public User CurrentUser { get; private set; }
    public bool IsAuthenticated => CurrentUser != null;

    // Event to notify UI changes
    public event Action OnAuthStateChanged;

    public void SetAuthenticatedUser(User user)
    {
        CurrentUser = user;
        NotifyAuthenticationStateChanged();
    }

    public void Logout()
    {
        CurrentUser = null;
        NotifyAuthenticationStateChanged();
    }
    

    private void NotifyAuthenticationStateChanged()
    {
        OnAuthStateChanged?.Invoke(); // Notify subscribers
    }
}

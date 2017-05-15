using System.Security.Principal;

namespace AgeRanger.Api.Security
{
    public class ApiUserPrincipal : IPrincipal
    {

        #region Constructor

        public ApiUserPrincipal(string userName)
        {
            UserName = userName;
            Identity = new GenericIdentity(userName);
        }

        #endregion

        #region Public Members

        public string UserName { get; set; }

        public IIdentity Identity { get; set; }

        public bool IsInRole(string role)
        {
            if (role.Equals("user"))
            {
                return true;
            }
        
            return false;
        }

        #endregion  
    }
}
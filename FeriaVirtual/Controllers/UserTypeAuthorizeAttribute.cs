using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FeriaVirtual.Controllers
{
    public class UserTypeAuthorizeAttribute : System.Web.Mvc.AuthorizeAttribute
    {
        private readonly string _requiredUserType;

        public UserTypeAuthorizeAttribute(string requiredUserType)
        {
            _requiredUserType = requiredUserType;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (!base.AuthorizeCore(httpContext))
            {
                return false;
            }

            // Check user's type against the requiredUserType
            // Replace this logic with your own way of getting user type information
            string userType = httpContext.Session["Roles"].ToString();


            return userType == _requiredUserType;
        }
    }
}
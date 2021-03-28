using FrameworkWorkShop.Business.DependencyResolvers.Ninject;
using FrameworkWorkShop.Core.CrossCuttingConcerns.Security.Web;
using FrameworkWorkShop.Core.Utilities.Mvc.Infrastructer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace FrameworkWorkShop.MVCUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(new BusinessModule(),new AutoMapperModule()));
        }

        public override void Init()
        {
            PostAuthenticateRequest += MvcApplication_PostAuthenticateRequest;
            base.Init();
        }

        private void MvcApplication_PostAuthenticateRequest(object sender, EventArgs e)
        {
            try
            {
                var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                if (authCookie == null)
                {
                    return;
                }

                var encrTicket = authCookie.Value;
                if (string.IsNullOrEmpty(encrTicket))
                {
                    return;
                }

                var ticket = FormsAuthentication.Decrypt(encrTicket);

                var securityUtilities = new SecurityUtilities();
                var identity = securityUtilities.FormsAuthTicketToIdentity(ticket);
                var principle = new GenericPrincipal(identity, identity.Roles);

                HttpContext.Current.User = principle;
                Thread.CurrentPrincipal = principle;
            }
            catch (Exception)
            {

            }
           
        }
    }
}

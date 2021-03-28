using FrameworkWorkShop.Business.Abstract;
using FrameworkWorkShop.Business.DependencyResolvers.Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace FrameworkWorkShop.WebAPI.MessageHandlers
{
    public class AuthenticationHandler : DelegatingHandler
    {

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                var token = request.Headers.GetValues("Authorization").FirstOrDefault();
                if (token != null)
                {
                    byte[] data = Convert.FromBase64String(token);
                    string decodedStr = Encoding.UTF8.GetString(data);
                    string[] tokenValues = decodedStr.Split(':');

                    IUserService userService = InstanceFactory.GetInstance<IUserService>();


                    var user = userService.GetByUserNameAndPassword(tokenValues[0], tokenValues[1]);
                    if (user != null)
                    {
                        IPrincipal principal = new GenericPrincipal(new GenericIdentity(tokenValues[0]), userService.GetUserRoles(user).Select(t=> t.RoleName).ToArray());
                        Thread.CurrentPrincipal = principal;
                        HttpContext.Current.User = principal;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return base.SendAsync(request, cancellationToken);
        }
    }
}
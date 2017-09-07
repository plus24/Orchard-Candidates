using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Orchard.Candidate.Net.Filters
{
    public class TokenAuthorizeFilter : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            #region CheckToken
            var Token = HttpContext.Current.Request.Headers["token"];
            int id;
            int.TryParse(actionContext.ControllerContext.RouteData.Values["id"].ToString(), out id);
            string TokenString;
            try
            {
                var EncodedToken = System.Convert.FromBase64String(Token);
                TokenString = Encoding.UTF8.GetString(EncodedToken);
            }
            catch
            {
                actionContext.Response = new HttpResponseMessage
                {
                    Content = new StringContent("Unauthorized"),
                    StatusCode = HttpStatusCode.Unauthorized
                };
                return;
            }
            if (!(TokenString == "OrchardApiKey" && id == 1))//TODO for next iterations Id must c
            {
                actionContext.Response = new HttpResponseMessage
                {
                    Content= new StringContent("Unauthorized"),
                    StatusCode=HttpStatusCode.Unauthorized
                };
                return;
            }
            #endregion
            base.OnAuthorization(actionContext);
        }

    }
}
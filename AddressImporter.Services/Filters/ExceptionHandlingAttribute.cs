using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace AddressImporter.Services.Filters
{
    public class ExceptionHandlingAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            //A logging framework should be injected in this class, Log4Net, Enterprise Library.. 
            //Due to time constraints it was not possible for me to integrate, i'm just hidding the errors to the client applications
            context.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent("Sorry, An Error has occurred.."),
                ReasonPhrase = "Sorry, An Error has occurred.."
            };
        }
    }
}
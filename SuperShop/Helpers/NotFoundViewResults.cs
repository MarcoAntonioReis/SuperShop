using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace SuperShop.Helpers
{
    public class NotFoundViewResults:ViewResult
    {
        public NotFoundViewResults(string viewName)
        {
            ViewName = viewName;
            StatusCode=(int)HttpStatusCode.NotFound;
        }
    }
}

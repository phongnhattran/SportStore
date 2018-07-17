using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfiguringApps.Infrastructure
{
    public class ResponseEditingMiddleware
    {
        private RequestDelegate nextDelegate;
        public ResponseEditingMiddleware(RequestDelegate requestDelegate) => nextDelegate = requestDelegate;
        public async Task Invoke(HttpContext httpContext)
        {
            await nextDelegate.Invoke(httpContext);
            if (httpContext.Response.StatusCode == 403)
            {
                await httpContext.Response.WriteAsync("We do not support Edge", Encoding.UTF8);
            }
            else if (httpContext.Response.StatusCode == 404)
            {
                await httpContext.Response.WriteAsync("No content middleware response", Encoding.UTF8);

            }


        }
    }
}

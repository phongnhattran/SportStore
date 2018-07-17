using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfiguringApps.Infrastructure
{
    public class BrowserTypeMiddleware
    {
        private RequestDelegate nextDelegate;
        public BrowserTypeMiddleware(RequestDelegate requestDelegate) => nextDelegate = requestDelegate;
        public async Task Invoke(HttpContext httpContext)
        {
            httpContext.Items["EdgeBrowser"] = httpContext.Request.Headers["User-Agent"].Any(x => x.ToLower().Contains("edge"));
            await nextDelegate.Invoke(httpContext);

        }
    }
}

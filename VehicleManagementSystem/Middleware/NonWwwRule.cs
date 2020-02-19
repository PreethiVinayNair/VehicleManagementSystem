using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Net.Http.Headers;

namespace VMS.Middleware
{
    public class NonWwwRule : IRule
    {
        public readonly int _statusCode;

        public NonWwwRule(int statusCode)
        {
            _statusCode = statusCode;
        }

        public virtual void ApplyRule(RewriteContext context)
        {
            var req = context.HttpContext.Request;
            if (req.Host.Host.Equals("localhost", StringComparison.OrdinalIgnoreCase))
            {
                context.Result = RuleResult.ContinueRules;
                return;
            }

            if (req.Host.Value.StartsWith("www.", StringComparison.OrdinalIgnoreCase))
            {
                var host = new HostString($"{req.Host.Value.Substring(4)}");
                var newUrl = UriHelper.BuildAbsolute(req.Scheme, host, req.PathBase, req.Path, req.QueryString);
                var response = context.HttpContext.Response;
                response.StatusCode = _statusCode;
                response.Headers[HeaderNames.Location] = newUrl;
                context.Result = RuleResult.EndResponse;
            }
            else
            {
                context.Result = RuleResult.ContinueRules;
                return;
            }     
        }
    }
}

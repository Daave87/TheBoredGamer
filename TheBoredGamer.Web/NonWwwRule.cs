using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite;

namespace TheBoredGamer.Web
{
    public class NonWwwRule : IRule
    {
        public void ApplyRule(RewriteContext context)
        {
            var request = context.HttpContext.Request;
            var currentHost = request.Host;
            if (!currentHost.Host.StartsWith("www."))
            {
                return;
            }

            var newHost = new HostString(currentHost.Host.Substring(4));
            var newUrl = new StringBuilder().Append("https://").Append(newHost).Append(request.PathBase).Append(request.Path).Append(request.QueryString);
            context.HttpContext.Response.Redirect(newUrl.ToString(), true);
            context.Result = RuleResult.EndResponse;
        }
    }
}

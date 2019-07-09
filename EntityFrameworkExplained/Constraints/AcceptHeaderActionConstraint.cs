using Microsoft.AspNetCore.Mvc.ActionConstraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkExplained.Constraints
{
    public class AcceptHeaderActionConstraint : IActionConstraint
    {
        readonly string headerValue;

        public AcceptHeaderActionConstraint(string headerValue)
        {
            this.headerValue = headerValue;
        }

        public int Order => 0;

        public bool Accept(ActionConstraintContext context)
        {
            var headerVal = context.RouteContext.HttpContext.Request.Headers["Accept"];
            return headerVal.Contains(this.headerValue);
        }
    }
}

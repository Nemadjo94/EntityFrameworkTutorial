using Microsoft.AspNetCore.Mvc.ActionConstraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkExplained.Constraints
{
    public class AcceptHeaderAttribute : Attribute, IActionConstraintFactory
    {

        readonly string value;

        public AcceptHeaderAttribute(string value)
        => this.value = value;
        


        public bool IsReusable => true;

        public IActionConstraint CreateInstance(IServiceProvider services)
        {
            return new AcceptHeaderActionConstraint(this.value);
        }
    }
}

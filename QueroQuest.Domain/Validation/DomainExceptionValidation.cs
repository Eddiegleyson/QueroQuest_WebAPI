using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QueroQuest.Domain.Validation
{
    public class DomainExceptionValidation : Exception
    {
        public DomainExceptionValidation(string error) : base(error)
        { }
    }
}
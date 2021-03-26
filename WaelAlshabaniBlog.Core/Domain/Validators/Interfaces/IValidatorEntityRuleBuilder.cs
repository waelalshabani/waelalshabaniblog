using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaelAlshabaniBlog.Core.Domain.Validators.Interfaces
{
    internal interface IValidatorEntityRuleBuilder<T>
    {
       T BuildEntityRule();
    }
}

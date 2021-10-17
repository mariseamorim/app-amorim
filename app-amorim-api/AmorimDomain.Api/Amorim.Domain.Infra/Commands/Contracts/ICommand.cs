using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amorim.Domain.Commands.Contracts
{
    public interface ICommand : IValidatable
    {

    }

    public interface IValidatable
    {
        void Validate();
    }
}

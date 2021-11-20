using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VA.Application.UseCase.Queries.BuscarCidade
{
    public class BuscarCidadeValidator : AbstractValidator<BuscarCidadeQuery>
    {
        public BuscarCidadeValidator()
        {
            RuleFor(c => c.IdEstado).GreaterThan(0);
            RuleFor(c => c.IdCidade).GreaterThan(0);
        }
    }
}

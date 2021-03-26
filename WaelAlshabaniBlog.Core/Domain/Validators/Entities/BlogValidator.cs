using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using WaelAlshabaniBlog.Core.Domain;
using WaelAlshabaniBlog.Core.Domain.Validators.Interfaces;

namespace WaelAlshabaniBlog.DataUnitTests.DomainEntityValidator
{
    public class BlogValidator : AbstractValidator<BlogEntity>, IValidatorEntityRuleBuilder<BlogValidator>
    {
        private readonly int _titleMinimumLength;
        private readonly int _bodyMinimumLength;
        public BlogValidator(int titleMinimumLength, int bodyMinimumLength)
        {
            _titleMinimumLength = titleMinimumLength;
            _bodyMinimumLength = bodyMinimumLength;
        }

        public BlogValidator BuildEntityRule()
        {
            RuleSet("Required", () =>
            {
                RuleFor(blog => blog.Title).NotNull()
                                           .NotEmpty()
                                           .MinimumLength(_titleMinimumLength);

                RuleFor(blog => blog.Body).NotNull()
                                          .NotEmpty()
                                          .MinimumLength(_bodyMinimumLength);
            });




            return this;
        }
    }
}

using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ValidationRules
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x=>x.CategoryName).NotEmpty().WithMessage("Category Name can't be empty!");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Category Description can't be empty!");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage(" Category Name's min length can be 3!");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage(" Category Name's max length can be 20!");
        }
    }
}

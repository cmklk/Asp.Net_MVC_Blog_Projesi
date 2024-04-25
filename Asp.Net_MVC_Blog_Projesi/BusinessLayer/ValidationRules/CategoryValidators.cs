using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidators : AbstractValidator<Category>
    {
        public CategoryValidators()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("KATEGORİ ADI BOŞ GEÇİLEMEZ.");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("KATEGORİ AÇIKLAMASI BOŞ GEÇİLEMEZ.");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("KATEGORİ ADI 3 KARAKTERDEN AZ OLAMAZ.");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("KATEGORİ ADI 20 KARAKTERDEN FAZLA OLAMAZ.");
            RuleFor(x => x.CategoryDescription).MinimumLength(5).WithMessage("KATEGORİ AÇIKLAMASI 5 KARAKTERDEN AZ OLAMAZ.");
            RuleFor(x => x.CategoryDescription).MaximumLength(100).WithMessage("KATEGORİ AÇIKLAMASI 100 KARAKTERDEN FAZLA OLAMAZ.");
        }
    }
}

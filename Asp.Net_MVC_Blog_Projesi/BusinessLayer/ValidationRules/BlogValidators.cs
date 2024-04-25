using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidators : AbstractValidator<Blog>
    {
        public BlogValidators()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("BLOG ADI BOŞ GEÇİLEMEZ.");
            RuleFor(x => x.BlogTitle).MinimumLength(5).WithMessage("BLOG ADI 5 KARAKTERDEN AZ OLAMAZ.");
            RuleFor(x => x.BlogTitle).MaximumLength(100).WithMessage("BLOG ADI 100 KARAKTERDEN FAZLA OLAMAZ.");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("BLOG RESMİ BOŞ GEÇİLEMEZ.");
            RuleFor(x => x.BlogDate).NotEmpty().WithMessage("BLOG TARİHİ BOŞ GEÇİLEMEZ.");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("BLOG İÇERİĞİ BOŞ GEÇİLEMEZ.");
            RuleFor(x => x.BlogContent).MinimumLength(10).WithMessage("BLOG AÇIKLAMASI 10 KARAKTERDEN FAZLA OLAMAZ.");
            RuleFor(x => x.BlogTitle).MaximumLength(100).WithMessage("BLOG AÇIKLAMASI 100 KARAKTERDEN FAZLA OLAMAZ.");
            RuleFor(x => x.BlogRating).NotEmpty().WithMessage("BLOG PUANLAMA BOŞ GEÇİLEMEZ.");
        }
    }
}

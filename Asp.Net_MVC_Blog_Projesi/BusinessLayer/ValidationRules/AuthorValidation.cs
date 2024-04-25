using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AuthorValidation : AbstractValidator<Author>
    {
        public AuthorValidation()
        {
            RuleFor(x => x.AuthorName).NotEmpty().WithMessage("Yazar Adı Boş Geçilemez.");
            RuleFor(x => x.AuthorName).MinimumLength(3).WithMessage("3 Karakterden az ad girmeyin !!!!.");
            RuleFor(x => x.AuthorName).MaximumLength(20).WithMessage("20 Karakterden fazla ad giremezsiniz !!!!.");
            RuleFor(x => x.AboutTitle).NotEmpty().WithMessage("Yazar başlığı boş geçilemez.");
            RuleFor(x => x.AboutShort).NotEmpty().WithMessage("Bu alanı boş geçilemez.");
            RuleFor(x => x.AhuthotAbout).NotEmpty().WithMessage("Bu alan boş geçilemez.");
            RuleFor(x => x.AuthorImage).NotEmpty().WithMessage("Bu alan boş geçilemez.");
            RuleFor(x => x.AuthorPassword).NotEmpty().WithMessage("Şifre alanı boş geçilemez.");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail alanı boş geçilemez.");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Telefon numarası boş geçilemez.");
        }
    }
}

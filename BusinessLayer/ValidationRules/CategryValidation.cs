using Entitylayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public class CategryValidation : AbstractValidator<Category>
    {
        public CategryValidation()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Açıklamayı boş geçemezsiniz");
            RuleFor(X => X.CategoryName).MinimumLength(3).WithMessage("En az 3 Karakter girilmeli");
            RuleFor(X => X.CategoryName).MaximumLength(50).WithMessage("Lütfen 50 karakterden fazla giriş yapmayınız");
        }
    }
}

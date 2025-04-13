using DiziFilm.Model.ViewModel.Areas.AdminPanel;
using FluentValidation;
using FluentValidation.AspNetCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiziFilm.Business.ValidationRules.Areas.AdminPanel
{
    public class LoginVmValidator:AbstractValidator<LoginVm>
    {
        public LoginVmValidator()
        {
            RuleFor(x=>x.Email).NotNull().WithMessage("Lütfen E-postanızı Giriniz").NotEmpty().
                WithMessage("Lütfen E-postanızı Giriniz").MinimumLength(8).WithMessage("Lütfen en az 8 karakter giriniz");

            RuleFor(x=>x.Sifre).NotNull().WithMessage("Lütfen Şifre Giriniz").NotEmpty().
                WithMessage("Lütfen Şifre Giriniz").MinimumLength(8).WithMessage("Lütfen en az 8 karakter giriniz");

            
        }
    }
}

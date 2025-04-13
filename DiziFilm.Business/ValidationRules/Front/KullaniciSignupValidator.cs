using DiziFilm.Business.Abstract;
using DiziFilm.Model.Entity;
using DiziFilm.Model.ViewModel.Front;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiziFilm.Business.ValidationRules.Front
{
    public class KullaniciSignupValidator:AbstractValidator<KullaniciSignUpVm>
    {
        IKullanicilarBs _kullaniciBs;
        public KullaniciSignupValidator(IKullanicilarBs kullaniciBs)
        {
            _kullaniciBs = kullaniciBs;


            RuleFor(x => x.Adi).NotNull().WithMessage("Lütfen Boş Bırakmayın").NotEmpty().WithMessage("Lütfen Boş Bırakmayın");

            RuleFor(x => x.Soyadi).NotNull().WithMessage("Lütfen Boş Bırakmayın").NotEmpty().WithMessage("Lütfen Boş Bırakmayın");

            RuleFor(x => x.Email).NotNull().WithMessage("Boş Geçilmez").NotEmpty().WithMessage("Boş Geçilmez").Must(KullaniliyorMu).WithMessage("Bu Email Kullanılıyor").EmailAddress().WithMessage("Lütfen Geçerli Bir Email Giriniz.");

            RuleFor(x => x.Sifre).NotNull().WithMessage("Lütfen Boş bırakmayın").NotEmpty().WithMessage("Boş Geçilmez").Matches("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$").WithMessage("Lütfen  en az 8 karekter, En az bir rakam,Bir Büyük Harf  ve bir özel karakter giriniz. ");

            RuleFor(x => x.SifreTekrar).NotNull().WithMessage("Boş Geçilmez").NotEmpty().WithMessage("Boş Geçilmez").Equal(x => x.Sifre).WithMessage("Şifreler Eşleşmiyor");

           
        }
        public bool SecildiMi(int arg)
        {
            if (arg == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool KullaniliyorMu(string arg) 
        { 
            Kullanicilar k=_kullaniciBs.Get(x=>x.Email==arg);
            if (k != null)
            {
                // bu mail kullanılıyordur

                return false;
            }
            else
            {
                // email yok kayıt olabilirsin
                return true;
            }

        }



    }
}

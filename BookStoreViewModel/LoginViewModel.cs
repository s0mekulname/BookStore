using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using IkitMita;
using IkitMita.Mvvm.ViewModels;
using System.ComponentModel.Composition;
namespace BookStoreViewModel
{
    [Export]
    public class LoginViewModel : ChildViewModelBase
        
    {
        
        private string _login;
        private string _password;

        public LoginViewModel()
        {
            Title = "Авторизация";
        }
        public string Login {
            get { return _login; }
            set
            {
                _login = value;
                OnPropertyChanged();
            } 
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value; 
                OnPropertyChanged();
            }
        }

        public string Message
        {
            get { return _message; }
            set
            {
                _message = value; 
                OnPropertyChanged();
            }
        }


        //[DependsOn(nameof(Login))]
        //
        private DelegateCommand _makeLoginCommand;
        private string _message;

        [DependsOn(nameof(Login))]
        [DependsOn(nameof(Password))]

        public DelegateCommand MakeLoginCommand => _makeLoginCommand ??
                                                   (_makeLoginCommand = new DelegateCommand(MakeLogin, () => !Login.IsNullOrEmpty() && !Password
                                                   .IsNullOrEmpty()));

        private void MakeLogin()
        {
            if (Login == Password)
            {
                Message = "Вы вошли";
            }
            else
            {
                Message = "Неверный логин или пароль";

            }
        }
    }
}

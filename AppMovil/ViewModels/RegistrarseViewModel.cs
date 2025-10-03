using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth.Providers;
using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Service.Services;
using Service.Models;
using Service.Enums;

namespace AppMovil.ViewModels
{
    public partial class RegistrarseViewModel : ObservableObject
    {
        AuthService _authService = new ();
        UsuarioService _usuarioService = new ();
        public IRelayCommand RegistrarseCommand { get; }
        public IRelayCommand VolverCommand { get; }


        [ObservableProperty]
        private string nombre;

        [ObservableProperty]
        private string mail;

        [ObservableProperty]
        private string password;

        [ObservableProperty]
        private string verifyPassword;

        [ObservableProperty]
        private bool isBusy;

        public RegistrarseViewModel()
        {
            RegistrarseCommand = new RelayCommand(Registrarse);
            VolverCommand = new AsyncRelayCommand(OnVolver);

        }
        private async Task OnVolver()
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
        private async void Registrarse()
        {
            if (IsBusy) return;
            IsBusy = true;
            if (password != verifyPassword)
            {
                await Application.Current.MainPage.DisplayAlert("Registrarse", "Las contraseñas ingresadas no coinciden", "Ok");
                return;
            }
            

            try
            {
                var user = await _authService.CreateUserWithEmailAndPasswordAsync(Mail, Password, Nombre);
                
                if (user == false)
                {
                    await Application.Current.MainPage.DisplayAlert("Registrarse", "No se pudo crear la cuenta. Intente nuevamente.", "Ok");
                }
                else
                {
                    var newUser = new Usuario { Nombre = Nombre, Email = Mail, TipoRol = TipoRolEnum.Alumno, Dni = "1234567", Password = Password };
                    await _usuarioService.AddAsync(newUser);
                    await Application.Current.MainPage.DisplayAlert("Registrarse", "Cuenta creada!", "Ok");
                    await Shell.Current.GoToAsync("//LoginPage");

                }
                   
            }
            catch (FirebaseAuthException error) // Use alias here 
            {
                await Application.Current.MainPage.DisplayAlert("Registrarse", "Ocurrió un problema:" + error.Reason, "Ok");

            }
            finally
            {
                IsBusy = false;
            }

        }
    }
}

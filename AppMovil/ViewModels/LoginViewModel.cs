using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using Service.Interfaces;
using Service.Models;
using Service.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace AppMovil.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        AuthService _authService;
        private UsuarioService? _usuarioService; // Declarado aquí

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
        private string username = string.Empty;
        
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
        private string password = string.Empty;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
        private bool _isBusy;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
        private string _errorMessage = string.Empty;


        public IRelayCommand LoginCommand { get; }

        public LoginViewModel()
        {
            _authService = new AuthService();
            _usuarioService = new UsuarioService();
            LoginCommand = new RelayCommand(OnLogin, CanLogin);
        }

        private bool CanLogin()
        {
            return !IsBusy && 
                   !string.IsNullOrWhiteSpace(Username) && 
                   !string.IsNullOrWhiteSpace(Password);
        }

        private async void OnLogin()
        {
            if (IsBusy) return;

            try
            {
                IsBusy = true;
                ErrorMessage = string.Empty;

                var token = await _authService.Login(new Login
                {
                    Username = this.Username,
                    Password = this.Password
                });


                if(string.IsNullOrEmpty(token))
                {
                    ErrorMessage = "Usuario o contraseña incorrectos.";
                    return;
                }

                Console.WriteLine($"ESTE ES EL TOKEN: {token}");

                //token = token.Trim().Trim('"');

                // Asignar token global antes de crear servicios genéricos
                GenericService<object>.jwtToken = token;

                // Instanciar ahora el servicio (el ctor base ya configurará Authorization)
                //_usuarioService = new UsuarioService();

                var usuario = await _usuarioService.GetByEmailAsync(Username);
                if (usuario == null)
                { 
                    ErrorMessage ="No se pudo obtener la información del usuario.";
                    return;
                }

                // PERMITE CUALQUIER USUARIO/CONTRASEÑA durante desarrollo
                // Solo requiere que no estén vacíos
                if (Application.Current?.MainPage is AppShell shell)
                {
                    shell.SetLoginState(true);
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Error al iniciar sesión: {ex.Message}";
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}

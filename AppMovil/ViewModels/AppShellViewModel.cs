using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;

namespace AppMovil.ViewModels
{
    public partial class AppShellViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool isLoggedIn;
        [ObservableProperty]
        private bool loginVisible = true;
        [ObservableProperty]
        private bool menuVisible = false;

        partial void OnIsLoggedInChanged(bool value)
        {
            LoginVisible = !value;
            MenuVisible = value;
        }

        public IRelayCommand LogoutCommand { get; }

        public AppShellViewModel()
        {
            LogoutCommand = new RelayCommand(OnLogout);
        }

        public void SetLoginState(bool isLoggedIn)
        {
            IsLoggedIn = isLoggedIn;
            if (isLoggedIn)
                Shell.Current.GoToAsync("//MainPage");  // Cambio a MainPage (pantalla de inicio)
            else
                Shell.Current.GoToAsync("//LoginPage");
        }

        private void OnLogout()
        {
            SetLoginState(false);
        }
    }
}
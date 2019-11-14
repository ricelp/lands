
namespace Lands
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Services;
    using Xamarin.Forms;
    using ViewModels;
    using Views;

    public class LoginViewModel : BaseViewModel
    {
        #region Services
        private ApiService apiService;
        #endregion

        #region Attributes
        private string email;
        private string password;
        private bool isRunning;
        private bool isEnabled;
        private bool isRemembered;

        #endregion
        #region properties
        public string Email
        {
            get { return this.email; }
            set { SetValue(ref this.email, value); }
        }

        public string Password
        {
            get { return this.password; }
            set { SetValue(ref this.password, value); }
        }

        public bool IsRemembered
        {
            get { return this.isRemembered; }
            set { SetValue(ref this.isRemembered, value); }
        }

        public bool IsRunning
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }

        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }

        #endregion

        #region Contructors
        public LoginViewModel()
        {
            this.apiService = new ApiService();

            this.IsRemembered = true;
            this.IsEnabled = true;


        }
        #endregion
        #region Commands
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }



        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter Email",
                    "Accept");
                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter a password",
                    "Accept");
                return;
            }

            this.IsRunning = true;
            this.IsEnabled = false;

            //var connection = await this.apiService.CheckConnection();

            //if (!connection.IsSuccess)
            //{
            //    this.IsRunning = false;
            //    this.IsEnabled = true;

            //    await Application.Current.MainPage.DisplayAlert(
            //         "Error",
            //         connection.Message,
            //         "Accept");
            //    return;
            //}

            //var token = await this.apiService.GetToken(
            //    "http://200.46.9.156:81",
            //    this.Email,
            //    this.Password);

            ////if (token == null)
            ////{
            ////    this.IsRunning = false;
            ////    this.IsEnabled = true;

            ////    await Application.Current.MainPage.DisplayAlert(
            ////         "Error",
            ////         "Something was wrong, please try later",
            ////         "Accept");
            ////    return;
            ////}

            //if (string.IsNullOrEmpty(token.AccessToken))
            //{
            //    this.IsRunning = false;
            //    this.IsEnabled = true;

            //    await Application.Current.MainPage.DisplayAlert(
            //         "Error",
            //         token.ErrorDescription,
            //         "Accept");
            //    this.Password = string.Empty;
            //    return;
            //}

            if (this.Email != "Ricelp@hotmail.com" || this.Password != "1234")
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                   "Error",
                   "Email or password incorrect.",
                   "Accept");
                this.Password = string.Empty;
                return;
            }

            //mainViewModel.Token = token;


            //mainViewModel.Empleados = new EmpleadosViewModel();

            //await Application.Current.MainPage.Navigation.PushAsync(new EmpleadosPage());

            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.Lands = new LandsViewModel();
            //mainViewModel.Token = token;
            await Application.Current.MainPage.Navigation.PushAsync(new LandsPage());
            this.IsRunning = false;
            this.IsEnabled = true;

            this.Email = string.Empty;
            this.Password = string.Empty;
        }

        #endregion
    }
}

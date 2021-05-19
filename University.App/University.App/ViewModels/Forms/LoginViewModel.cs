using System;
using System.Collections.Generic;
using System.Text;
using University.App.Views.Forms;
using University.App.Views.Menu;
using University.BL.DTOs;
using University.BL.Services.Implements;
using Xamarin.Forms;

namespace University.App.ViewModels.Forms
{
    public class LoginViewModel : BaseViewModel
    {
        #region Attributes
        private string _email;
        private string _password;
        private bool _isEmailValid;
        private bool _isEnabled;
        private bool _isRunning;
        private ApiService _apiService;
        #endregion

        #region Properties
        public string Email 
        { 
            get { return this._email; }
            set { this.SetValue(ref this._email, value); }
        }
        public string Password
        {
            get { return this._password; }
            set { this.SetValue(ref this._password, value); }
        }
        public bool IsEmailValid
        {
            get { return this._isEmailValid; }
            set { this.SetValue(ref this._isEmailValid, value); }
        }
        public bool IsEnabled
        {
            get { return this._isEnabled; }
            set { this.SetValue(ref this._isEnabled, value); }
        }
        public bool IsRunning
        {
            get { return this._isRunning; }
            set { this.SetValue(ref this._isRunning, value); }
        }
        #endregion

        #region Commands
        //Eventos
        public Command LoginCommand { get; set; }
        public Command RegisterCommand { get; set; }
        #endregion

        #region Methods
        async void Login() {
            try
            {
                this.IsRunning = true;
                this.IsEnabled = false;
                if (!await _apiService.CheckConnection())
                {
                    this.IsRunning = false;
                    this.IsEnabled = true;
                    await Application.Current.MainPage.DisplayAlert("Notification", "No internet connection", "Accept");
                    return;
                }

                if (string.IsNullOrEmpty(this.Email) || string.IsNullOrEmpty(this.Password)) 
                {
                    this.IsRunning = false;
                    this.IsEnabled = true;
                    await Application.Current.MainPage.DisplayAlert("Notification", "The fields are required", "Accept");
                    return;
                }

                var loginDTO = new LoginDTO
                {
                    Email = this.Email,
                    Password = this.Password
                };

                var responseDTO = await _apiService.RequestAPI<UserDTO>(Helpers.Endpoints.URL_BASE_UNIVERSITY_AUTH,
                    Helpers.Endpoints.LOGIN,
                    loginDTO,
                    ApiService.Method.Post,
                    true);

                if (responseDTO.Code == 200)
                {
                    var user = (UserDTO)responseDTO.Data;
                    Helpers.Settings.UserID = user.Id;
                    Application.Current.MainPage = new MasterPage();
                }
                else
                    await Application.Current.MainPage.DisplayAlert("Notification", responseDTO.Message, "Accept");

                this.IsRunning = false;
                this.IsEnabled = true;
            }
            catch (Exception ex)
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert("Notification", ex.Message, "Accept");
            }
        }
        async void Register()
        {
            this.IsRunning = true;
            this.IsEnabled = false;
            if (!await _apiService.CheckConnection())
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert("Notification", "No internet connection", "Accept");
                return;
            }
            Application.Current.MainPage = new RegisterPage();
            this.IsRunning = false;
            this.IsEnabled = true;
        }
        #endregion

        #region Constructor
        public LoginViewModel()
        {
            this.IsEmailValid = this.IsEnabled = true;
            this.IsRunning = false;

            this.LoginCommand = new Command(Login);
            this.RegisterCommand = new Command(Register);
            this._apiService = new ApiService();
        }
        #endregion
    }
}

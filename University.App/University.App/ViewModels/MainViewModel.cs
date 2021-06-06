﻿using System.Collections.ObjectModel;
using System.Threading.Tasks;
using University.App.ViewModels.Forms;
using University.App.ViewModels.Menu;
using Xamarin.Forms;

namespace University.App.ViewModels
{
    public class MainViewModel
    {        
        public LoginViewModel Login { get; set; }    
        public RegisterViewModel Register { get; set; }    
        public ProfileViewModel Profile { get; set; }    
        public AboutViewModel About { get; set; }    
        public PQRSViewModel PQRS { get; set; }    
        public ChangePasswordViewModelh ChangePassword { get; set; }    
        public ObservableCollection<MenuItemViewModel> Menu { get; set; }

        #region Constructors
        public MainViewModel()
        {
            instance = this;
            this.LoadMenu();

            this.Login = new LoginViewModel();
            this.Register = new RegisterViewModel();
            this.ChangePassword = new ChangePasswordViewModelh();
        }
        #endregion

        #region Methods
        private void LoadMenu()
        {
            this.Menu = new ObservableCollection<MenuItemViewModel>
            {                
                new MenuItemViewModel
                {
                    Icon = "ic_exit_to_app",
                    PageName = "LoginPage",
                    Title = "Log out"
                },
                new MenuItemViewModel
                {
                    Icon = "ic_exit_to_app",
                    PageName = "AboutPage",
                    Title = "About"
                },
                new MenuItemViewModel
                {
                    Icon = "ic_exit_to_app",
                    PageName = "PQRSPage",
                    Title = "PQRS"
                },
                new MenuItemViewModel
                {
                    Icon = "ic_exit_to_app",
                    PageName = "ProfilePage",
                    Title = "Profile"
                },
                new MenuItemViewModel
                {
                    Icon = "ic_exit_to_app",
                    PageName = "ChangePasswordPage",
                    Title = "Change password"
                }
            };
        }
        #endregion

        #region Singleton
        private static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
                return new MainViewModel();

            return instance;
        }
        #endregion
    }
}

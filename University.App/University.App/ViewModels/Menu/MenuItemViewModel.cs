using System.Threading.Tasks;
using Xamarin.Forms;
using University.App.ViewModels.Forms;
using University.App.Views.Forms;

namespace University.App.ViewModels.Menu
{
    public class MenuItemViewModel
    {
        #region Properties
        public string Icon { get; set; }
        public string Title { get; set; }
        public string PageName { get; set; }
        #endregion

        #region Constructors
        public MenuItemViewModel()
        {
            this.GoToCommand = new Command(GoTo);
        }
        #endregion

        #region Commands
        public Command GoToCommand { get; set; }
        #endregion

        #region Methods
        async void GoTo()
        {
            await App.Navigator.PopToRootAsync();

            if (this.PageName.Equals("LoginPage"))
            {
                MainViewModel.GetInstance().Login = new LoginViewModel();
                Application.Current.MainPage = new NavigationPage(new LoginPage());
            }
            else if (this.PageName.Equals("CoursesPage"))
            {
				//MainViewModel.GetInstance().Courses = new CoursesViewModel();
                //await App.Navigator.PushAsync(new Views.Forms.CoursesPage());             
            }
        }
        #endregion
    }
}

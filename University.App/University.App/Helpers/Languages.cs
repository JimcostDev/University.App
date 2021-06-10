        using University.App.Interfaces;
using University.App.Resources;
using Xamarin.Forms;

namespace University.App.Helpers
{
    public static class Languages
    {
        static Languages()
        {
            var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
            Resource.Culture = ci;
            DependencyService.Get<ILocalize>().SetLocale(ci);
        }

        public static string Accept { get { return Resource.Accept; } }
        public static string Notification { get { return Resource.Notification; } }
        public static string NoInternetConnection { get { return Resource.NoInternetConnection; } }
        public static string FieldsRequired { get { return Resource.FieldsRequired; } }
        public static string RegisterSuccessfull { get { return Resource.RegisterSuccessfull; } }
        public static string ChangePasswordSuccessfully { get { return Resource.ChangePasswordSuccessfully; } }
        public static string LogOut { get { return Resource.LogOut; } }
        public static string AboutUs { get { return Resource.AboutUs; } }
        public static string Profile { get { return Resource.Profile; } }
        public static string ChangePassword { get { return Resource.ChangePassword; } }
        public static string ProcessSuccessfull { get { return Resource.ProcessSuccessfull; } }
        public static string Petition { get { return Resource.Petition; } }
        public static string Complain { get { return Resource.Complain; } }
        public static string Claim { get { return Resource.Claim; } }
        public static string Suggestion { get { return Resource.Suggestion; } }
        public static string Bad { get { return Resource.Bad; } }
        public static string Regular { get { return Resource.Regular; } }
        public static string Well { get { return Resource.Well; } }
        public static string Acceptable { get { return Resource.Acceptable; } }
        public static string Excellent { get { return Resource.Excellent; } }
    }
}

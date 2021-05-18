using System;
using System.Collections.Generic;
using System.Text;

namespace University.App.Helpers
{
    public class Endpoints
    {
        public static string URL_BASE_UNIVERSITY_AUTH { get; set; } = "http://university-auth.azurewebsites.net/";
        public static string LOGIN { get; set; } = "api/AccountApp/Login/";
        public static string REGISTER { get; set; } = "api/AccountApp/Register/";
    }
}

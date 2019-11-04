using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WebApp.Admin.Security
{
    // A collection of application-wide settings that provide values for secruity roles which have been set in the web.config
    internal static class Settings
    {
        #region
        public static string AdminRole => ConfigurationManager.AppSettings
            ["adminRole"];

        public static string UserRole => ConfigurationManager.AppSettings
            ["userRole"];
        public static IEnumerable<string> DefaultSecurityRoles =>
            new List<string> { AdminRole, UserRole };

        #endregion

        #region
        public static string AdminUserName => ConfigurationManager.AppSettings["adminUserName"];
        public static string AdminPassword => ConfigurationManager.AppSettings["adminPassword"];
        public static string AdminEmail => ConfigurationManager.AppSettings["adminEmail"];
        public static string TempPassword => ConfigurationManager.AppSettings["temporaryUserPassword"];
        #endregion

    }



}
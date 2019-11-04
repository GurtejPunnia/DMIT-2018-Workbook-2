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
        public static string AdminRole => ConfigurationManager.AppSettings
            ["adminRole"];

        public static string UserRole => ConfigurationManager.AppSettings
            ["userRole"];
        public static IEnumerable<string> DefaultSecurityRoles =>
            new List<string> { AdminRole, UserRole };
    }



}
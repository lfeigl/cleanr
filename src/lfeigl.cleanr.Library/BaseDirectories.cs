using System;
using System.IO;

namespace lfeigl.cleanr.Library
{
    public static class BaseDirectories
    {
        public static string SystemDrive = Path.GetPathRoot(Environment.ExpandEnvironmentVariables("%SYSTEMROOT%"));
        public static string UserProfile = Environment.ExpandEnvironmentVariables("%USERPROFILE%") + @"\";
    }
}

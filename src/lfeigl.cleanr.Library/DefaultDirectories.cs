namespace lfeigl.cleanr.Library
{
    public static class DefaultDirectories
    {
        public static string ProgramData                = BaseDirectories.SystemDrive + @"ProgramData";
        public static string ProgramFiles               = BaseDirectories.SystemDrive + @"Program Files";
        public static string ProgramFilesCommonFiles    = BaseDirectories.SystemDrive + @"Program Files\Common Files";
        public static string ProgramFilesX86            = BaseDirectories.SystemDrive + @"Program Files (x86)";
        public static string ProgramFilesX86CommonFiles = BaseDirectories.SystemDrive + @"Program Files (x86)\Common Files";
        public static string AppDataLocal               = BaseDirectories.UserProfile + @"AppData\Local";
        public static string AppDataLocalLow            = BaseDirectories.UserProfile + @"AppData\LocalLow";
        public static string AppDataRoaming             = BaseDirectories.UserProfile + @"AppData\Roaming";
        public static string Documents                  = BaseDirectories.UserProfile + @"Documents";
    }
}

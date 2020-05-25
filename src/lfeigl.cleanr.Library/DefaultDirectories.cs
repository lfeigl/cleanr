namespace lfeigl.cleanr.Library
{
    public static class DefaultDirectories
    {
        public static string ProgramData { get; set; }
        public static string ProgramFiles { get; set; }
        public static string ProgramFilesCommonFiles { get; set; }
        public static string ProgramFilesX86 { get; set; }
        public static string ProgramFilesX86CommonFiles { get; set; }
        public static string AppDataLocal { get; set; }
        public static string AppDataLocalPrograms { get; set; }
        public static string AppDataLocalProgramsCommon { get; set; }
        public static string AppDataLocalLow { get; set; }
        public static string AppDataRoaming { get; set; }
        public static string Documents { get; set; }
        static DefaultDirectories()
        {
            ProgramData                 = BaseDirectories.SystemDrive + @"ProgramData";
            ProgramFiles                = BaseDirectories.SystemDrive + @"Program Files";
            ProgramFilesCommonFiles     = BaseDirectories.SystemDrive + @"Program Files\Common Files";
            ProgramFilesX86             = BaseDirectories.SystemDrive + @"Program Files (x86)";
            ProgramFilesX86CommonFiles  = BaseDirectories.SystemDrive + @"Program Files (x86)\Common Files";
            AppDataLocal                = BaseDirectories.UserProfile + @"AppData\Local";
            AppDataLocalPrograms        = BaseDirectories.UserProfile + @"AppData\Local\Programs";
            AppDataLocalProgramsCommon  = BaseDirectories.UserProfile + @"AppData\Local\Programs\Common";
            AppDataLocalLow             = BaseDirectories.UserProfile + @"AppData\LocalLow";
            AppDataRoaming              = BaseDirectories.UserProfile + @"AppData\Roaming";
            Documents                   = BaseDirectories.UserProfile + @"Documents";
        }
    }
}

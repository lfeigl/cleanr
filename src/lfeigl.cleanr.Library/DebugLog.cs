using System;
using System.IO;

namespace lfeigl.cleanr.Library
{
    public static class DebugLog
    {
        private static string path = @"debug.log";

        private static void Initialize()
        {
            string[] header = {
                $"cleanr debug log [initialized on {DateTime.Now}]",
                "",
            };

            File.WriteAllLines(path, header);
        }

        public static void Add(string log)
        {
            if (!File.Exists(path))
            {
                Initialize();
            }

            using (StreamWriter debugLog = new StreamWriter(path, true))
            {
                debugLog.WriteLine($"[{DateTime.Now}] {log}");
            }
        }
    }
}

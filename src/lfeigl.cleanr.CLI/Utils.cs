using System;
using System.Collections.Generic;
using System.ComponentModel;
using lfeigl.cleanr.Library;

namespace lfeigl.cleanr.CLI
{
    public static class Utils
    {
        public static void PrintBaseObject(Base baseObject)
        {
            List<string> print = new List<string>();

            print.Add($"=== {baseObject.ID} ===");

            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(baseObject))
            {
                string key = descriptor.Name;
                object value = descriptor.GetValue(baseObject);

                print.Add($"{key}: {value}");
            }

            print.Add("");

            Console.WriteLine(string.Join("\n", print));
        }

        public static void PrintListOfBaseObjects(List<Base> list)
        {
            foreach (Base baseObject in list)
            {
                PrintBaseObject(baseObject);
            }
        }
    }
}

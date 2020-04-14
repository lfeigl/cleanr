using System;
using lfeigl.cleanr.Library;

namespace lfeigl.cleanr.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            Location locationA = new Location();
            Location locationB = new Location();
            Location locationC = new Location();

            locationA.Path = @"a\b\c";
            locationB.Path = @"x\y\z";
            locationC.Path = @"1\2\3";

            Utils.PrintBaseObject(locationA);
            Utils.PrintBaseObject(locationB);
            Utils.PrintBaseObject(locationC);
        }
    }
}

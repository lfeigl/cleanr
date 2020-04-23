using System.Linq;
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
            LocationList list = new LocationList();

            locationA.Path = @"a\b\c";
            locationB.Path = @"x\y\z";
            locationC.Path = @"1\2\3";

            list.Add(locationA);
            list.Add(locationB);
            list.Add(locationC);

            Utils.PrintListOfBaseObjects(list.ToList<Base>());
            list.ToggleAllChecked();
            Utils.PrintListOfBaseObjects(list.ToList<Base>());
            list.ToggleAllChecked();
            Utils.PrintListOfBaseObjects(list.ToList<Base>());
        }
    }
}

using System.Collections.Generic;

namespace lfeigl.cleanr.Library
{
    public class LocationList : List<Location>
    {
        public bool AllChecked { get; set; }

        public void ToggleAllChecked()
        {
            AllChecked = !AllChecked;

            foreach (Location location in this)
            {
                location.Checked = AllChecked;
            }
        }
    }
}

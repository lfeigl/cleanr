using System.Collections.Generic;

namespace lfeigl.cleanr.Library
{
    public class LocationList : List<Location>
    {
        public bool AllChecked { get; set; }

        public LocationList()
        {
            this.AllChecked = true;
        }

        public new void Add(Location location)
        {
            location.Checked = this.AllChecked;
            base.Add(location);
        }

        public void ToggleAllChecked()
        {
            this.AllChecked = !this.AllChecked;

            foreach (Location location in this)
            {
                location.Checked = this.AllChecked;
            }
        }
    }
}

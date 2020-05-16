using System.Windows;
using lfeigl.cleanr.Library;

namespace lfeigl.cleanr.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private LocationList list = new LocationList();

        public MainWindow()
        {
            InitializeComponent();
            AddSampleLocations();
            DataGridLocations.ItemsSource = list;
        }

        private void AddSampleLocations()
        {
            Location locationA = new Location();
            Location locationB = new Location();
            Location locationC = new Location();

            locationA.Path = @"a\b\c";
            locationB.Path = @"x\y\z";
            locationC.Path = @"1\2\3";

            list.Add(locationA);
            list.Add(locationB);
            list.Add(locationC);
        }

        private void CheckBoxToggleAllChecked_Toggle(object sender, RoutedEventArgs e)
        {
            list.ToggleAllChecked();
            DataGridLocations.Items.Refresh();
        }
    }
}

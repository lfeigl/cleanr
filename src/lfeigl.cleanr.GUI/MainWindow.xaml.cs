using System.Windows;
using lfeigl.cleanr.Library;

namespace lfeigl.cleanr.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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

            DataGridLocations.ItemsSource = list;
        }
    }
}

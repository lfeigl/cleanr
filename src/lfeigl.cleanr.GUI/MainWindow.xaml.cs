using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
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
            list.Clear();
            DataGridLocations.ItemsSource = list;
        }

        private void CheckBoxToggleAllChecked_Toggle(object sender, RoutedEventArgs e)
        {
            list.ToggleAllChecked();
            DataGridLocations.Items.Refresh();
        }

        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            List<string> directories = new List<string>();
            string appName = TextBoxAppName.Text;

            foreach (PropertyInfo prop in typeof(DefaultDirectories).GetProperties())
            {
                directories.AddRange(Directory.EnumerateDirectories((string)prop.GetValue(null), $"*{appName}*"));
            }

            list.Clear();

            foreach (string directory in directories)
            {
                list.Add(new Location { Path = directory });
            }

            DataGridLocations.Items.Refresh();
        }

        private void TextBoxAppName_TextChanged(object sender, TextChangedEventArgs e)
        {
            int cursorPosition = TextBoxAppName.SelectionStart;
            TextBoxAppName.Text = Regex.Replace(TextBoxAppName.Text, "[^0-9a-zA-Z ._-]", "");
            TextBoxAppName.SelectionStart = cursorPosition;
            ButtonSearch.IsEnabled = TextBoxAppName.Text.Length > 1;
        }
    }
}

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

        private void ButtonClean_Click(object sender, RoutedEventArgs e)
        {
            LocationList deletedLocations = new LocationList();

            foreach (Location location in list)
            {
                if (location.Checked)
                {
                    DeleteDirectory(location.Path);
                    deletedLocations.Add(location);
                }
            }

            foreach (Location location in deletedLocations)
            {
                list.Remove(location);
            }

            DataGridLocations.Items.Refresh();
        }

        private void DeleteDirectory(string directory)
        {
            File.SetAttributes(directory, FileAttributes.Normal);

            foreach (string file in Directory.EnumerateFiles(directory))
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }

            foreach (string subDirectory in Directory.EnumerateDirectories(directory))
            {
                DeleteDirectory(subDirectory);
            }

            Directory.Delete(directory, false);
        }
    }
}

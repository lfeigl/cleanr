﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using lfeigl.cleanr.Library;
using MahApps.Metro.Controls.Dialogs;

namespace lfeigl.cleanr.GUI.Windows
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main
    {
        private LocationList list = new LocationList();

        public Main()
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

        private async void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            List<string> foundDirsList = new List<string>();
            string appName = TextBoxAppName.Text.Trim();
            string searchPattern = $"*{appName}*";

            foreach (PropertyInfo prop in typeof(DefaultDirectories).GetProperties())
            {
                string rootDirPath = (string)prop.GetValue(null);
                List<string> allSubDirsList = GetSubDirsBySearchPattern(rootDirPath, "*");

                foundDirsList.AddRange(GetSubDirsBySearchPattern(rootDirPath, searchPattern));

                foreach (string subDirPath in allSubDirsList.Except(foundDirsList))
                {
                    foundDirsList.AddRange(GetSubDirsBySearchPattern(subDirPath, searchPattern));
                }
            }

            if (foundDirsList.Count == 0)
            {
                await this.ShowMessageAsync("Nothing here! 😄👍", $"No leftovers of \"{appName}\" were found.");
            } else
            {
                list.Clear();

                foreach (string dirPath in foundDirsList)
                {
                    Location location = new Location { Path = dirPath };
                    string dirName = Path.GetFileName(dirPath);

                    if (dirName.ToLower() == appName.ToLower())
                    {
                        location.Checked = true;
                    }

                    list.Add(location);
                }

                DataGridLocations.Items.Refresh();
            }
        }

        private List<string> GetSubDirsBySearchPattern(string rootDirPath, string searchPattern)
        {
            List<string> foundDirsList = new List<string>();

            try
            {
                Directory.GetAccessControl(rootDirPath);
                foundDirsList.AddRange(Directory.EnumerateDirectories(rootDirPath, searchPattern));
            }
            catch (UnauthorizedAccessException ex)
            {
                DebugLog.Add(ex.Message);
            }

            return foundDirsList;
        }

        private void TextBoxAppName_TextChanged(object sender, TextChangedEventArgs e)
        {
            int cursorPosition = TextBoxAppName.SelectionStart;
            TextBoxAppName.Text = Regex.Replace(TextBoxAppName.Text, "[^0-9a-zA-Z ._-]", "");
            TextBoxAppName.SelectionStart = cursorPosition;
            ButtonSearch.IsEnabled = TextBoxAppName.Text.Trim().Length > 1;
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

        private void TextBoxAppName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ButtonSearch_Click(sender, e);
            }
        }

        private void ButtonOpen_Click(object sender, RoutedEventArgs e)
        {
            Location selectedLocation = (Location)DataGridLocations.SelectedItem;
            Process.Start(@selectedLocation.Path);
        }

        private void DataGridLocations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGridLocations.SelectedItem == null)
            {
                ButtonOpen.IsEnabled = false;
            }
            else
            {
                ButtonOpen.IsEnabled = true;
            }
        }

        private async void ButtonAbout_Click(object sender, RoutedEventArgs e)
        {
            string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            string[] aboutText = {
                $"cleanr v{version}",
                "VERSION NOT FINAL",
            };

            await this.ShowMessageAsync("About cleanr", string.Join(Environment.NewLine, aboutText));
        }
    }
}

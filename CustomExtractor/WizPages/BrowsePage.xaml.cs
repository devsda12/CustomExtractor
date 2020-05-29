using CustomExtractor.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CustomExtractor.WizPages
{
    /// <summary>
    /// Interaction logic for BrowsePage.xaml
    /// </summary>
    public partial class BrowsePage : Page
    {
        public BrowsePage()
        {
            InitializeComponent();
            ExportPath_TB.Text = Directory.GetCurrentDirectory();
        }

        private void Browse_Button_Click(object sender, RoutedEventArgs e)
        {
            var folderbrowser = new System.Windows.Forms.FolderBrowserDialog();
            if (folderbrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ExportPath_TB.Text = folderbrowser.SelectedPath;
                ExtractorLogic.Instance.exportPath = folderbrowser.SelectedPath;
            }
        }
    }
}

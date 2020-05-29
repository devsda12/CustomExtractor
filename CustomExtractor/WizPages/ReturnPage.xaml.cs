﻿using CustomExtractor.Models;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for ReturnPage.xaml
    /// </summary>
    public partial class ReturnPage : Page
    {
        public ReturnPage()
        {
            InitializeComponent();
        }

        public void Page_Loaded(object sender, RoutedEventArgs e)
        {
            FinishMessage.Text = ExtractorLogic.Instance.exportResultString;
        }
    }
}

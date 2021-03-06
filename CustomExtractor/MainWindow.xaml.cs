﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CustomExtractor.Models;

namespace CustomExtractor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        enum PageChange { UP, DOWN}

        List<WizPage> pages = new List<WizPage>();
        int lastAddedPageIndex, currentPageIndex = 0;
        public MainWindow()
        {
            InitializeComponent();

            //Initializing the pages
            pages.Add(new WizPage(new WizPages.BrowsePage(), "Customize"));
            WizPages.ProgressPage progressPage = new WizPages.ProgressPage();
            progressPage.ExtractionCompleted += Next_Button_Click;
            pages.Add(new WizPage(progressPage, "Extract", canGoBack: false, canGoForward: false));
            pages.Add(new WizPage(new WizPages.ReturnPage(), "Finish", canGoBack: false));

            //Creating the Steps
            InitializeSteps();

            //Setting the browse as the default appearing page in the contentframe
            ContentFrame.Content = pages[0].page;

            //Disabling the back button
            Back_Button.IsEnabled = false;
        }

        //Initialize steps method
        private void InitializeSteps()
        {
            int count = 0;
            foreach (WizPage aWizPage in pages)
            {
                RowDefinition newDef = new RowDefinition();
                newDef.Height = new GridLength(40);
                Steps_Grid.RowDefinitions.Add(newDef);

                TextBlock newStep = new TextBlock();
                newStep.Text = "• " + aWizPage.pageName;
                newStep.VerticalAlignment = VerticalAlignment.Center;
                newStep.Padding = new Thickness(10);
                if (count == 0) newStep.FontWeight = FontWeights.Bold;

                Grid.SetRow(newStep, count);
                Steps_Grid.Children.Add(newStep);
                aWizPage.nameBlock = newStep;
                count++;
            }
        }

        //Navigation bar button clicks and updates under here
        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            if (ContentFrame.CanGoBack && pages[currentPageIndex].canGoBack)
            {
                ContentFrame.GoBack();

                //Modding the index
                currentPageIndex--;
                Button_Update(pages[currentPageIndex]);
                Steps_Update(pages[currentPageIndex], PageChange.DOWN);
            }
        }

        private void Next_Button_Click(object sender, RoutedEventArgs e)
        {
            if (ContentFrame.CanGoForward)
            {
                ContentFrame.GoForward();
            }
            else
            {
                if (lastAddedPageIndex < pages.Count - 1)
                {
                    lastAddedPageIndex++;
                    ContentFrame.Navigate(pages[lastAddedPageIndex].page);
                } else if(currentPageIndex == pages.Count - 1)
                {
                    Close();
                    return;
                }
            }

            //Checking if back button should be enabled after updating current index
            currentPageIndex++;
            Button_Update(pages[currentPageIndex]);
            Steps_Update(pages[currentPageIndex]);

            //if (Back_Button.IsEnabled != pages[currentPageIndex].canGoBack) Back_Button.IsEnabled = !Back_Button.IsEnabled; //Quite cool, always works as it checks if enabled is equal to if it may be enabled and the other way around
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Update(WizPage newPage)
        {
            //First default checks, is it the first or last index. If so, this overrules the WizPage parameters
            if (currentPageIndex == 0) Back_Button.IsEnabled = false;
            if (currentPageIndex == pages.Count - 1) Next_Button.Content = "Finish";
            else Next_Button.Content = "Next";

            //Now checking the newPage properties
            if (newPage.canGoBack)
            {
                Back_Button.IsEnabled = true;
            }
            else Back_Button.IsEnabled = false;

            if (newPage.canGoForward)
            {
                Next_Button.IsEnabled = true;
            }
            else Next_Button.IsEnabled = false;
        }

        private void Steps_Update(WizPage newPage, PageChange pageChange=PageChange.UP)
        {
            //Changing it for the new page
            newPage.nameBlock.FontWeight = FontWeights.Bold;

            //Changing it for the previous page
            if(pageChange == PageChange.UP)
            {
                pages[currentPageIndex - 1].nameBlock.FontWeight = FontWeights.Normal;
            }
            else
            {
                pages[currentPageIndex + 1].nameBlock.FontWeight = FontWeights.Normal;
            }
        }
    }
}

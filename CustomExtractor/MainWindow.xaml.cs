using System;
using System.Collections.Generic;
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

namespace CustomExtractor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Page> pages = new List<Page>();
        int lastAddedPageIndex = 0;
        public MainWindow()
        {
            InitializeComponent();

            //Initializing the pages
            pages.Add(new WizPages.BrowsePage());
            pages.Add(new WizPages.ProgressPage());

            //Setting the browse as the default appearing page in the contentframe
            ContentFrame.Content = pages[0];

            //Disabling the back button
            Back_Button.IsEnabled = false;
        }

        //Navigation bar button clicks under here
        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            if (ContentFrame.CanGoBack)
            {
                ContentFrame.GoBack();

                //Checking if the back button should be disabled
                if (!ContentFrame.CanGoBack) Back_Button.IsEnabled = false;
            }
        }

        private void Extract_Button_Click(object sender, RoutedEventArgs e)
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
                    ContentFrame.Navigate(pages[lastAddedPageIndex]);
                }
            }

            if (!Back_Button.IsEnabled) Back_Button.IsEnabled = true;
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

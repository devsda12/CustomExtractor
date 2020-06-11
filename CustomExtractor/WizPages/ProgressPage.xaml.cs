using CustomExtractor.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Resources;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CustomExtractor.WizPages
{
    //Extraction complete event delegate (template)
    public delegate void NotifyResult(object sender, RoutedEventArgs e);

    /// <summary>
    /// Interaction logic for ProgressPage.xaml
    /// </summary>
    public partial class ProgressPage : Page
    {
        //Event that gets called whenever the extraction is complete, this uses the Notify delegate template
        public event NotifyResult ExtractionCompleted;

        //The worker thread object
        BackgroundWorker workerThread = new BackgroundWorker();

        public ProgressPage()
        {
            InitializeComponent();

            //Configuring the workerThread
            workerThread.WorkerReportsProgress = true;
            workerThread.DoWork += ExtractFile;
            workerThread.ProgressChanged += delegate (object sender, ProgressChangedEventArgs e)
            {
                StatusMessage.Text = e.UserState as String;
                ProgressBar.Value = e.ProgressPercentage;
            };
            workerThread.RunWorkerCompleted += delegate (object sender, RunWorkerCompletedEventArgs e)
            {
                if (e.Error != null)
                {
                    System.Windows.MessageBox.Show(e.Error.Message);
                    ExtractorLogic.Instance.exportResultString = (String)App.Current.Resources["Finish_Message_Failure"];
                }
                ExtractionCompleted?.Invoke(null, null);
            };
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            workerThread.RunWorkerAsync();
        }

        private void ExtractFile(object sender, DoWorkEventArgs e)
        {
            //Retrieving the payload from resources
            Uri uri = new Uri("pack://application:,,,/Res/Payload/payload.zip");


            for(int i = 0; i < 100; i++)
            {
                (sender as BackgroundWorker).ReportProgress(i, "Extracting \"...\"");
                Thread.Sleep(50);
                /*if(i == 50)
                {
                    throw new ExtractorLogic.ExtractionFaultException("A extraction fault appeared");
                }*/
            }
        }
    }
}

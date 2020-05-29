using System;
using System.Collections.Generic;
using System.Text;

namespace CustomExtractor.Models
{
    class ExtractorLogic
    {
        //Extractor class variables
        public String exportPath = null;
        public String exportResultString = (String)App.Current.Resources["Finish_Message_Success"];

        //Instance logic vars
        private static ExtractorLogic instance;
        private static readonly object padlock = new object();

        ExtractorLogic()
        {
        }

        public static ExtractorLogic Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null) instance = new ExtractorLogic();
                    return instance;
                }
            }
        }

        public class ExtractionFaultException : Exception
        {
            public ExtractionFaultException()
            {
            }

            public ExtractionFaultException(String message) : base(message)
            {
            }

            public ExtractionFaultException(String message, Exception inner) : base(message, inner)
            {
            }
        }
    }
}

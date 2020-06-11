using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace CustomExtractor.Models
{
    /// <summary>
    /// Wrapper for a default Page which also contains some own set properties
    /// </summary>
    public class WizPage
    {
        //Custom variables under here
        public Page page;
        public string pageName { get; set; }
        public TextBlock nameBlock { get; set; }
        public bool canGoBack, canGoForward = true;

        //Constructor
        public WizPage(Page page, string pageName, bool canGoBack = true, bool canGoForward = true)
        {
            this.page = page;
            this.pageName = pageName;
            this.canGoBack = canGoBack;
            this.canGoForward = canGoForward;
        }
    }
}

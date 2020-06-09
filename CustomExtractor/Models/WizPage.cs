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
        public String pageName;
        public TextBlock nameBlock;
        public bool canGoBack, canGoForward = true;

        //Constructor
        public WizPage(Page page, bool canGoBack = true, bool canGoForward = true)
        {
            this.page = page;
            this.canGoBack = canGoBack;
            this.canGoForward = canGoForward;
        }
    }
}

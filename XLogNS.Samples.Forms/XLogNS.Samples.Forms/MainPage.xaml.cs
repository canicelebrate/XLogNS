using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XLog;

namespace XLogNS.Samples.Forms
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        protected void OnBtnClicked(object sender,EventArgs e)
        {
            var logger = LogManager.Default.GetLogger("TestLogger");
            logger.Info(string.Format("Hello {0}", "World"));
        }
	}
}

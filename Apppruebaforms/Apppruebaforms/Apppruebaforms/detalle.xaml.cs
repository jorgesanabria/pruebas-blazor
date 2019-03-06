using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Apppruebaforms
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class detalle : ContentPage
	{
        //private float numero;
		public detalle ()
		{
			InitializeComponent ();
		}

        private void Numero_Clicked(object sender, EventArgs e)
        {
            var n = (sender as Button).Text.ToString();
            Numero.Text += n + "a";
        }
    }
}
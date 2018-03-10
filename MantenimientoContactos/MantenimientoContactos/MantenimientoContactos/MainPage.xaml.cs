using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MantenimientoContactos
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

	    private int contador = 0;

	    private void BtnAccion_OnClicked(object sender, EventArgs e)
	    {
	        contador++;
	        lblMensaje.Text = $"Numero de Clicks {contador}";
	    }
	  
	}
}

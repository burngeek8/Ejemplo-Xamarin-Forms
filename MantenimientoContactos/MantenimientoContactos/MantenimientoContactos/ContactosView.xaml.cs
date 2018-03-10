using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MantenimientoContactos.API.DTO;
using MantenimientoContactos.Datos;
using MantenimientoContactos.Datos.Modelo;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MantenimientoContactos
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContactosView : ContentPage
	{
	    private BaseDeDatos db;
	    private HttpClient cliente;

		public ContactosView ()
		{
			InitializeComponent ();
            InicializarConexion();
		    IniciarListView();
		}

	    public void OnSearchButtonPressed(object sender, EventArgs e)
	    {
	        lstContactos.ItemsSource =
	            db.Contactos.Where(c =>
	                c.Nombre.ToLower().Contains(scbBuscarContacto.Text.ToLower()));
	    }

	    private async void IniciarListView()
	    {
	        actLoader.IsVisible = true;
	        var respuesta = await cliente.GetAsync(new Uri("http://xfcontactos.azurewebsites.net/api/contactos"));
	        if (respuesta.IsSuccessStatusCode)
	        {
	            var contenido = await respuesta.Content.ReadAsStringAsync();
	            var items = JsonConvert.DeserializeObject<List<ContactosListView>>(contenido);
	            lstContactos.ItemsSource = items;
	        }
	        actLoader.IsVisible = false;
	    }

	    private void ScbBuscarContacto_OnTextChanged(object sender, TextChangedEventArgs e)
	    {
	        if(scbBuscarContacto.Text.Length==0) IniciarListView();
	    }

	    private void InicializarConexion()
	    {
            cliente =new HttpClient();
	    }
	}
}
using EVegaT6.Models;
using System;
using System.Net;

namespace EVegaT6.Views;

public partial class vActEliminar : ContentPage
{

    private const string url = "http://192.168.100.13/moviles/wsestudiantes.php";
    private readonly Estudiante estudiante;
    public vActEliminar(Estudiante datos)
	{
		InitializeComponent();
        estudiante = datos;
        txtCodigo.Text = datos.codigo.ToString();
        txtNombre.Text = datos.nombre;
        txtApellido.Text = datos.apellido;
        txtEdad.Text = datos.edad.ToString();
	}

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
        try
        {
            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            parametros.Add("codigo", txtCodigo.Text);
            parametros.Add("nombre", txtNombre.Text);
            parametros.Add("apellido", txtApellido.Text);
            parametros.Add("edad", txtEdad.Text);

            cliente.UploadValues($"{url}?codigo={txtCodigo.Text}", "PUT", parametros);

            DisplayAlert("Success", "Estudiante actualizado correctamente", "OK");
            Navigation.PushAsync(new vEstudiante());
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", ex.Message, "OK");
        }
    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        try
        {
            WebClient cliente = new WebClient();
            string codigo = txtCodigo.Text;
            var parametros = new System.Collections.Specialized.NameValueCollection();
            parametros.Add("codigo", codigo);

            cliente.UploadValues($"{url}?codigo={codigo}", "DELETE", parametros);

            DisplayAlert("Success", "Estudiante eliminado correctamente", "OK");
            Navigation.PushAsync(new vEstudiante());
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", ex.Message, "OK");
        }
    }
}
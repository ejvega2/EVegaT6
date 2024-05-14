using EVegaT6.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace EVegaT6.Views;

public partial class vEstudiante : ContentPage
{
	private const string url = "http://192.168.100.13/moviles/wsestudiantes.php";
	private readonly HttpClient cliente = new HttpClient();
	private ObservableCollection<Estudiante> est;
	public vEstudiante()
	{
		InitializeComponent();
		ObtenerDatos();

    }

	public async void ObtenerDatos()
	{
		var content = await cliente.GetStringAsync(url);
		List<Estudiante> mostrar = JsonConvert.DeserializeObject<List<Estudiante>>(content);
		est = new ObservableCollection<Estudiante>(mostrar);
		listEstudiantes.ItemsSource = est;
	}

}
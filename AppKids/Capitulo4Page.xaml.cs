namespace AppKids;

public partial class Capitulo4Page : ContentPage
{
	public Capitulo4Page()
	{
		InitializeComponent();
	}

    private async void OnPreguntasClicked(object sender, EventArgs e)
    {
        /// Navega a la p�gina de preguntas (la crearemos despu�s)
        await Shell.Current.GoToAsync("CuartoCapituloPreguntas");
    }
}
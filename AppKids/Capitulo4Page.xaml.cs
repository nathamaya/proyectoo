namespace AppKids;

public partial class Capitulo4Page : ContentPage
{
	public Capitulo4Page()
	{
		InitializeComponent();
	}

    private async void OnPreguntasClicked(object sender, EventArgs e)
    {
        /// Navega a la página de preguntas (la crearemos después)
        await Shell.Current.GoToAsync("CuartoCapituloPreguntas");
    }
}
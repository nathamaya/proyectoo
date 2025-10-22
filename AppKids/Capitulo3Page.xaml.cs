namespace AppKids;

public partial class Capitulo3Page : ContentPage
{
	public Capitulo3Page()
	{
		InitializeComponent();
	}

    private async void OnPreguntasClicked(object sender, EventArgs e)
    {
        // Navega a la página de preguntas (la crearemos después)
        await Shell.Current.GoToAsync("TerceroCapituloPreguntas");
    }
}
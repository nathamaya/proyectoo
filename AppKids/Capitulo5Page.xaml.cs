namespace AppKids;

public partial class Capitulo5Page : ContentPage
{
	public Capitulo5Page()
	{
		InitializeComponent();
	}

    private async void OnPreguntasClicked(object sender, EventArgs e)
    {
        // Navega a la página de preguntas (la crearemos después)
        await Shell.Current.GoToAsync("QuintoCapituloPreguntas");
    }
}
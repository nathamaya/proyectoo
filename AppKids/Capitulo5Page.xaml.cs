namespace AppKids;

public partial class Capitulo5Page : ContentPage
{
	public Capitulo5Page()
	{
		InitializeComponent();
	}

    private async void OnPreguntasClicked(object sender, EventArgs e)
    {
        // Navega a la p�gina de preguntas (la crearemos despu�s)
        await Shell.Current.GoToAsync("QuintoCapituloPreguntas");
    }
}
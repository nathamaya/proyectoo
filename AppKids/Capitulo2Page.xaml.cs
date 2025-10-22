namespace AppKids;

public partial class Capitulo2Page : ContentPage
{
	public Capitulo2Page()
	{
		InitializeComponent();
	}

    private async void OnPreguntasClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("SegundoCapituloPreguntas");
    }
}
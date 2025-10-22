namespace AppKids;

public partial class PreguntasCuatro : ContentPage
{
	public PreguntasCuatro()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        int correctas = 0;

        // Pregunta 1 correcta: "Asteroide B-612"
        if (rb1_3.IsChecked) correctas++;

        // Pregunta 2 correcta: "Un astrónomo turco"
        if (rb2_1.IsChecked) correctas++;

        // Pregunta 3 correcta: "Por su manera de vestir"
        if (rb3_2.IsChecked) correctas++;

        lblResultado.Text = $"¡Respondiste correctamente {correctas} de 3 preguntas!";
        popupResultado.IsVisible = true;
    }

    private async void Continuar_Clicked(object sender, EventArgs e)
    {
        popupResultado.IsVisible = false;

        // Navegar al capítulo 5
        await Navigation.PushAsync(new Capitulo5Page());
    }
}
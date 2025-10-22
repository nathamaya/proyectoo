namespace AppKids;

public partial class PreguntasDos : ContentPage
{
	public PreguntasDos()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        int correctas = 0;

        // Pregunta 1 correcta: "Que le dibuje un cordero"
        if (rb1_3.IsChecked) correctas++;

        // Pregunta 2 correcta: "Acepta y le dibuja un cordero"
        if (rb2_3.IsChecked) correctas++;

        // Pregunta 3 correcta: "Un cordero dormido en una caja"
        if (rb3_3.IsChecked) correctas++;

        lblResultado.Text = $"¡Respondiste correctamente {correctas} de 3 preguntas!";
        popupResultado.IsVisible = true;
    }

    private async void Continuar_Clicked(object sender, EventArgs e)
    {
        popupResultado.IsVisible = false;

        // Aquí navega al siguiente capítulo (ajusta el nombre de la página)
        await Navigation.PushAsync(new Capitulo3Page());
    }

}
namespace AppKids;

public partial class PreguntasTres : ContentPage
{
	public PreguntasTres()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        int correctas = 0;

        // Pregunta 1 correcta: "Que viene de un planeta muy pequeño"
        if (rb1_2.IsChecked) correctas++;

        // Pregunta 2 correcta: "Por preguntas que el Principito hace sobre la Tierra"
        if (rb2_2.IsChecked) correctas++;

        // Pregunta 3 correcta: "Las ovejas y su flor"
        if (rb3_1.IsChecked) correctas++;

        lblResultado.Text = $"¡Respondiste correctamente {correctas} de 3 preguntas!";
        popupResultado.IsVisible = true;
    }

    private async void Continuar_Clicked(object sender, EventArgs e)
    {
        popupResultado.IsVisible = false;

        // Navegar al capítulo 4
        await Navigation.PushAsync(new Capitulo4Page());
    }

}
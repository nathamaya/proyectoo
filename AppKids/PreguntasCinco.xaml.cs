namespace AppKids;

public partial class PreguntasCinco : ContentPage
{
	public PreguntasCinco()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        int correctas = 0;

        // Pregunta 1 correcta: "Los baobabs que pod�an destruir su planeta"
        if (rb1_2.IsChecked) correctas++;

        // Pregunta 2 correcta: "Arrancarlos cuando eran peque�os"
        if (rb2_2.IsChecked) correctas++;

        // Pregunta 3 correcta: "Romper�an el planeta con sus ra�ces"
        if (rb3_1.IsChecked) correctas++;

        lblResultado.Text = $"�Respondiste correctamente {correctas} de 3 preguntas!";
        popupResultado.IsVisible = true;
    }

    private async void Continuar_Clicked(object sender, EventArgs e)
    {
        popupResultado.IsVisible = false;

        // Aqu� podr�as ir a una pantalla final o repetir
        await Navigation.PushAsync(new JuegoPage()); // Ajusta si hay una p�gina�final
����}

}
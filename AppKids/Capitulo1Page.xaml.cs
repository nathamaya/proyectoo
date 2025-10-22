namespace AppKids;

public partial class Capitulo1Page : ContentPage
{
	public Capitulo1Page()
	{
		InitializeComponent();
        AddPressEffect(Frame1);
        AddPressEffect(Frame2);
        AddPressEffect(Frame3);
        AddPressEffect(Frame4);
    }

    private void AddPressEffect(Frame frame)
    {
        var tapGesture = frame.GestureRecognizers.OfType<TapGestureRecognizer>().FirstOrDefault();
        if (tapGesture == null) return;

      
    }

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        if (sender is Frame frame)
        {
            // Animación de “presionar”
            await frame.ScaleTo(0.95, 100, Easing.CubicIn);

            // Animación de “soltar”
            await frame.ScaleTo(1, 100, Easing.CubicOut);
            // Determinar qué botón fue presionado
            string opcion = "";

            if (frame == Frame1) opcion = "Arreglar pensamientos negativos";
            else if (frame == Frame2) opcion = "Opción 2";
            else if (frame == Frame3) opcion = "Opción 3";
            else if (frame == Frame4) opcion = "Opción 4";

            if (opcion == "Arreglar pensamientos negativos")
            {
                await Navigation.PushAsync(new PreguntasUno("Arreglar pensamientos negativos"));
            }
        }
    }
}
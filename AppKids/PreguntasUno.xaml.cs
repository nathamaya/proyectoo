namespace AppKids;

public partial class PreguntasUno : ContentPage
{
    // Lista para guardar los textos de los botones seleccionados
    private List<string> botonesSeleccionados = new List<string>();

    // Este constructor permite recibir 1 argumento (el texto de la opción)
   

    public PreguntasUno(string opcion)
    {
        InitializeComponent();
    }

    // Al presionar un botón
    private async void BotonSeleccionado_Clicked(object sender, EventArgs e)
    {
        if (sender is Button btn)
        {
            // Evitar que se agregue varias veces
            if (!botonesSeleccionados.Contains(btn.Text))
            {
                botonesSeleccionados.Add(btn.Text);
            }

            // Animación visual: desvanecido + cambio de color
            await btn.FadeTo(0.5, 100);
            btn.BackgroundColor = Colors.LightGray;
        }
    }

    // Generar proceso personalizado según cuántos botones se seleccionaron
    private void GenerarProceso_Clicked(object sender, EventArgs e)
    {
        int cantidad = botonesSeleccionados.Count;
        string mensaje = "";

        if (cantidad == 0)
            mensaje = "Selecciona al menos un pensamiento para generar tu proceso personalizado.";
        else if (cantidad <= 2)
            mensaje = "Proceso básico: identifica tus pensamientos y reflexiona sobre ellos.";
        else if (cantidad <= 4)
            mensaje = "Proceso intermedio: aprende técnicas para manejar estos pensamientos.";
        else
            mensaje = "Proceso avanzado: aplica estrategias completas de gestión emocional y mental.";

        DisplayAlert("Tu proceso personalizado", mensaje, "OK");
    }
}
namespace AppKids
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            ShowIntro();
        }

        private async void ShowIntro()
        {
            try
            {
                // Animación del logo (~3s)
                await logoLabel.FadeTo(1, 400);
                await logoLabel.ScaleTo(1.05, 800);
                await Task.Delay(1800);

                // Desvanecer intro y mostrar el formulario de login
                await IntroGrid.FadeTo(0, 400, Easing.Linear);
                IntroGrid.IsVisible = false;

                LoginForm.IsVisible = true;
                await LoginForm.FadeTo(1, 600, Easing.CubicIn);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"ShowIntro error: {ex.Message}");
                IntroGrid.IsVisible = false;
                LoginForm.IsVisible = true;
                LoginForm.Opacity = 1;
            }
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            // Aquí luego se agregará la lógica de inicio de sesión
            await DisplayAlert("Login", "Función aún no implementada", "OK");
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            // Aquí luego se agregará la lógica de crear cuenta
            await DisplayAlert("Crear Cuenta", "Función aún no implementada", "OK");
        }
    }
}
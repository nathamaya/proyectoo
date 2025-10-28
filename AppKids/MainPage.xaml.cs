using AppKids.Data;

namespace AppKids
{
    public partial class MainPage : ContentPage
    {
        private readonly DatabaseRepository _repo;
        public MainPage(DatabaseRepository repo)
        {
            InitializeComponent();
            _repo = repo;
            ShowIntro();
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Shell.SetTabBarIsVisible(this, false);
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
            try
            {

                bool isRegistered = _repo.IsRegistered(EmailEntry.Text, PasswordEntry.Text).Result;
                if (isRegistered)
                {
                    Shell.SetTabBarIsVisible(this, true);
                    await Navigation.PushAsync(new Capitulo1Page(_repo));
                }
                else
                {
                    await DisplayAlert("Error de autenticación", "Correo o contraseña incorrectos.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error al iniciar sesión", "Correo o contraseña incorrectos", "OK");
            }
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Register(_repo));
        }
    }
}
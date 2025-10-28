using AppKids.Data;
using AppKids.Models;

namespace AppKids;

public partial class Register : ContentPage
{
    private readonly DatabaseRepository _repo;
    public Register(DatabaseRepository repo)
	{
		InitializeComponent();
        _repo = repo;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        Shell.SetTabBarIsVisible(this, false);
    }

    private void OnSignInClicked(object sender, EventArgs e)
    {
		try
		{
			var user = new User
			{
				Username = UsernameEntry.Text,
				Email = EmailEntry.Text,
                Password = PasswordEntry.Text
			};

			_repo.SaveUserWithItemsAsync(user).Wait();

			DisplayAlert("Éxito", "Usuario registrado exitosamente", "OK");
			Navigation.PopAsync();
        }
		catch (Exception ex)
		{
			DisplayAlert("Error!", "Ingrese todos los datos", "OK");
        }
    }

    private void OnReturnClicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}
namespace MauiAppLogin;

public partial class Protegida : ContentPage
{
	public Protegida()
	{
		InitializeComponent();

		string? usuario_logado = null;

		Task.Run(async () => //Usar Task.Run para chamar método async no construtor e recuperar o usuário logado
        {
			usuario_logado = await SecureStorage.Default.GetAsync("usuario_logado");
			lbl_boasvindas.Text = $"Seja bem-vindo (a), {usuario_logado}!";
        }).Wait();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
		bool confirmacao = await DisplayAlertAsync("Confirmação de saída", "Sair do App?", "Sim", "Não");

		if (confirmacao)
		{
			SecureStorage.Default.Remove("usuario_logado");
			App.Current.MainPage = new Login();
        }
    }
}
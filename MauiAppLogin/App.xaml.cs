using Microsoft.Extensions.DependencyInjection;

namespace MauiAppLogin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = new Window(new ContentPage
            {
                Content = new ActivityIndicator { IsRunning = true }
            });

            // Chama a verificação de login
            ChecarUsuarioLogado(window);

            return window;
        }

        private async void ChecarUsuarioLogado(Window window)
        {
            var usuarioLogado = await SecureStorage.Default.GetAsync("usuario_logado");

            if (string.IsNullOrEmpty(usuarioLogado))
            {
                window.Page = new Login();         // Página inicial se NÃO estiver logado
            }
            else
            {
                window.Page = new Protegida();     // Página inicial se estiver logado
            }
        }
    }
}
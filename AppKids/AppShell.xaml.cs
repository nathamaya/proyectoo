namespace AppKids
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Register), typeof(Register));
            Routing.RegisterRoute("PrimerCapituloPreguntas", typeof(PreguntasUno));
            Routing.RegisterRoute("SegundoCapituloPreguntas", typeof(PreguntasDos));
            Routing.RegisterRoute("TerceroCapituloPreguntas", typeof(PreguntasTres));
            Routing.RegisterRoute("CuartoCapituloPreguntas", typeof(PreguntasCuatro));
            Routing.RegisterRoute("QuintoCapituloPreguntas", typeof(PreguntasCinco));
            Routing.RegisterRoute("juego", typeof(JuegoPage));


        }

    
    }
}

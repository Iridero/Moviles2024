using AppInventario.Data;
using AppInventario.Models;

namespace AppInventario
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private async void ContentPage_Loaded(object sender, EventArgs e)
        {
            var db = new ArticuloDbContext();
            var articulo2 = new Articulo
            {
                Descripcion = "Jabón Rosa Venus 25 gr.",
                Precio = 19.90m,
                Existencia = 10
            };
            await db.Agregar(articulo2);
            var lista = await db.GetAll();
            await db.Delete(2);
            lista = await db.GetAll();
            var articulo = await db.GetById(2);
            articulo.Precio = 48;
            db.Update(articulo);
            lista = await db.GetAll();
        }
    }

}

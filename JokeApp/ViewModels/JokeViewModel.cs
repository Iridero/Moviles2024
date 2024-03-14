
using JokeApp.Services;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace JokeApp.ViewModels
{
    public class JokeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public ICommand MostrarCommand {  get; set; } 

        private JokeApi api;
        public List<String> Categories { get; set; }
        public string Category { get; set; } = "any";

        public string Joke { get; set; }
        = "\r\n      _       _           _                \r\n     | | ___ | | _____   / \\   _ __  _ __  \r\n  _  | |/ _ \\| |/ / _ \\ / _ \\ | '_ \\| '_ \\ \r\n | |_| | (_) |   <  __// ___ \\| |_) | |_) |\r\n  \\___/ \\___/|_|\\_\\___/_/   \\_\\ .__/| .__/ \r\n                              |_|   |_|    \r\n";

        private async Task llenarCategorias()
        {
            api = new JokeApi();
            Categories=await api.GetCategories();
            OnPropertyChanged("Categories");
        }
        public JokeViewModel()
        {
            llenarCategorias();

            MostrarCommand = new AsyncCommand(Mostrar);
        }
 
        public void OnPropertyChanged(string? propertyName)
        {
            PropertyChanged?
                .Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async Task Mostrar()
        {
            Joke=await api.GetJoke(Category);
            OnPropertyChanged(nameof(Joke));
        }
    }
}

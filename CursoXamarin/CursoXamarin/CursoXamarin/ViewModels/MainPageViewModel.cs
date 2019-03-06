using CursoXamarin.Helpers;
using CursoXamarin.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CursoXamarin.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private ObservableCollection<Amiibo> _amiibos;

        public ObservableCollection<Character> Characters { get; set; }
        public ObservableCollection<Amiibo> Amiibos
        {
            get => _amiibos; set
            {
                _amiibos = value;
                OnPropertyChanged();
            }
        }
        public ICommand SearchCommand { get; set; }
        public MainPageViewModel()
        {
            SearchCommand = new Command(async (character) =>
            {
                IsBusy = true;
                var c = character as Character;
                if (c == null)
                    return;

                var url = $"http://www.amiiboapi.com/api/amiibo/?character={c.name}";
                var service = new HttpHelper<Amiibos>();
                var amiibos = await service.GetRestServiceDataAsync(url);
                Amiibos = new ObservableCollection<Amiibo>(amiibos.amiibo);
                IsBusy = false;
            });
        }
        public async Task LoadCharacters()
        {
            IsBusy = true;
            var url = "http://www.amiiboapi.com/api/character";
            var service = new HttpHelper<Characters>();
            var characters = await service.GetRestServiceDataAsync(url);
            Characters = new ObservableCollection<Character>(characters.amiibo);
            IsBusy = false;
        }
    }
}

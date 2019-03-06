using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism;

namespace Mvvm.ViewModels
{
    public class Prueva1ViewModel : Prism.Mvvm.BindableBase
    {
        public ObservableCollection<Item> Observables { get; set; }
        public Prism.Commands.DelegateCommand comando;

        public Prueva1ViewModel()
        {
            comando = new Prism.Commands.DelegateCommand(() =>
            {
                Observables.Add(new Item
                {
                    A = "primero",
                    B = "segundo"
                });
            });
            Observables = new ObservableCollection<Item>();
            Observables.CollectionChanged += Observables_CollectionChanged;
        }

        private void Observables_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {

        }
    }
}

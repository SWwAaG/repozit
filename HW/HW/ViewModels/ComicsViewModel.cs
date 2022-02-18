using System;
using System.Collections.Generic;
using System.Text;
using ComicsLibrary;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json;
using Xamarin.Forms;
using JetBrains.Annotations;

namespace HW.ViewModels
{
    public class ComicsViewModel : INotifyPropertyChanged
    {

        public ObservableCollection<string> SomeCollection { get; set; }
            = new ObservableCollection<string>();

        public ICommand SomeCommand => new Command(async value => { await LoadData(); });

        private ObservableCollection<Comics> _comics;

        public ObservableCollection<Comics> comics
        {
            get => _comics;
            set
            {
                _comics = value;
                OnPropertyChanged();
            }
        }

        public async Task LoadData()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("https://10.0.2.2:5000/api/Comics/ComicsList").ConfigureAwait(false);
            var json = await response.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<ObservableCollection<Comics>>(json);
            comics = list;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

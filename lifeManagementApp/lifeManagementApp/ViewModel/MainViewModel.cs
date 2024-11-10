using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using static System.Net.Mime.MediaTypeNames;

namespace lifeManagementApp.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        public MainViewModel()
        {
            Items = new ObservableCollection<string>();
            DoneItems = new ObservableCollection<string>();
        }

        [ObservableProperty]
        ObservableCollection<string> items;

        [ObservableProperty]
        ObservableCollection<string> doneItems;

        [ObservableProperty]
        string text;


        [RelayCommand]
        void Add()
        {
            if (string.IsNullOrWhiteSpace(Text))
                return;
            Items.Add(Text);
            Text = string.Empty;
        }

        [RelayCommand]
        void Delete(string s)
        {
            if (Items.Contains(s)) Items.Remove(s);
        }


        [RelayCommand]
        void MarkAsDone(string s)
        {
            if (Items.Contains(s))
            {
                Items.Remove(s);
                DoneItems.Add(s);
            }
        }
    }
}

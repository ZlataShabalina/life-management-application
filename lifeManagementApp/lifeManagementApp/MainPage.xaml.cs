using lifeManagementApp.ViewModel;
using Microsoft.Maui.Controls;

namespace lifeManagementApp
{
    public partial class MainPage : ContentPage
    {
        private readonly MainViewModel _viewModel;

        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
        }

        private async void WeatherClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Weather());
        }

        private async void TodoClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ToDo(_viewModel));
        }
    }
}

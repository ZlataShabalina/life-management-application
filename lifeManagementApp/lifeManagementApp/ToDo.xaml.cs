using lifeManagementApp.ViewModel;

namespace lifeManagementApp;

public partial class ToDo : ContentPage
{
    public ToDo()
    {
    }

    public ToDo(MainViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
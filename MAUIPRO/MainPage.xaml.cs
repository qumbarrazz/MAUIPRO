using MAUIPRO.Services;

namespace MAUIPRO
{
    public partial class MainPage : ContentPage
    {
        private readonly UserService _userService;

        public MainPage()
        {
            InitializeComponent();
            _userService = new UserService();
        }

        private async void OnCreateUserClicked(object sender, EventArgs e)
        {
            var user = new User
            {
                Name = NameEntry.Text,
                Age = int.Parse(AgeEntry.Text),
                Number = NumberEntry.Text
            };

            await _userService.CreateUserAsync(user);
            await DisplayAlert("Success", "User created successfully!", "OK");
        }

        private async void OnViewUsersClicked(object sender, EventArgs e)
        {
            var users = await _userService.GetUsersAsync();
            // Display or navigate to another page to view users
        }
    }

}

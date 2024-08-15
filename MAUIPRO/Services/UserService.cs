using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MAUIPRO.Services
{
    public class UserService
    {
        private readonly HttpClient _httpClient;

        public UserService()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7036/api/") };
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<User>>("Users");
        }

        public async Task<User> GetUserAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<User>($"Users/{id}");
        }

        public async Task CreateUserAsync(User user)
        {
            await _httpClient.PostAsJsonAsync("Users", user);
        }

        public async Task UpdateUserAsync(User user)
        {
            await _httpClient.PutAsJsonAsync($"Users/{user.Id}", user);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _httpClient.DeleteAsync($"Users/{id}");
        }
    }
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Number { get; set; }
    }
}

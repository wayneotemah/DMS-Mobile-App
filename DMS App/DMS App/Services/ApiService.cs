using DMS_App.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace DMS_App.Services
{
    public static class ApiService
        //handle all my api calls
    {
        public static async Task<bool> LoginStudent(string username,string password)
            //handles student login api
        {
            var login = new Login()
            {
                username = username,
                password = password
            };
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(login);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("https://ditams.herokuapp.com/login", content);
            if (!response.IsSuccessStatusCode) return false;
            var jsonResult = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Token>(jsonResult);
            Preferences.Set("accessToken", result.token);
            return true;
        }
    }
}

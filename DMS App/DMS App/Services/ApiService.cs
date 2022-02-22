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

        public static async Task<Studentaccount> GetStudentAccountInfo()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("token", Preferences.Get("accessToken",string.Empty));
            var response = await httpClient.GetStringAsync("https://ditams.herokuapp.com/student/"+Preferences.Get("Username",string.Empty)+"/");
            var result = JsonConvert.DeserializeObject<Studentaccount>(response);
            Preferences.Set("admission_number", result.admission_number);
            Preferences.Set("username", result.username);
            Preferences.Set("email", result.email);
            Preferences.Set("phone_number", result.phone_number);
            return result;

        }

    }
}

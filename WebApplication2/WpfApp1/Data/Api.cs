using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;

namespace WpfApp1.Data
{
    public static class Api
    {
        public static async Task<User?> Auth(string login, string password)
        {
            using (var client = new HttpClient())
            {
                var result = client.GetAsync($"http://localhost:5017/api/user/authenticate/{login},{password}").Result;
                return result.StatusCode == System.Net.HttpStatusCode.OK
                    ? JsonConvert.DeserializeObject<User>(await result.Content.ReadAsStringAsync())
                    : null;
            }
        }
        public static async Task<User?> Reg(string surname, string name, string patronymic, string login, string password)
        {
            using (var client = new HttpClient())
            {
                var result = client.GetAsync($"http://localhost:5017/api/user/register/{surname},{name},{patronymic},{login},{password}").Result;
                return result.StatusCode == System.Net.HttpStatusCode.OK
                    ? JsonConvert.DeserializeObject<User>(await result.Content.ReadAsStringAsync())
                    : null;
            }
        }
    }
}

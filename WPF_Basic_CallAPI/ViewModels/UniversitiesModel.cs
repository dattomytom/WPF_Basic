using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WPF_Basic_CallAPI.Models;

namespace WPF_Basic_CallAPI.ViewModels
{
    public class UniversitiesModel : ViewModelBase
    {
        public List<University> universities { get; private set; }
        public UniversitiesModel()
        {
            universities = new List<University>();
            LoadJson();
        }
        public void LoadJson()
        {
            //using( StreamReader r = new StreamReader("Data/world_universities_and_domains.json"))
            //{
            //    string json = r.ReadToEnd();
            //    DefaultContractResolver resolver = new DefaultContractResolver
            //    {
            //        NamingStrategy = new SnakeCaseNamingStrategy()
            //    };
            //    var options = new JsonSerializerSettings()
            //    {
            //        Formatting = Formatting.Indented,
            //        ContractResolver = resolver

            //    };
            //    universities = JsonConvert.DeserializeObject<List<University>>(json,options);
            //}
            HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("http://universities.hipolabs.com/search?country=United+States");
            HttpResponseMessage response = client.GetAsync("http://universities.hipolabs.com/search?country=United+States").Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                universities = System.Text.Json.JsonSerializer.Deserialize<List<University>>(result);
            }
        }

    }
}

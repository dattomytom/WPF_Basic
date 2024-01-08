using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WPF_Basic_CallAPI.Models
{
    
    public class University
    {

        [JsonPropertyName("domains")]
        public List<string> Domains { get; set; }


        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("alpha_two_code")]
        public string AlphaTwoCode { get; set; }

        [JsonPropertyName("web_pages")]
        public List<string> WebPages { get; set; }

        [JsonPropertyName("state_province")]
        public string StateProvinces { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

    }
}

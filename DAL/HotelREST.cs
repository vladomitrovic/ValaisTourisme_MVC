using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using DTO;

namespace DAL
{
    public class HotelREST
    {

        readonly static string baseUri = "http://localhost:57527/api/Hotel/";

        //Get all hotels
        public static List<Hotel> GetAll()
        {
            string uri = baseUri +"all";
            using (HttpClient httpClient = new HttpClient())
            {
                Task<String> response = httpClient.GetStringAsync(uri);
                return JsonConvert.DeserializeObject<List<Hotel>>(response.Result);
            }
        }

        //Get hotel by id
        public static Hotel Getid(int id)
        {
            string uri = baseUri +id;
            using (HttpClient httpClient = new HttpClient())
            {
                Task<String> response = httpClient.GetStringAsync(uri);
                return JsonConvert.DeserializeObject<Hotel>(response.Result);
            }
        }

    }
}

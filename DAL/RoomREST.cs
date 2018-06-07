using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Newtonsoft.Json;

namespace DAL
{
    public class RoomREST
    {
        readonly static string baseUri = "http://localhost:57527/api/Room/";

        public static Room Getid(int id)
        {
            string uri = baseUri + id;
            using (HttpClient httpClient = new HttpClient())
            {
                Task<String> response = httpClient.GetStringAsync(uri);
                return JsonConvert.DeserializeObject<Room>(response.Result);
            }
        }


        public static List<Room> GetSearch(String city, DateTime cin, DateTime cout)
        {
            string uri = baseUri + city+"/"+cin.ToString("yyyy-MM-dd")+"/"+cout.ToString("yyyy-MM-dd");
            using (HttpClient httpClient = new HttpClient())
            {
                Task<String> response = httpClient.GetStringAsync(uri);
                var temp = JsonConvert.DeserializeObject<List<Hotel>>(response.Result);
                return JsonConvert.DeserializeObject<List<Room>>(response.Result);
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using Newtonsoft.Json;

namespace DAL
{
    public class BookingREST
    {
        readonly static string baseUri = "http://localhost:57527/api/Booking/";

        //Get bookings by firstname and lastname
        public static List<Booking> GetBooking(String firstname, String lastname)
        {
            string uri = baseUri + firstname+"/"+lastname;
            using (HttpClient httpClient = new HttpClient())
            {
                Task<String> response = httpClient.GetStringAsync(uri);
                return JsonConvert.DeserializeObject<List<Booking>>(response.Result);
            }
        }

        //Book a room
        public static bool PostNewBooking(Booking b)
        {
            string uri = baseUri;
            using (HttpClient httpClient = new HttpClient())
            {
                string pro = JsonConvert.SerializeObject(b, new JsonSerializerSettings()
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                    Formatting = Formatting.Indented
                });
                StringContent frame = new StringContent(pro, Encoding.UTF8, "Application/json");
                Task<HttpResponseMessage> response = httpClient.PostAsync(uri, frame);
                return response.Result.IsSuccessStatusCode;
            }
        }


        public static bool DeleteBooking(int idBook)
        {
            string uri = baseUri+"DeleteBooking/"+idBook;
            using (HttpClient httpClient = new HttpClient())
            {

                httpClient.BaseAddress = new Uri("http://localhost:57527/");
                var response = httpClient.DeleteAsync("api/booking/"+idBook.ToString()).Result;

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                    return false;

            }
        }



    }
}

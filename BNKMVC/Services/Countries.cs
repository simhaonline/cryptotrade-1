//using RestSharp;
//using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using BNKMVC.Entities;
using RestSharp;
using RestSharp.Deserializers;

namespace BNKMVC.Services
{
    public class Countries
    {

        public bool PopulateCountries()
        {
            try
            {
                var client = new RestClient("https://restcountries.eu/rest/v2/");
                var request = new RestRequest("all", Method.GET);

                // string date = ConvertToTimestamp(datetime).ToString();
                //   request.AddParameter("fields", "name;alpha3code");

                //      request.AddHeader("contentType", "application/x-www-form-urlencoded");

                IRestResponse response = client.Execute(request);
                JsonDeserializer deserial = new JsonDeserializer();
                var obj = deserial.Deserialize<List<BNKMVC.Models.ViewModel.CountryViewModel>>(response);
                using (var db = new Entities.mbankEntities())
                {
                    foreach (var i in obj)
                    {
                        db.Countries.Add(new Country()
                        {
                            Alph3Code = i.alpha3Code,
                            Name = i.name,
                        });
                    }
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                string returnMessage = ex.Message;
                return false;
            }

        }
        public static void SetSSH_SSL_Allow()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }
    }


}
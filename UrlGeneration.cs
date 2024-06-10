using System;
using System.Collections.Generic;
using System.Text;

namespace Padelbooker
{
    public  class UrlGeneration
    {
        public static string playtomicUrl;

        public static string GenerateUrl()
        {
            string baseUrl = "https://playtomic.io/checkout/booking?";
            string locatie = "s=3e8f97c2-b984-4de8-9615-d4795b9dbff5";//Olympiade
            //string locatie = "s=3bcb5989-3c5c-4bc8-8911-315f185d2189";//Berchem

            //string veld = "~aa85ce64-ef0d-4e54-a399-0f106c6629b7~"; //olymp 3
            string veld = "~cf8106d5-a08b-404a-b999-adbcaa833432~";//olymp 4


            string datum = "2024-06-17";
            string uur = "T09%3A00%"; //2u erbij doen!
            string duur = "~60";
            string fullUrl = baseUrl + locatie + veld + datum + uur + duur;
            return fullUrl;
            //url was correct, maar er is iets mis met de site

        }
    }
}

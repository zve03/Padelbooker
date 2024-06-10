using System;
using System.Collections.Generic;
using System.Text;

namespace Padelbooker
{
    public  class UrlGeneration
    {
        public static string GeneratePaymentUrl(int adddays, string hour, string minutes, string duration)
        {
            string baseUrl = "https://playtomic.io/checkout/booking?";
            string locatie = "s=3e8f97c2-b984-4de8-9615-d4795b9dbff5";//Olympiade
            //string locatie = "s=3bcb5989-3c5c-4bc8-8911-315f185d2189";//Berchem

            //string veld = "~aa85ce64-ef0d-4e54-a399-0f106c6629b7~"; //olymp 3
            //string veld = "~cf8106d5-a08b-404a-b999-adbcaa833432~";//olymp 4
            //string veld = "~0374acf0-dca9-472d-9979-81529c2d3a2f~"; //geen idee waarom maar deze werkt manueel wel?
            //string veld = "~e079d971-f653-4c87-bcac-98f4090a1be6~"; // olymp 1
            string veld = "~1fa49a54-9dc4-4b28-8109-8f1b3eec1f28~";// olymp 2 PEAK

            string datum = DayNextWeek(adddays);
            string uur = "T"+hour+"%3A"+minutes; //2u erbij doen! geen % erachter? 07 en 00/30. 
            string duur = "~"+duration;// 60/90/120
            string fullUrl = baseUrl + locatie + veld + datum + uur + duur;
            return fullUrl;

        }
        public static string DayNextWeek(int adddays)
        {
            var x = DateTime.Today.AddDays(adddays);
            
            string y = NormalizeDateNumbers(x.Year) + "-" + NormalizeDateNumbers(x.Month) + "-" + NormalizeDateNumbers(x.Day);
            return y;
        }
        public static string NormalizeDateNumbers(int nr)
        {
            string outcome;
            if (nr> 9) { outcome = nr.ToString(); }
            else { outcome = "0" + nr.ToString(); }
            return outcome;
        }

    }
    
}

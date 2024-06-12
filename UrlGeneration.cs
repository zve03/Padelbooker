using System;
using System.Collections.Generic;
using System.Text;

namespace Padelbooker
{
    public  class UrlGeneration
    {
        public static string GeneratePaymentUrl(string location, int field,int adddays, string hour, string minutes, string duration)
        {
            string baseUrl = "https://playtomic.io/checkout/booking?";
            //string locatie = "s=3e8f97c2-b984-4de8-9615-d4795b9dbff5";//Olympiade
            //string locatie = "s=3bcb5989-3c5c-4bc8-8911-315f185d2189";//Berchem

            //string veld = "~aa85ce64-ef0d-4e54-a399-0f106c6629b7~"; //olymp 3
            //string veld = "~cf8106d5-a08b-404a-b999-adbcaa833432~";//olymp 4
            //string veld = "~0374acf0-dca9-472d-9979-81529c2d3a2f~"; //geen idee waarom maar deze werkt manueel wel?
            //string veld = "~e079d971-f653-4c87-bcac-98f4090a1be6~"; // olymp 1
            string locatieenveld = SelectLocationAndField(location, field);
            string datum = DayNextWeek(adddays);
            string uur = "T"+hour+"%3A"+minutes; //2u erbij doen! geen % erachter? 07 en 00/30. 
            string duur = "~"+duration;// 60/90/120
            string fullUrl = baseUrl + locatieenveld+ datum + uur + duur;
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
        public static string SelectLocationAndField(string location, int field)
        {
            //Dit zijn enkel de velden voor PEAK!

            string locatie;
            string veld = null;
            string locatieenveld;
            if (location == "Berchem")
            {
                locatie = "s=3bcb5989-3c5c-4bc8-8911-315f185d2189";
                switch (field)
                {
                    case 1:
                        veld = "~87fc6fd7-4007-46fc-a085-6ac224aca246~";
                        break;
                    case 2:
                        veld = "~b0c5c0f6-2a62-4d72-869c-2b01a1a0e1f0~";
                        break;
                    case 3:
                        veld = "~ac432500-f012-4716-810c-e3577212b9f5~";
                        break;
                }
            }
            else //Olympiade
            {
                locatie = "s=3e8f97c2-b984-4de8-9615-d4795b9dbff5";
                switch (field)
                {
                    case 1:
                        veld = "~e079d971-f653-4c87-bcac-98f4090a1be6~";
                        break;
                    case 2:
                        veld = "~1fa49a54-9dc4-4b28-8109-8f1b3eec1f28~";
                        break;
                    case 3:
                        veld = "~aa85ce64-ef0d-4e54-a399-0f106c6629b7~";
                        break;
                    case 4:
                        veld = "~0374acf0-dca9-472d-9979-81529c2d3a2f~";
                        break;
                    case 5:
                        veld = "~a082b4f3-173d-48c0-8e1f-3d437f183645~";
                        break;
                    case 6:
                        veld = "~bb23d939-ed35-47a2-9b2f-4ba8113706cd~";
                        break;
                }


            }

            locatieenveld = locatie + veld;
            return locatieenveld;
        }
                


    }
    
}

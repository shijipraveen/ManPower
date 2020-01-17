using System;

namespace ManPowerModel
{
    public class Nationality
    {

        public string CountryCode { get; set; }
        public string CountryName { get; set; }

        public Nationality()
        {

        }

        public Nationality(string CountryName, string CountryCode)
        {
            this.CountryName = CountryName;

            this.CountryCode = CountryCode;
        }


    }
}

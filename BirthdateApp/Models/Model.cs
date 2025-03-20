using System;

namespace BirthdateApp.Models
{
    public class Model
    {
        public DateTime BirthDate { get; set; }

        public int Age => CalculateAge();

        public string WesternZodiac => GetWesternZodiac();
        public string ChineseZodiac => GetChineseZodiac();

        private int CalculateAge()
        {
            DateTime today = DateTime.Today;
            int age = today.Year - BirthDate.Year;
            if (BirthDate > today.AddYears(-age)) age--;
            return age;
        }

        private string GetWesternZodiac()
        {
            int day = BirthDate.Day;
            int month = BirthDate.Month;

            return month switch
            {
                1 => day <= 19 ? "Capricorn" : "Aquarius",
                2 => day <= 18 ? "Aquarius" : "Pisces",
                3 => day <= 20 ? "Pisces" : "Aries",
                4 => day <= 19 ? "Aries" : "Taurus",
                5 => day <= 20 ? "Taurus" : "Gemini",
                6 => day <= 20 ? "Gemini" : "Cancer",
                7 => day <= 22 ? "Cancer" : "Leo",
                8 => day <= 22 ? "Leo" : "Virgo",
                9 => day <= 22 ? "Virgo" : "Libra",
                10 => day <= 22 ? "Libra" : "Scorpio",
                11 => day <= 21 ? "Scorpio" : "Sagittarius",
                12 => day <= 21 ? "Sagittarius" : "Capricorn",
                _ => throw new NotImplementedException()
            };
        }

        private string GetChineseZodiac()
        {
            string[] zodiacSigns = {
                "Monkey", "Rooster", "Dog", "Pig", "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat"
            };
            return zodiacSigns[BirthDate.Year % 12];
        }
    }
}

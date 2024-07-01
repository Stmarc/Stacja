using System;

namespace WeatherAppMVC.Models
{
    public class WeatherData
    {
        public int Id { get; set; }
        public string Stacja { get; set; }
        public DateTime DataPomiaru { get; set; }
        public string GodzinaPomiaru { get; set; }
        public float Temperatura { get; set; }
        public float PredkoscWiatru { get; set; }
        public string KierunekWiatru { get; set; }
        public float WilgotnoscWzgledna { get; set; }
        public float SumaOpadu { get; set; }
        public float Cisnienie { get; set; }
    }
}

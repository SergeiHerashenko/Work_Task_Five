using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace Task_Five
{
    class Program
    {
        static void Main(string[] args)
        {
            //Створюемо зміння для URL адреси
            string Url_Address_kieve = "http://api.openweathermap.org/data/2.5/weather?q=Kieve&units=metric&appid=6821107bc79f8a9e6cbd23c43a8f8338";
            string Url_Address_Odessa = "http://api.openweathermap.org/data/2.5/weather?q=Odessa&units=metric&appid=6821107bc79f8a9e6cbd23c43a8f8338";

            //Щоб зробити запит, створюемо об’єкти Request
            HttpWebRequest httpWebRequestKieve = (HttpWebRequest)WebRequest.Create(Url_Address_kieve);
            HttpWebRequest httpWebRequestOdessa = (HttpWebRequest)WebRequest.Create(Url_Address_Odessa);

            //Створюємо Response та считуємо всі дання з Request
            HttpWebResponse httpWebResponseKieve = (HttpWebResponse)httpWebRequestKieve.GetResponse();
            HttpWebResponse httpWebResponseOdessa = (HttpWebResponse)httpWebRequestOdessa.GetResponse();


            string responseKieve;
            string responseOdessa;

            using (StreamReader streamReader = new StreamReader(httpWebResponseKieve.GetResponseStream()))
            {
                responseKieve = streamReader.ReadToEnd();
            }
            using (StreamReader streamReader = new StreamReader(httpWebResponseOdessa.GetResponseStream()))
            {
                responseOdessa = streamReader.ReadToEnd();
            }

            //Використовуємо Json конвектор для преобразовния в строку 
            WeatherResponse weatherResponseKiev = JsonConvert.DeserializeObject<WeatherResponse>(responseKieve);
            WeatherResponse weatherResponseOdessa = JsonConvert.DeserializeObject<WeatherResponse>(responseOdessa);

            Console.WriteLine("Temperature in {0}: {1} Celsius", weatherResponseKiev.Name, weatherResponseKiev.Main.Temp);
            Console.WriteLine("Temperature in {0}: {1} Celsius", weatherResponseOdessa.Name, weatherResponseOdessa.Main.Temp);

            Console.ReadLine();
        }
    }
}

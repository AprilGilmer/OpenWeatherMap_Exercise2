using Newtonsoft.Json.Linq;


namespace OpenWeatherMap_Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {

            var client = new HttpClient();

            var key = "1e6f1692cc86ea36c2e16107939b934b";
            //var city = "Orange Beach";

            //var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={key}&units=imperial";
            //var response = client.GetStringAsync(weatherURL).Result;
            ////Console.WriteLine(response);

            //JObject formattedResponse = JObject.Parse(response);
            //var temp = formattedResponse["main"]["temp"];
            //Console.WriteLine(temp);

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Please enter the city name: ");
                var city_name = Console.ReadLine();
                Console.WriteLine();

                var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?q={city_name}&appid={key}&units=imperial";
                try
                {
                    var response = client.GetStringAsync(weatherURL).Result;
                    var formattedResponse = JObject.Parse(response).GetValue("main").ToString();
                    var temp = JObject.Parse(formattedResponse).GetValue("temp");
                    Console.WriteLine($"The current Temperature is {temp} degress Fahrenheit");

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message); ;
                }

                AddSpaces(2);
                Console.WriteLine("Would you like to exit?");
                var userInput = Console.ReadLine();
                AddSpaces(2);

                if (userInput.ToLower().Trim() == "yes")
                {
                    break;
                }

            }
        }

        static void AddSpaces(int numberOfSpaces)
        {
            while (numberOfSpaces != 0)
            {
                Console.WriteLine();
                numberOfSpaces--;
            }
        }
    }
}

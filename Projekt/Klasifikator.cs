using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Projekt
{
    public class StringTable
    {
        public string[] ColumnNames { get; set; }
        public string[,] Values { get; set; }
    }
    public class Klasifikator
    {
        private static string[,] MushroomValues;

        public void setValues(string[,] mMushroomValues)
        {
            MushroomValues = mMushroomValues;
        }

        public async Task <string> InvokeRequestResponseService()
        {
            using (var client = new HttpClient())
            {
                var scoreRequest = new
                {

                    Inputs = new Dictionary<string, StringTable>() {
                        {
                            "input1",
                            new StringTable()
                            {
                                ColumnNames = new string[] {"class", "cap-shape", "cap-surface", "cap-color", "bruises", "odor", "gill-attachment", "gill-spacing", "gill-size", "gill-color", "stalk-shape", "stalk-root", "stalk-surface-above-ring", "stalk-surface-below-ring", "stalk-color-above-ring", "stalk-color-below-ring", "veil-type", "veil-color", "ring-number", "ring-type", "spore-print-color", "population", "habitat"},
                                Values = MushroomValues
                            }
                        },
                    },
                    GlobalParameters = new Dictionary<string, string>()
                    {
                    }
                };
                const string apiKey = "Elwf+CrW0ocqHOWdAYS6bn04b0E9XAoPXEn6zXnhJg7ZteWqfO0K7ye+u7yHeSuRdz/zmZam9QZdY7OWKhok9g==";
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
                client.BaseAddress = new Uri("https://ussouthcentral.services.azureml.net/workspaces/ca1a21a65dac4f3c8fe5985652d97f6d/services/cbd84fe921e444cc92986510c006209c/execute?api-version=2.0&details=true");
                


                HttpResponseMessage response = await client.PostAsJsonAsync("", scoreRequest);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Result: {0}", result);
                    return result;
                }
                else
                {

                    string responseContent = await response.Content.ReadAsStringAsync();
                    return responseContent;
                }
            }
        }

    }
}
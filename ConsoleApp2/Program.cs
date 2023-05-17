using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json; //burada kütüphane hatası veriyor

class Program
{
    static async Task Main(string[] args)
    {
        await GetApiData();
    }

    static async Task GetApiData()
    {
        string apiUrl = "https://www.usom.gov.tr"; // API URL'si

        using (HttpClient client = new HttpClient())
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string jsonData = await response.Content.ReadAsStringAsync();

                    // JSON verilerini C# nesnelerine dönüştürme
                    var data = JsonConvert.DeserializeObject<DataModel>(jsonData);

                    // Verileri işleme veya gösterme
                    Console.WriteLine("API'den gelen veri: " + data.Property);
                }
                else
                {
                    Console.WriteLine("API isteği başarısız oldu. Hata kodu: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("API bağlantısı sırasında bir hata oluştu: " + ex.Message);
            }
        }
    }
}

class DataModel
{
    public string Property { get; set; } // API'den gelen veri modeli 
}

using Crypto_II.Data;
using Crypto_II.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Crypto_II.Services
{
    public class CoinService : ICoinService
    {
        public async Task getCoinData(DatabaseContext context)
        {
            Console.WriteLine("Preparing to get coin price");
            HttpClient client = new HttpClient();

            try
            {
                var UrlEndpoint = "https://coinlib.io/api/v1/coin";
                var ApiKey = "8c18a5652d352b02";
                var UrlWithAPIKey = $"{UrlEndpoint}?key={ApiKey}";
                // Environment.GetEnvironmentVariable("UrlEndpoint");
                //var UrlEndpoint = Environment.GetEnvironmentVariable("UrlEndpoint");
                var CoinCodesCSV = "BTC"; //Environment.GetEnvironmentVariable("CoinCodesCSV");
                var CoinCodes = CoinCodesCSV.Split(",");

                foreach (var coin in CoinCodes)
                {
                    Console.WriteLine($"Preparing to get price for {coin}");
                    var path = $"{UrlWithAPIKey}&symbol={coin}";
                    Console.WriteLine($"Calling {path}");
                    HttpResponseMessage response = await client.GetAsync(path);
                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Received data for {coin}");
                        var coinPriceStr = await response.Content.ReadAsStringAsync();
                        CoinPrice coinPrice = JsonSerializer.Deserialize<CoinPrice>(coinPriceStr)!;
                        Console.WriteLine("Saving data");
                        Console.WriteLine($"Coin [{coin}], Price={coinPrice.price}, Open={coinPrice.open}, High={coinPrice.high_24h}, Low={coinPrice.low_24h},");
                        await saveCoinData(context, coinPrice.last_updated_timestamp, coin, Convert.ToDecimal(coinPrice.price));
                        Console.WriteLine("Data saved");
                    }
                    else
                    {
                        Console.WriteLine($"Get request failed.{response.StatusCode} {response.ReasonPhrase}");
                    }
                }

            }
            catch (Exception ex)
            {
                //error message log for retrieve coin price fail
                Console.WriteLine($"Get coin price failed. {ex}");
            }
            Console.WriteLine("Completed getting coin prices");

        }
        public async Task saveCoinData(DatabaseContext _context, long timestamp, string coin, decimal price)
        {
            try
            {
                CoinData coinData = new CoinData()
                {
                    Price = price,
                    Coin = coin,
                    TimeStamp = timestamp
                };
                _context.CoinDatas.Add(coinData);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

    }

}

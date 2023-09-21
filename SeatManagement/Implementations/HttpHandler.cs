using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagement.Implementations
{
    public class HttpHandler
    {
        public async Task<string> HttpGetAsync(string url)
        {
            try
            {
                string requestUrl = ApiConfig.ApiBaseUrl + (url);
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(requestUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();
                        return json;
                    }
                    else
                    {
                        return null;
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
        public async Task<string> HttpPostAsync(string json, string url)
        {
            try
            {
                string postUrl = ApiConfig.ApiBaseUrl + (url);
                using (var client = new HttpClient())
                {
                    var content = new StringContent(json, Encoding.UTF8, "application/JSON");
                    var response = await client.PostAsync(postUrl, content);
                    string responseContent = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        if (!int.TryParse(responseContent, out _))
                            Console.WriteLine($"\n {responseContent}");
                       
                        return responseContent;
                        
                        
                        
                    }
                    else
                    {
                        Console.WriteLine($"\n Error:{response.StatusCode},{responseContent}");
                        return null;
                        
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
    }
}

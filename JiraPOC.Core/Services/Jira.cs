using Flurl;
using Flurl.Http;
using JiraPOC.Core.Models.Payloads;
using JiraPOC.Core.Models.Response;
using System.Text.Json;

namespace JiraPOC.Services
{
    public static class Jira 
    {
        public static async Task<Issue?> CreateNewTicket(string url, string token, Ticket payload)
        {
            try
            {
                Console.WriteLine("Starting creation of a new ticket");
                var json = JsonSerializer.Serialize(payload);
                url = url + "/rest/api/2/issue/";
                Console.WriteLine($"[POST]: {url}");
                var result = await url.WithOAuthBearerToken(token).PostJsonAsync(payload).ReceiveJson<Issue>();
                Console.WriteLine($"The ticket was created, ticket number: {result.key}");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error ocurred: {ex.Message}");
                return null;
            }

        }


        public static async Task GetTicket(string url, string token, string ticketNumber)
        {
            url = $"{url}/rest/api/2/issue/{ticketNumber}";
            var person = await url.WithOAuthBearerToken(token).GetJsonAsync<object>();
            var res = JsonSerializer.Serialize(person);
            Console.WriteLine(res);
        }

        public static async Task<object?> UpdateTicket(string url, string token, string ticketNumber, Ticket payload)
        {
            try
            {
                Console.WriteLine("Starting creation of a new ticket");
                url = $"{url}/rest/api/2/issue/{ticketNumber}";
                Console.WriteLine($"[POST]: {url}");
                var result = await url.WithOAuthBearerToken(token).PutJsonAsync(payload).ReceiveJson<object>();
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error ocurred: {ex.Message}");
                return null;
            }
        }

        public static async Task<object?> CreateNewComment(string url, string token, string ticketNumber, Comment payload)
        {
            try
            {
                Console.WriteLine("Starting creation of a new ticket");
                url = url + $"/rest/api/2/issue/{ticketNumber}/comment";
                Console.WriteLine($"[POST]: {url}");
                var result = await url.WithOAuthBearerToken(token).PostJsonAsync(payload).ReceiveJson<object>();
                Console.WriteLine("The request was sucessfully completed");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error ocurred: {ex.Message}");
                return null;
            }

        }


        public static async Task<object?> CreateNewAttchament(string url, string token, string ticketNumber, List<string> paths)
        {
            try
            {
                Console.WriteLine("Starting creation of a new ticket");
                url = url + $"/rest/api/2/issue/{ticketNumber}/attachments";
                Console.WriteLine($"[POST]: {url}");
                var result = await url.WithOAuthBearerToken(token)
                    .WithHeader("Accept", "application/json")
                    .WithHeader("X-Atlassian-Token", "no-check")
                    .PostMultipartAsync(_ =>
                {
                    paths.ForEach(p => _.AddFile("file", p));
                });

                Console.WriteLine("The request was sucessfully completed");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error ocurred: {ex.Message}");
                return null;
            }

        }
    }
}

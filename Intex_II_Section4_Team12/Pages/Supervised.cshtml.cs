using Intex_II_Section4_Team12.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Build.Framework;
using Newtonsoft.Json;

namespace Intex_II_Section4_Team12.Pages
{
    public class SupervisedModel : PageModel
    {
        private MyApiRequestData ApiData { get; set; }
        public string? JsonData { get; set; }
        public SupervisedModel(MyApiRequestData temp)
        {
            ApiData = temp;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                //Age at Death Dummy Variables
                if (ApiData.AgeAtDeath == "Adult")
                {
                    ApiData.AgeAtDeath_adult = 1;
                    ApiData.AgeAtDeath_child = 0;
                    ApiData.AgeAtDeath_infant = 0;
                    ApiData.AgeAtDeath_other = 0;
                }
                else if (ApiData.AgeAtDeath == "Child")
                {
                    ApiData.AgeAtDeath_adult = 0;
                    ApiData.AgeAtDeath_child = 1;
                    ApiData.AgeAtDeath_infant = 0;
                    ApiData.AgeAtDeath_other = 0;
                }
                else if (ApiData.AgeAtDeath == "Infant")
                {
                    ApiData.AgeAtDeath_adult = 0;
                    ApiData.AgeAtDeath_child = 0;
                    ApiData.AgeAtDeath_infant = 1;
                    ApiData.AgeAtDeath_other = 0;
                }
                else if (ApiData.AgeAtDeath == "Other")
                {
                    ApiData.AgeAtDeath_adult = 0;
                    ApiData.AgeAtDeath_child = 0;
                    ApiData.AgeAtDeath_infant = 0;
                    ApiData.AgeAtDeath_other = 1;
                }

                //Wrappings Dummy Variables
                if (ApiData.Wrapping == "Full")
                {
                    ApiData.Wrapping_full = 1;
                    ApiData.Wrapping_partial = 0;
                    ApiData.Wrapping_none = 0;
                }
                else if (ApiData.Wrapping == "Partial")
                {
                    ApiData.Wrapping_full = 0;
                    ApiData.Wrapping_partial = 1;
                    ApiData.Wrapping_none = 0;
                }
                else if (ApiData.Wrapping == "Partial")
                {
                    ApiData.Wrapping_full = 0;
                    ApiData.Wrapping_partial = 0;
                    ApiData.Wrapping_none = 1;
                }
                // Convert the JSON request data to a JSON string
                var requestDataJson = JsonConvert.SerializeObject(ApiData);

                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync("https://example.com/api/data");
                    var content = await response.Content.ReadAsStringAsync();
                    JsonData = content;
                }
                return Page();
            }
            else
            {
                return Page();
            }
        }
    }
}

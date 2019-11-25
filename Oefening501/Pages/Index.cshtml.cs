using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Oefening501.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public Dictionary<string, int> dict { get; set; } = new Dictionary<string, int>() { { "aap", 7 }, { "beer", 25 } };

        public string stringFromForm { get; set; } = "";
        public string origstringFromForm { get; set; } = "";

        public string renderAnimal(string animal, int n)
        {
            string classname = n < 10 ? "class= red" : "";
            return classname;
        }

        private void addStringsInDict(Dictionary<string, int> dict, string stringsFromForm)
        {
            foreach (string s in stringsFromForm.Split(" ", StringSplitOptions.RemoveEmptyEntries))
            {
                if (!dict.ContainsKey(s))
                    dict[s] = 0;
                dict[s]++;
            }
        }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            //uitlezen input
            stringFromForm = Request.Form["values"];
            origstringFromForm = $"{Request.Form["originalValues"]}";

            //toevoegen nieuw item
            addStringsInDict(dict, origstringFromForm);
            addStringsInDict(dict, stringFromForm);
        }
    }
}
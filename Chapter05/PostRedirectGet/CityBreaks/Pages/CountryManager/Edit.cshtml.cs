using CityBreaks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CityBreaks.Pages.CountryManager
{
    public class EditModel : PageModel
    {
        private readonly ILogger<EditModel> _logger;

        [BindProperty]
        public List<InputModel> Inputs { get; set; }
        public List<Country> Countries { get; set; } = new List<Country>();

        public EditModel(ILogger<EditModel> logger)
        {
            _logger = logger;
            _logger.LogInformation("EditModel.ctor");
        }
        public void OnGet()
        {
            _logger.LogInformation("OnGet");
            Inputs = new List<InputModel> {
                new InputModel{ Id = 840, CountryCode = "us", CountryName ="United States" },
                new InputModel{ Id = 826, CountryCode = "en", CountryName = "Great Britain" },
                new InputModel{ Id = 250, CountryCode = "fr", CountryName = "France" }
            };
        }

        public void OnPost()
        {
            _logger.LogInformation("OnPost");
            Countries = Inputs
                .Where(x => !string.IsNullOrWhiteSpace(x.CountryCode))
                .Select(x => new Country
                {
                    Id = x.Id,
                    CountryCode = x.CountryCode,
                    CountryName = x.CountryName
                }).ToList();
        }

        public class InputModel
        {
            public int Id { get; set; }
            public string CountryName { get; set; }
            public string CountryCode { get; set; }

        }
    }
}
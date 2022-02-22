using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using PizzaApp.Data;

namespace PizzaApp.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        private DataContext dataContext;

        public PrivacyModel(ILogger<PrivacyModel> logger, DataContext dataContext)
        {
            _logger = logger;
            this.dataContext = dataContext;
        }

        public void OnGet()
        {
            // var pizza = new Pizza() {name = "PizzaTest", price = 5};
            // dataContext.Pizzas.Add(pizza);
            // dataContext.SaveChanges();
        }
    }
}
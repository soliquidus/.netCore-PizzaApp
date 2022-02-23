using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PizzaApp.Models;

namespace PizzaApp.Pages
{
    public class PizzaMenu : PageModel
    {
        private readonly PizzaApp.Data.DataContext _context;

        public PizzaMenu(PizzaApp.Data.DataContext context)
        {
            _context = context;
        }

        public IList<Pizza> Pizza { get;set; }

        public async Task OnGetAsync()
        {
            Pizza = await _context.Pizzas.ToListAsync();
            Pizza = Pizza.OrderBy(p => p.Price).ToList();
        }
    }
}
using System.ComponentModel.DataAnnotations;

namespace PizzaApp.Models
{
    public class Pizza
    {
        public int PizzaId { get; set; }
        public string Name { get; set; }
        [Display(Name = "Price (€)")]
        public float Price { get; set; }
        public bool Vegetarian { get; set; }
        public string Ingredients { get; set; }
    }
}
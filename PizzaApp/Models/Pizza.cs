using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace PizzaApp.Models
{
    public class Pizza
    {
        [JsonIgnore] public int PizzaId { get; set; }
        public string Name { get; set; }
        [Display(Name = "Price (€)")] public float Price { get; set; }
        public bool Vegetarian { get; set; }
        [JsonIgnore]
        public string Ingredients { get; set; }
        
        [NotMapped]
        [JsonPropertyName("Ingredients")]
        public string[] ingredientsList
        {
            get { return string.IsNullOrEmpty(Ingredients) ? null : Ingredients.Split(", "); }
        }
    }
}
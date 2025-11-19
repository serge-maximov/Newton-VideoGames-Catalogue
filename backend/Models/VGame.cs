using System.ComponentModel.DataAnnotations;
namespace Newton_VideoGames_Catalogue.Models
{
    public class VGame
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Genre {  get; set; } = string.Empty;
        public int ReleaseYear { get; set; }
        public string Platform { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Rating {  get; set; } = string.Empty;
        public decimal Price { get; set; }

    }
}

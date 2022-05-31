using System.ComponentModel.DataAnnotations;

namespace Test.ApriCode.VideoGames.Models
{
    public class CreateGames
    {
        [Required]
        public int GameId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string DeveloperStudio { get; set; }

        [Required]
        public int DeveloperStudioId { get; set; }

        [Required]
        public string Genre { get; set; }
    }
}

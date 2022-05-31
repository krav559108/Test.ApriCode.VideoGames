using System.ComponentModel.DataAnnotations;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Test.ApriCode.VideoGames.Models
{
    public class GamesList
    {
        [Key]
        public int GameId { get; set; }


        public string Title { get; set; }


        public string DeveloperStudio { get; set; }

        
        public int DeveloperStudioId { get; set; }


        public string Genre { get; set; }
    }
}


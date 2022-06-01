using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Test.ApriCode.VideoGames.Models
{
    public class GamesList
    {
        [Key]
        public int GameId { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public string Title { get; set; }


        public string DeveloperStudio { get; set; }

        
        public int DeveloperStudioId { get; set; }


        public string Genre { get; set; }
    }
}


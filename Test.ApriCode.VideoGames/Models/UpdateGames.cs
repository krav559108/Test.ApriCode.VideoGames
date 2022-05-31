using System.ComponentModel.DataAnnotations;


namespace Test.ApriCode.VideoGames.Models
{
	public class UpdateGames
	{
        
        [Required]
        public int GameId { get; set; }

            
        public string Title { get; set; }


        public string DeveloperStudio { get; set; }


        public int DeveloperStudioId { get; set; }


        public string Genre { get; set; }

    }
}


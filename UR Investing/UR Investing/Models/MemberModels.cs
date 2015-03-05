using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
using System.Web.Mvc;

namespace UR_Investing.Models
{
    public class Member
    {
        [Key]
        [Required]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string name { get; set; }

        [Display(Name = "Picture")]
        [FileExtensions(ErrorMessage = "Please enter a valid file name with the extension \".png, .jpg, .jpeg, or .gif\"", Extensions = ".png,.jpg,.jpeg,.gif")]
        public string picturePath { get; set; }

       
        [Display(Name = "Biography")]
        [DataType(DataType.MultilineText)]
        public string biography { get; set; }

        [ForeignKey("Team")]
        [Display (Name = "Team")]
        public string teamName { get; set; }

        [ForeignKey("Position")]
        [Display (Name = "Position")]
        public string positionName { get; set; }

        [Display (Name = "Resume")]
        public string resumePath { get; set; }

        [Display(Name = "LinkedIn")]
        public string linkedIn { get; set; }

        public virtual Team Team { get; set; }
        public virtual Position Position { get; set; }
    }

    public class Team
    {
        [Key]
        [Required]
        [Display(Name = "Team")]
        [Index(IsUnique = true)]
        [Remote("doesTeamExist", "Teams", HttpMethod = "POST", ErrorMessage = "Team already exists. Please enter a different one.")]
        public string name { get; set; }

        [Display(Name = "Description")]
        public string description { get; set; }

        [Display(Name = "Rank")]
        public int? rank { get; set; }
    }

    public class Position
    {
        [Key]
        [Required]
        [Display(Name = "Position")]
        [Index(IsUnique = true)]
        [Remote("doesPositionExist", "Positions", HttpMethod = "POST", ErrorMessage = "Position already exists. Please enter a different one.")]
        public string name { get; set; }

        [Display(Name = "Description")]
        public string description { get; set; }

        [Display(Name = "Rank")]
        public int? rank { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace UR_Investing.Models
{
    public class Member
    {
        [Key]
        [Required]
        public int ID { get; set; }

        [Required]
        public string name { get; set; }

        [DataType(DataType.ImageUrl)]
        [FileExtensions(ErrorMessage = "Please enter a valid file name with the extension \".png, .jpg, .jpeg, or .gif\"", Extensions = ".png,.jpg,.jpeg,.gif")]
        public string picturePath { get; set; }

        [DataType(DataType.MultilineText)]
        public string biography { get; set; }

        public string resumePath { get; set; }
    }
}
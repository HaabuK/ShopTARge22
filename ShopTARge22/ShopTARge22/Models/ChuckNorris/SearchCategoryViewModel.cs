using System.ComponentModel.DataAnnotations;

namespace ShopTARge22.Models.Norris
{
    public class SearchCategoryViewModel
    {
        [Required(ErrorMessage = "You must enter a category name!")]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage = "Only text allowed")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Enter a category name greater than 2 and lesser than 20 characters!")]
        [Display(Name = "Category Name")]
        public string categories { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace CurlyQueens.ViewModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }

        public decimal Price { get; set; }

        [Display(Name = "Product Image")]
        public IFormFile? ImageFile { get; set; }  // <-- added to receive uploaded file

        // path that will be saved after upload
        public string ImageUrl { get; set; }
        public string CategoryName { get; set; }

    }
}

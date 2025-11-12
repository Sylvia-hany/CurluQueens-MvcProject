using System.ComponentModel.DataAnnotations;

namespace CurlyQueens.ViewModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; } 
        public string Description { get; set; } 

        public decimal Price { get; set; }

        //// الصورة اللي المستخدم هيختارها
        //[Display(Name = "Product Image")]
        //public IFormFile ImageFile { get; set; }

        // دي هتتحفظ بعد الرفع (المسار فقط
        public string ImageUrl { get; set; } 
        public string CategoryName { get; set; } 
        
    }
}

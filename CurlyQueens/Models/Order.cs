namespace CurlyQueens.Models
{
    //final checkout order model
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal TotalAmount { get; set; }


        //34an hst5dm Identity
        public String UserId { get; set; }
       

        public ICollection<OrderItem>? OrderItems { get; set; }
    }
}

namespace CurlyQueens.Models
{
    public class Cart
    {
        public int Id { get; set; }

        //34an hst5dm Identity
        public string UserId { get; set; }

        public ICollection<CartItem>? CartItems { get; set; }
    }
}

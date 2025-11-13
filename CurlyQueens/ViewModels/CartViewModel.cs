namespace CurlyQueens.ViewModels
{
    public class CartViewModel
    {
        public List<CartItemViewModel> Items { get; set; } = new List<CartItemViewModel>();

        // ÍÓÇÈ ÇáÅÌãÇáí Çáßáí ááÓáÉ
        public decimal GetTotal()
        {
            return Items.Sum(item => item.SubTotal);
        }

        // ÚÏÏ ÇáãäÊÌÇÊ Ýí ÇáÓáÉ
        public int GetItemCount()
        {
            return Items.Sum(item => item.Quantity);
        }
    }
}

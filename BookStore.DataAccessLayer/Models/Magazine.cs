namespace BookStore.DataAccessLayer.Models
{
    public class Magazine:BaseModel
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
    }
}


{
    public class CheckoutAddRequest
    {
        [Required]
        public string Image { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Total { get; set; }

    }
}

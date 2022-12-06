namespace FreelanceDJ.Models.DjAccount
{
    public class AddDjAccount
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Email { get; set; } = null!;
        public long Phone { get; set; } 
        public int Price { get; set; }
    }
}

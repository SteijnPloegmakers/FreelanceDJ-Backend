namespace FreelanceDJ.Models.DjAccount
{
    public class DjAccount
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public int Price { get; set; }
    }
}

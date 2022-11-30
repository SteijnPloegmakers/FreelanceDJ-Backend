using FreelanceDJ.Models.DjAccount;

namespace FreelanceDJ.Data.Repos
{
    public interface IFreelanceDJRepo
    {
        Task<List<DjAccount>> GetAllDjAccounts();
    }
}

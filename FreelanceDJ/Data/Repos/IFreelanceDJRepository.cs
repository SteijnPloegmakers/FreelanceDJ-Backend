using FreelanceDJ.Models.DjAccount;

namespace FreelanceDJ.Data.Repos
{
    public interface IFreelanceDJRepository
    {
        Task<List<DjAccount>> GetAllDjAccounts();
    }
}

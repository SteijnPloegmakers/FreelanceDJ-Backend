using FreelanceDJ.Models.DjAccount;

namespace FreelanceDJ.Data.Repos
{
    public interface IFreelanceDJRepository
    {
        Task<List<DjAccount>> GetAllDjAccounts();
        Task<DjAccount> GetSpecificDjAccount(Guid id);
        Task<AddDjAccount> AddNewDjAccount(AddDjAccount addDjAccount);
        Task<UpdateDjAccount> UpdateDjAccount(Guid id, UpdateDjAccount updateDjAccount);
        Task<DjAccount> DeleteSpecificDjAccount(Guid id);
    }
}

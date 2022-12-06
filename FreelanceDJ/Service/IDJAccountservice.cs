using FreelanceDJ.Models.DjAccount;

namespace FreelanceDJ.Service
{
    public interface IDJAccountservice
    {
        Task<List<DjAccount>> GetAllDjs();
        Task<DjAccount> GetDjAccountById(Guid id);
        Task<AddDjAccount> AddDjAccount(AddDjAccount addDjAccount);
        Task<UpdateDjAccount> UpdateDjAccount(Guid id, UpdateDjAccount updateDjAccount);
        Task<DjAccount> DeleteDjAccountById(Guid id);
    }
}

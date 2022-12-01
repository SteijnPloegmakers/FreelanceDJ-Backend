using FreelanceDJ.Models.DjAccount;

namespace FreelanceDJ.Service
{
    public interface IDJAccountservice
    {
        Task<List<DjAccount>> GetAllDjs();
    }
}

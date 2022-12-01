using Microsoft.EntityFrameworkCore;
using FreelanceDJ.Data;
using FreelanceDJ.Models.DjAccount;
using FreelanceDJ.Data.Repos;

namespace FreelanceDJ.Service
{
    public class DjAccountService : IDJAccountservice
    {
        private readonly IFreelanceDJRepository _freelanceDJRepository;

        public DjAccountService(IFreelanceDJRepository freelanceDJRepository)
        {
            _freelanceDJRepository = freelanceDJRepository;
        }

        public async Task<List<DjAccount>> GetAllDjs()
        {
            var djs = await _freelanceDJRepository.GetAllDjAccounts();
            return djs.OrderBy(x => x.Name).ToList();
        }
    }
}

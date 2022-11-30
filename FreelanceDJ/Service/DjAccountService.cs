using Microsoft.EntityFrameworkCore;
using FreelanceDJ.Data;
using FreelanceDJ.Models.DjAccount;
using FreelanceDJ.Data.Repos;

namespace FreelanceDJ.Service
{
    public class DjAccountService : IDJAccountservice
    {
        private readonly IFreelanceDJRepo _freelanceDJRepo;

        public DjAccountService(IFreelanceDJRepo freelanceDJRepo)
        {
            _freelanceDJRepo = freelanceDJRepo;
        }

        public async Task<List<DjAccount>> GetAllDjs()
        {
            var djs = await _freelanceDJRepo.GetAllDjAccounts();
            return djs.OrderBy(x => x.Name).ToList();
        }
    }
}

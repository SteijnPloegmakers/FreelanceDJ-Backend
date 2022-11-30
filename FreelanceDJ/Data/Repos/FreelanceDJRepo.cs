using FreelanceDJ.Models.DjAccount;
using Microsoft.EntityFrameworkCore;

namespace FreelanceDJ.Data.Repos
{
    public class FreelanceDJRepo : IFreelanceDJRepo
    {
        private readonly DataContext _dataContext;

        public FreelanceDJRepo(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<DjAccount>> GetAllDjAccounts()
        {
            return await _dataContext.DjAccounts.ToListAsync();
        }
    }
}

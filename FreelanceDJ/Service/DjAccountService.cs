using Microsoft.EntityFrameworkCore;
using FreelanceDJ.Data;


namespace FreelanceDJ.Service
{
    public class DjAccountService
    {
        private readonly DbContext _dbContext;

        public DjAccountService(DjAccountData dbContext)
        {
            this._dbContext = dbContext;
        }

        public GetAllDjAccounts()
        {
            _dbContext.DjAccounts
        }
    }
}

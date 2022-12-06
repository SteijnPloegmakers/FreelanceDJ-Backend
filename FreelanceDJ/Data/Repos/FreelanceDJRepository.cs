using FreelanceDJ.Models.DjAccount;
using Microsoft.EntityFrameworkCore;

namespace FreelanceDJ.Data.Repos
{
    public class FreelanceDJRepository : IFreelanceDJRepository
    {
        private readonly DataContext _dataContext;

        public FreelanceDJRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<DjAccount>> GetAllDjAccounts()
        {
            return await _dataContext.DjAccounts.ToListAsync();
        }

        public async Task<DjAccount> GetSpecificDjAccount(Guid id)
        {
            return await _dataContext.DjAccounts.FirstAsync(x => x.Id == id);
        }

        public async Task<AddDjAccount> AddNewDjAccount(AddDjAccount addDjAccount)
        {
            var djaccount = new DjAccount
            {
                Id = Guid.NewGuid(),
                Name = addDjAccount.Name,
                Description = addDjAccount.Description,
                Email = addDjAccount.Email,
                Phone = addDjAccount.Phone,
                Price = addDjAccount.Price
            };

            await _dataContext.DjAccounts.AddAsync(djaccount);
            await _dataContext.SaveChangesAsync();

            return addDjAccount;
        }

        public async Task<UpdateDjAccount> UpdateDjAccount(Guid id, UpdateDjAccount updateDjAccount)
        {
            var djaccount = await _dataContext.DjAccounts.FindAsync(id);
            if (djaccount != null)
            {
                djaccount.Name = updateDjAccount.Name;
                djaccount.Description = updateDjAccount.Description;
                djaccount.Email = updateDjAccount.Email;
                djaccount.Phone = updateDjAccount.Phone;
                djaccount.Price = updateDjAccount.Price;

                await _dataContext.SaveChangesAsync();
            }

            return updateDjAccount;
        }

        public async Task<DjAccount> DeleteSpecificDjAccount(Guid id)
        {
            var djaccount = await _dataContext.DjAccounts.FirstAsync(x => x.Id == id);
            _dataContext.Remove(djaccount);
            await _dataContext.SaveChangesAsync();
            return djaccount;
        }
    }
}

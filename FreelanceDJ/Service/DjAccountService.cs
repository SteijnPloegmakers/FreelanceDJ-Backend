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
            return await _freelanceDJRepository.GetAllDjAccounts();
        }

        public async Task<DjAccount> GetDjAccountById(Guid id)
        {
            return await _freelanceDJRepository.GetSpecificDjAccount(id);
        }

        public async Task<AddDjAccount> AddDjAccount(AddDjAccount addDjAccount)
        {
            return await _freelanceDJRepository.AddNewDjAccount(addDjAccount);
        }

        public async Task<UpdateDjAccount> UpdateDjAccount(Guid id, UpdateDjAccount updateDjAccount)
        {
            return await _freelanceDJRepository.UpdateDjAccount(id, updateDjAccount);
        }

        public async Task<DjAccount> DeleteDjAccountById(Guid id)
        {
            return await _freelanceDJRepository.DeleteSpecificDjAccount(id);
        }

    }
}

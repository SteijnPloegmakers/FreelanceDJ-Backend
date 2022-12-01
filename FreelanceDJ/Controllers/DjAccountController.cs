using FreelanceDJ.Data;
using FreelanceDJ.Models.DjAccount;
using FreelanceDJ.Service;
using Microsoft.AspNetCore.Mvc;

namespace FreelanceDJ.Controllers
{
    [ApiController]
    [Route("api/djaccount")]
    public class DjAccountController : Controller
    {
        private readonly IDJAccountservice _djAccountservice;
        private readonly DataContext _dataContext;

        public DjAccountController(IDJAccountservice djAccountservice, DataContext dataContext)
        {
            _djAccountservice = djAccountservice;
            _dataContext = dataContext;
        }
    

        [HttpGet]
        public async Task<List<DjAccount>> GetDjAccounts()
        {
            return await _djAccountservice.GetAllDjs();
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetDjAccount([FromRoute] Guid id)
        {
            var djaccount = await _dataContext.DjAccounts.FindAsync(id);

            if (djaccount == null)
            {
                return NotFound();
            }

            return Ok(djaccount);
        }

        [HttpPost]
        public async Task<IActionResult> AddDjAccount(AddDjAccount addDjAccount)
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

            return Ok(djaccount);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateDjAccount([FromRoute] Guid id, UpdateDjAccount updateDjAccount)
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

                return Ok(djaccount);
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteDjAccount([FromRoute] Guid id)
        {
            var djaccount = await _dataContext.DjAccounts.FindAsync(id);

            if (djaccount != null)
            {
                _dataContext.Remove(djaccount);
                await _dataContext.SaveChangesAsync();

                return Ok(djaccount);
            }

            return NotFound();
        }
    }
}

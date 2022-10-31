using FreelanceDJ.Data;
using FreelanceDJ.Models.DjAccount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FreelanceDJ.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DjAccountController : Controller
    {
        private readonly DjAccountData dbContext;

        public DjAccountController(DjAccountData dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetDjAccount([FromRoute] Guid id)
        {
            var djaccount = await dbContext.DjAccounts.FindAsync(id);

            if (djaccount == null)
            {
                return NotFound();
            }

            return Ok(djaccount);
        }

        [HttpGet]
        public async Task<IActionResult> GetDjAccounts()
        {
            return Ok(await dbContext.DjAccounts.ToListAsync());
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

            await dbContext.DjAccounts.AddAsync(djaccount);
            await dbContext.SaveChangesAsync();

            return Ok(djaccount);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateDjAccount([FromRoute] Guid id, UpdateDjAccount updateDjAccount)
        {
            var djaccount = await dbContext.DjAccounts.FindAsync(id);

            if (djaccount != null)
            {
                djaccount.Name = updateDjAccount.Name;
                djaccount.Description = updateDjAccount.Description;
                djaccount.Email = updateDjAccount.Email;
                djaccount.Phone = updateDjAccount.Phone;
                djaccount.Price = updateDjAccount.Price;

                await dbContext.SaveChangesAsync();

                return Ok(djaccount);
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteDjAccount([FromRoute] Guid id)
        {
            var djaccount = await dbContext.DjAccounts.FindAsync(id);

            if (djaccount != null)
            {
                dbContext.Remove(djaccount);
                await dbContext.SaveChangesAsync();

                return Ok(djaccount);
            }

            return NotFound();
        }
    }
}

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

        public DjAccountController(IDJAccountservice djAccountservice)
        {
            _djAccountservice = djAccountservice;
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
            var djaccount = await _djAccountservice.GetDjAccountById(id);

            if (djaccount == null)
            {
                return NotFound();
            }

            return Ok(djaccount);
        }

        [HttpPost]
        public async Task<IActionResult> AddDjAccount(AddDjAccount addDjAccount)
        {
            var djaccount = await _djAccountservice.AddDjAccount(addDjAccount);
            return Ok(djaccount);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateDjAccount([FromRoute] Guid id, UpdateDjAccount updateDjAccount)
        {
            var djaccount = await _djAccountservice.UpdateDjAccount(id, updateDjAccount);
            return Ok(djaccount);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteDjAccount([FromRoute] Guid id)
        {
            var djaccount = await _djAccountservice.DeleteDjAccountById(id);

            if (djaccount != null)
            {
                return Ok(djaccount);
            }

            return NotFound();
        }
    }
}

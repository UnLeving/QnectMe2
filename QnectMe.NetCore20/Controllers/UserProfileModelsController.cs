using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QnectMe.NetCore20.Models;
using QnectMe.NetCore20.Data;

namespace QnectMe.NetCore20.Controllers
{
    [Produces("application/json")]
    [Route("api/UserProfileModels")]
    public class UserProfileModelsController : Controller
    {
        private readonly UserProfileContext _context;

        public UserProfileModelsController(UserProfileContext context)
        {
            _context = context;
        }

        // GET: api/UserProfileModels
        [HttpGet]
        public IEnumerable<UserProfileModel> GetUserProfiles()
        {
            return _context.UserProfiles;
        }

        // GET: api/UserProfileModels/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserProfileModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userProfileModel = await _context.UserProfiles.SingleOrDefaultAsync(m => m.ID == id);

            if (userProfileModel == null)
            {
                return NotFound();
            }

            return Ok(userProfileModel);
        }

        // PUT: api/UserProfileModels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserProfileModel([FromRoute] int id, [FromBody] UserProfileModel userProfileModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userProfileModel.ID)
            {
                return BadRequest();
            }

            _context.Entry(userProfileModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserProfileModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UserProfileModels
        [HttpPost]
        public async Task<IActionResult> PostUserProfileModel([FromBody] UserProfileModel userProfileModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.UserProfiles.Add(userProfileModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserProfileModel", new { id = userProfileModel.ID }, userProfileModel);
        }

        // DELETE: api/UserProfileModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserProfileModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userProfileModel = await _context.UserProfiles.SingleOrDefaultAsync(m => m.ID == id);
            if (userProfileModel == null)
            {
                return NotFound();
            }

            _context.UserProfiles.Remove(userProfileModel);
            await _context.SaveChangesAsync();

            return Ok(userProfileModel);
        }

        private bool UserProfileModelExists(int id)
        {
            return _context.UserProfiles.Any(e => e.ID == id);
        }
    }
}
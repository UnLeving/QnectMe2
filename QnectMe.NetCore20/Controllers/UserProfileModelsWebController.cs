using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QnectMe.NetCore20.Models;
using QnectMe.NetCore20.Data;
using Microsoft.AspNetCore.Authorization;

namespace QnectMe.NetCore20.Controllers
{
    [Authorize]
    public class UserProfileModelsWebController : Controller
    {
        UserProfileContext _context;

        public UserProfileModelsWebController(UserProfileContext context)
        {
            _context = context;
        }

        // GET: UserProfileModelsWeb
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserProfiles.ToListAsync());
        }

        // GET: Get my profile
        public async Task<IActionResult> MyIndex()
        {
            var userProfileModel = await _context.UserProfiles.FirstOrDefaultAsync();
            if (userProfileModel == null) return RedirectToAction(nameof(Create));

            return View(userProfileModel);
        }

        // GET: UserProfileModelsWeb/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var userProfileModel = await _context.UserProfiles.SingleOrDefaultAsync(m => m.ID == id);
            if (userProfileModel == null) return NotFound();

            return View(userProfileModel);
        }

        // GET: UserProfileModelsWeb/Create
        public IActionResult Create()
        {
            if (_context.UserProfiles.Count() == 0)
                return View();
            return RedirectToAction(nameof(MyIndex));
        }

        // POST: UserProfileModelsWeb/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Number,Company,Email,Skype,LI,FB,VK")] UserProfileModel userProfileModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userProfileModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(MyIndex));
            }
            return View(userProfileModel);
        }

        // GET: UserProfileModelsWeb/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var userProfileModel = await _context.UserProfiles.SingleOrDefaultAsync(m => m.ID == id);
            if (userProfileModel == null) return NotFound();

            return View(userProfileModel);
        }

        // POST: UserProfileModelsWeb/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Number,Company,Email,Skype,LI,FB,VK")] UserProfileModel userProfileModel)
        {
            if (id != userProfileModel.ID) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userProfileModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserProfileModelExists(userProfileModel.ID)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(MyIndex));
            }
            return View(userProfileModel);
        }

        // GET: UserProfileModelsWeb/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var userProfileModel = await _context.UserProfiles.SingleOrDefaultAsync(m => m.ID == id);
            if (userProfileModel == null) return NotFound();

            return View(userProfileModel);
        }

        // POST: UserProfileModelsWeb/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userProfileModel = await _context.UserProfiles.SingleOrDefaultAsync(m => m.ID == id);
            _context.UserProfiles.Remove(userProfileModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        bool UserProfileModelExists(int id) => _context.UserProfiles.Any(e => e.ID == id);
    }
}

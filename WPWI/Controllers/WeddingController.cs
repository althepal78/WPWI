using AutoMapper;
using DAL.DbContext;
using DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WPWI.Models.ViewModels;

namespace WPWI.Controllers
{
    [Authorize]
    public class WeddingController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly AppDbContext _dbContext;
        private readonly SignInManager<AppUser> _signInManager;


        public WeddingController(UserManager<AppUser> userManager,
                                  IMapper mapper,
                                  AppDbContext dbContext,
                                  SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _dbContext = dbContext;
            _signInManager = signInManager;
        }

        private async Task<AppUser> GetUserConnected()
        {
            var userConnected = HttpContext.User.Identity.Name;
            return await _userManager.FindByEmailAsync(userConnected);
        }

        public async Task<IActionResult> Dashboard()
        {

            var weddings = await _dbContext.Weddings.Include(a => a.AppUser).Include(r => r.RSVPs).ToListAsync();

            List<WeddingVM> weddingsVM = _mapper.Map<List<WeddingVM>>(weddings);
            DashboardVM vm = new DashboardVM
            {
                WeddingsList = weddingsVM
            };

            return View(vm);
        }

        public IActionResult AddWedding()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddWedding(WeddingVM weddingVM)
        {
            if (!ModelState.IsValid)
            {
                return View(weddingVM);
            }

            Wedding newWedding = _mapper.Map<Wedding>(weddingVM);

            AppUser user = await GetUserConnected();

            newWedding.AppUserId = user.Id;
            newWedding.AppUser = user;

            var hasRoles = await _userManager.IsInRoleAsync(user, "Planner");
            if (!hasRoles)
            {
                await _userManager.AddToRoleAsync(user, "Planner");
            }


            await _dbContext.Weddings.AddAsync(newWedding);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Dashboard");
        }

        public IActionResult ShowWedding(Guid WeddingId)
        {


            return View();
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var DeleteThisWedding = await _dbContext.Weddings
                                          .Include(r => r.RSVPs)
                                          .Include(au => au.AppUser)
                                          .FirstOrDefaultAsync(x => x.WeddingId == id);
            if (DeleteThisWedding == null)
            {
                return View();
            }
            else
            {
                if (User.IsInRole("Planner") && User.FindFirst("id").Value == DeleteThisWedding.AppUser.Id)
                {
                    _dbContext.Weddings.Remove(DeleteThisWedding);
                    _dbContext.SaveChanges();
                    return RedirectToAction("Dashboard");
                }
                else
                {
                    return RedirectToAction(nameof(Dashboard));
                }
            }


        }

        public async Task<IActionResult> RSVP(Guid id)
        {

            AppUser UserConnected = await GetUserConnected();
            Console.WriteLine(UserConnected.Id + "**********************************************");
            if (User.IsInRole("User"))
            {
                RSVP Attending = new RSVP()
                {
                    WeddingID = id,
                    AppUserId = UserConnected.Id,
                };
                await _dbContext.RSVPs.AddAsync(Attending);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction("Dashboard");
            }
            else
            {
                return RedirectToAction("Logout", "Accounts");
            }

        }
    }
}

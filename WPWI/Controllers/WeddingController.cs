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

        public async Task<IActionResult> Dashboard()
        {
            var weddings = await _dbContext.Weddings.ToListAsync();
            List<WeddingVM> weddingsVM = _mapper.Map<List<WeddingVM>>(weddings);
            return View(weddingsVM);
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
            var userEmail = HttpContext.User.Identity.Name;
            AppUser user = await _userManager.FindByEmailAsync(userEmail);

            newWedding.AppUserId = user.Id;

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
    }
}

using AutoMapper;
using DAL.DbContext;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WPWI.Models.ViewModels;

namespace WPWI.Controllers
{
    
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
    }
}

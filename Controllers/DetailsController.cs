using Microsoft.AspNetCore.Mvc;
using RotiMakan.Repository;

namespace RotiMakan.Controllers
{
    public class DetailsController : Controller
    {
        private readonly IDetailsRepository repository;

        public DetailsController(IDetailsRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IActionResult> Index()
        {
            var model = await repository.ShowDetails();
            return View(model);
        }
    }
}

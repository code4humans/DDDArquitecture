using Application.Contracts;
using Application.Core;
using System.Collections.Generic;
using System.Web.Http;

namespace Web_API.Controllers
{
    public class HomeController : ApiController
    {
        private readonly IHomeService _homeService;
        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }

        [HttpGet]
        public IEnumerable<HomeDTO> GetAll()
        {
            return _homeService.GetAll();
        }

        [HttpPost]
        public void Add(HomeDTO request)
        {
            _homeService.Add(request);
        }
    }
}

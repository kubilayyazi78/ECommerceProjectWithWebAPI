using Business.Abstract;
using Entities.Dtos.AppUsers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PageTypesController : ControllerBase
    {
        private readonly IPageTypeService _pageTypeService;

        public PageTypesController(IPageTypeService pageTypeService)
        {
            _pageTypeService = pageTypeService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _pageTypeService.GetListAsync();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }


    }
}
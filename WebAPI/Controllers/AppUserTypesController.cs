using Business.Abstract;
using Entities.Dtos.AppUsers;
using Entities.Dtos.AppUserTypes;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AppUserTypesController : ControllerBase
    {
        private readonly IAppUserTypeService  _appUserTypeService;

        public AppUserTypesController(IAppUserTypeService appUserTypeService)
        {
            _appUserTypeService = appUserTypeService;
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _appUserTypeService.GetListAsync();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet]
        [Route("[action]/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _appUserTypeService.GetByIdAsync(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Add([FromBody] AppUserTypeAddDto  appUserTypeAddDto)
        {
            var result = await _appUserTypeService.AddAsync(appUserTypeAddDto);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> Update([FromBody] AppUserTypeUpdateDto  appUserTypeUpdateDto)
        {
            var result = await _appUserTypeService.UpdateAsync(appUserTypeUpdateDto);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpDelete]
        [Route("[action]/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _appUserTypeService.DeleteAsync(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

    }
}

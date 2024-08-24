using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictsController : ControllerBase
    {
        private readonly IDistrictService _districtService;

        public DistrictsController(IDistrictService districtService)
        {
            _districtService = districtService;
        }

        [HttpGet("getlist")]
        public IActionResult GetList()
        {
            var result = _districtService.GetAll();

            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpGet("get")]
        public IActionResult GetById(int id)
        {
            var result = _districtService.GetById(id);

            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpPost("add")]
        public IActionResult AddDistrict(District district)
        {
            var result = _districtService.Add(district);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpPut("update")]
        public IActionResult UpdateDistrict(District district)
        {
            var result = _districtService.Update(district);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpDelete("delete")]
        public IActionResult DeleteDistrict(int id)
        {
            var result = _districtService.GetById(id);

            if (result.Success)
            {
                try
                {
                    _districtService.Delete(result.Data);
                    return Ok();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
    }
}

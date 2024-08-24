using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StreetsController : ControllerBase
    {
        private readonly IStreetService _streetService;

        public StreetsController(IStreetService streetService)
        {
            _streetService = streetService;
        }

        [HttpGet("getlist")]
        public IActionResult GetList()
        {
            var result = _streetService.GetAll();

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
            var result = _streetService.GetById(id);

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
        public IActionResult AddStreet(Street street)
        {
            var result = _streetService.Add(street);

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
        public IActionResult UpdateStreet(Street street)
        {
            var result = _streetService.Update(street);

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
        public IActionResult DeleteStreet(int id)
        {
            var result = _streetService.GetById(id);

            if (result.Success)
            {
                try
                {
                    _streetService.Delete(result.Data);
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
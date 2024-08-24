using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressesController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet("getlist")]
        public IActionResult GetList()
        {
            var result = _addressService.GetAll();

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
            var result = _addressService.GetById(id);

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
        public IActionResult AddAddress(Address address)
        {
            var result = _addressService.Add(address);

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
        public IActionResult UpdateAddress(Address address)
        {
            var result = _addressService.Update(address);

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
        public IActionResult DeleteAddress(int id)
        {
            var result = _addressService.GetById(id);

            if (result.Success)
            {
                try
                {
                    _addressService.Delete(result.Data);
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

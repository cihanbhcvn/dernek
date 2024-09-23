using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagementsController : ControllerBase
    {
        private readonly IManagementService _managementService;

        public ManagementsController(IManagementService managementService)
        {
            _managementService = managementService;
        }

        [HttpGet("getlist")]
        public IActionResult GetList()
        {
            var result = _managementService.GetAll();

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
            var result = _managementService.GetById(id);

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
        public IActionResult AddManagement(Management management)
        {
            var result = _managementService.Add(management);

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
        public IActionResult UpdateManagement(Management management)
        {
            var result = _managementService.Update(management);

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
        public IActionResult DeleteManagement(int id)
        {
            var result = _managementService.GetById(id);

            if (result.Success)
            {
                try
                {
                    _managementService.Delete(result.Data);
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
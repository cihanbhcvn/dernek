using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NeighbourhoodsController : ControllerBase
    {
        private readonly INeighbourhoodService _neighbourhoodService;

        public NeighbourhoodsController(INeighbourhoodService neighbourhoodService)
        {
            _neighbourhoodService = neighbourhoodService;
        }

        [HttpGet("getlist")]
        public IActionResult GetList()
        {
            var result = _neighbourhoodService.GetAll();

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
            var result = _neighbourhoodService.GetById(id);

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
        public IActionResult AddNeighbourhood(Neighbourhood neighbourhood)
        {
            var result = _neighbourhoodService.Add(neighbourhood);

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
        public IActionResult UpdateNeighbourhood(Neighbourhood neighbourhood)
        {
            var result = _neighbourhoodService.Update(neighbourhood);

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
        public IActionResult DeleteNeighbourhood(int id)
        {
            var result = _neighbourhoodService.GetById(id);

            if (result.Success)
            {
                try
                {
                    _neighbourhoodService.Delete(result.Data);
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

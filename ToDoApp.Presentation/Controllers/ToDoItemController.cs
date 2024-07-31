using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Application.DTOs;
using ToDoApp.Application.Services;

namespace ToDoApp.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemController : ControllerBase
    {
        private readonly ToDoService _Service;

        public ToDoItemController(ToDoService Service)
        {
            _Service = Service;
        }
        [HttpGet]
        public IActionResult Get()
        {

            return Ok(_Service.GetAll());
        }
        [HttpGet(/*"{id}"*/"{id:int}")]
        public IActionResult GetById(int id)
        {
            var item = _Service.GetById(id);
            if (item is null)
            {
                return NotFound();
            }

            return Ok(_Service.GetById(id));
        }
       // [HttpGet(/*"{id}"*/"{item}")]
        [HttpGet(/*"{id}"*/"search/{item}")]
        public IActionResult Search(string item)
        {
            _Service.Search(item).ToList();
            if (item is null)
            {
                return NotFound();
            }

            return Ok(_Service.Search(item).ToList());
        }
        [HttpPut(/*"{id}"*/"{id:int}")]
        public IActionResult UpdateById(int id, UpdateToDoItem dto)
        {
            var item = _Service.UpdateById(id, dto);
            if (item != null)
            {
                return Ok();
            }

            return BadRequest("cannot update");
        }
        [HttpPut(/*"{id}"*/"Update-complete")]
        public IActionResult UpdateComplete(int id, UpdateCompleteDTO dto)
        {
            var item = _Service.UpdateComplete( dto);
            if (item != null)
            {
                return Ok();
            }

            return BadRequest("cannot update");
        }
        [HttpDelete(/*"{id}"*/"{id:int}")]
        public IActionResult DeleteById(int id)
        {
            _Service.DeleteById(id);

            return Ok();
        }
        [HttpPost]
        public IActionResult Post(CreateToDoItem item)
        {
            _Service.Create(item);
            return Ok();
        }


    }
}

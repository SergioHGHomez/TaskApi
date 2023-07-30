using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Models;
using TaskApi.Service;

namespace TaskApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListsController : ControllerBase
    {
        private IListService _listService;

        public ListsController(IListService listService) {
            _listService = listService;
        }

        [HttpGet]
        public IActionResult Get() {
            
            return Ok(_listService.Get());
        }

        [HttpPost]
        public IActionResult Post([FromBody] List list) {
            _listService.add(list);
            return Ok();
            
        }

    }
}

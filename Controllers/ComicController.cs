using ApiMarvel.Data;
using ApiMarvel.Model;
using ApiMarvel.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiMarvel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComicController : ControllerBase
    {
        private readonly IComicService comicService;
        private readonly IMapper mapper;
        public ComicController(IComicService comicService, IMapper mapper)
        {
            this.comicService = comicService;
            this.mapper = mapper;
        }

        [HttpPost]

        [Route("AddComic")]
        public async Task<IActionResult> Add(ComicDto comicDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var comic = mapper.Map<Comic>(comicDto);
            comic = await comicService.Insert(comic);
            return Ok(comic);
        }

        [HttpPut]
        [Route("UpdateComic")]
        public async Task<IActionResult> Update(ComicDto comicDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var comic = mapper.Map<Comic>(comicDto);
            comic = await comicService.Update(comic);
            return Ok(comic);
        }
        [HttpGet]
        [Route("GetComics")]
        public async Task<IActionResult> GetAll()
        {
            var listComic = await comicService.GetList();
            return Ok(listComic);
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return BadRequest();

            var comic = await comicService.GetById((int)id);

            if (comic == null)
                return BadRequest("Comic No existe");

            await comicService.Delete(id.Value);

            return Ok("El Comic se elimino");
        }
    }
}

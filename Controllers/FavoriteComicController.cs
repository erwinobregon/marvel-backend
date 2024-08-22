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
    public class FavoriteComicController : ControllerBase
    {
        private readonly IFavoriteComicService favoriteComicService;
        private readonly IMapper mapper;

        public FavoriteComicController(IFavoriteComicService favoriteComicService, IMapper mapper)
        {
            this.favoriteComicService = favoriteComicService;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("AddFavoriteComic")]
        public async Task<IActionResult> Add(FavoriteComicDto favoriteComicDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var favoriteComic = mapper.Map<FavoriteComic>(favoriteComicDto);
            favoriteComic = await favoriteComicService.Insert(favoriteComic);
            return Ok(favoriteComic);
        }

        [HttpPut]
        [Route("UpdateFavoriteComic")]
        public async Task<IActionResult> Update(FavoriteComicDto favoriteComicDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var favoriteComic = mapper.Map<FavoriteComic>(favoriteComicDto);
            favoriteComic = await favoriteComicService.Update(favoriteComic);
            return Ok(favoriteComic);
        }
        [HttpGet]
        [Route("GetFavoriteComics")]
        public async Task<IActionResult> GetAll()
        {
            var listFavoriteComic = await favoriteComicService.GetList();
            return Ok(listFavoriteComic);
        }

        [HttpDelete]
        [Route("DeleteFavorite")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return BadRequest();

            var favoriteComic = await favoriteComicService.GetById((int)id);

            if (favoriteComic == null)
                return BadRequest("Comic No existe");

            await favoriteComicService.Delete(id.Value);

            return Ok("El Comic se elimino");
        }
    }
}


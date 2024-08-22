using ApiMarvel.Data;
using AutoMapper;

namespace ApiMarvel.Model
{
    public class Mapper: Profile
    {
        public Mapper()
        {
            CreateMap<ComicDto, Comic>();
            CreateMap<Comic, ComicDto>();

            CreateMap<UserDto, User >();
            CreateMap<User, UserDto>();

            CreateMap<FavoriteComicDto, FavoriteComic>();
            CreateMap<FavoriteComic, FavoriteComicDto>();
        }   
    }
}

namespace ApiMarvel.Model
{
    public class FavoriteComicDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ComicId { get; set; }
        public UserDto User { get; set; } = null!;
    }

}

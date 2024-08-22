using System;
using System.Collections.Generic;

namespace ApiMarvel.Data
{
    public partial class User
    {
        public User()
        {
            FavoriteComics = new HashSet<FavoriteComic>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Identification { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<FavoriteComic> FavoriteComics { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace ApiMarvel.Data
{
    public partial class Comic
    {
        public Comic()
        {
            FavoriteComics = new HashSet<FavoriteComic>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Path { get; set; } = null!;

        public virtual ICollection<FavoriteComic> FavoriteComics { get; set; }
    }
}

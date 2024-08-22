using System;
using System.Collections.Generic;

namespace ApiMarvel.Data
{
    public partial class FavoriteComic
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? ComicId { get; set; }

        public virtual Comic? Comic { get; set; }
        public virtual User? User { get; set; }
    }
}

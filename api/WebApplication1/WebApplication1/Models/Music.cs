using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Music
    {
        public int MusicId { get; set; }
        public string Playlist {get; set; }
        public string AlbumName { get; set; }

        public string SingerName { get; set; }
        public string  ReleaseDate { get; set; }
        public string  Genre { get; set; }
    }
}

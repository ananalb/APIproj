using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicLibraryWebAPI.Models
{
    public class Music
    {
        [key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }

    }
}

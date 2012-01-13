using System.Collections.Generic;
using Merriweather.Models;
using MvcMusicStore.Models;

namespace Merriweather.ViewModels
{
    public class BandEditModel
    {
        public CheckedList<Artist> ArtistCheckedList { get; set; }

        public Band Band { get; set; }
    }

    public class CheckedList<T> : Dictionary<T, bool>
    {
    }
}
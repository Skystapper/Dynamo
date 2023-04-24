﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamo_Desktop.Models.Anime
{
    public class GogoResult
    {
        public string id { get; set; }
        public string episodeId { get; set; }
        public int episodeNumber { get; set; }
        public string title { get; set; }
        public string image { get; set; }
        public string url { get; set; }
    }

    public class GogoAnimeRecentEpisodes
    {
        public int currentPage { get; set; }
        public bool hasNextPage { get; set; }
        public List<GogoResult> ?results { get; set; }
    }


}
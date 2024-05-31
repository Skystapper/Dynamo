﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Dynamo_Desktop.Models.Anime;
using Dynamo_Desktop.Services.Anime;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Dynamo_Desktop.ViewModels.Anime
{
    public class DetailsViewModel2 : ReactiveObject
    {
        private AnimeIndexToDetailsRouteParams _routeParams;

        public AnimeIndexToDetailsRouteParams RouteParams
        {
            get => _routeParams;
            set
            {
                this.RaiseAndSetIfChanged(ref _routeParams, value);
                GetInfo();
              
            }
        }

        [Reactive]
        public AnimeInfo Info { get; set; }
        private IAnimeService AnimeService { get; set; }
        public async void GetInfo()
        {
            switch (RouteParams.Provider)
            {
                case AnimeProviders.GogoAnime:
                    AnimeService = new GogoAnimeService();
                    break;
            }
            Info = await AnimeService.Info(RouteParams.AnimeId);
            Debug.WriteLine(JsonSerializer.Serialize(Info));
        }
    }
}

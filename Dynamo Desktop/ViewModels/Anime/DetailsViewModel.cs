﻿using Dynamo_Desktop.Models.Anime;
using Dynamo_Desktop.Services.Anime;
using Dynamo_Desktop.Views.Anime.Subviews.AnimePahe;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Dynamo_Desktop.ViewModels.Anime;

public class DetailsViewModel : ViewModelBase
{

    private AnimeIndexToDetailsRouteParams _routeParams;
    private AnimePaheAnimeInfo _animePaheAnimeInfo;
    private AnimePaheService _animePaheService = new AnimePaheService();

    public AnimePaheAnimeInfo AnimePaheAnimeInfo { get => _animePaheAnimeInfo; set => this.RaiseAndSetIfChanged(ref _animePaheAnimeInfo, value); }
    public AnimeIndexToDetailsRouteParams RouteParams { get => _routeParams; set { this.RaiseAndSetIfChanged(ref _routeParams, value);GetAnimeDetails(); } }
    public  DetailsViewModel()
    {

    }
    public async void GetAnimeDetails()
    {
        switch (RouteParams.Provider)
        {
            case "AnimePahe":
                AnimePaheAnimeInfo = await _animePaheService.Info<AnimePaheAnimeInfo>(RouteParams.AnimeId);
                Debug.WriteLine(JsonSerializer.Serialize(AnimePaheAnimeInfo));
                break;
            default:
                break;
        }
 
    }

}
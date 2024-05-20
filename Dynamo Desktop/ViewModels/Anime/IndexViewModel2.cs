﻿using Dynamo_Desktop.Models.Anime;
using Dynamo_Desktop.Services.Anime;
using ReactiveUI.Fody.Helpers;
using System.Collections.Generic;


namespace Dynamo_Desktop.ViewModels.Anime;

//not partial, added for refactoring
public class IndexViewModel2 : ViewModelBase
{
    public AnimeProviders Provider { get; set; }

    [Reactive]
    public List<PopularAnime> PopularAnime { get; set; }

    [Reactive]
    public List<PopularAnime> RecentAnime { get; set; }

    [Reactive]
    public List<PopularAnime> SearchResults { get; set; }

    [Reactive]
    public IAnimeService AnimeService { get; set; }

    [Reactive]
    public string Sort { get; set; }

    public List<string> SortOptions => new List<string>() { "Newest", "Popular" };
    public IndexViewModel2()
    {
        Sort = "Newest";
        Page = 1;
        AnimeService = new GogoAnimeService();
        GetEpisodes();
    }
    public async void GetEpisodes()
    {
        DataLoading = true;
        RecentAnime = await AnimeService.RecentAnime(Page);
        PopularAnime = await AnimeService.PopularAnime(Page);
        DataLoading = false;
    }
    public void PrevPage()
    {
        if (Page > 1)
        {
            Page--;
            GetEpisodes();
        }
    }
    public void NextPage()
    {
        Page++;
        GetEpisodes();
    }
}
public enum AnimeProviders
{
    GogoAnime,  
    AnimePahe,
    ZoroAnime
}
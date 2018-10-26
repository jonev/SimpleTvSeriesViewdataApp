using SimpleTvSeriesViewdataApp.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTvSeriesViewdataApp
{
    public interface IViewdataRespository
    {
        List<Viewdata> getAllSeriesIdAndViews();
        List<Viewdata> getAllSeriesIdAndViewsSortedOnDate();
        List<Viewdata> getAllSeriesIdViewdOnTv();
        Viewdata getTheMostPopularInYear2018();
        List<Viewdata> getAllData(string seriesId, DateTime date);
    }
}

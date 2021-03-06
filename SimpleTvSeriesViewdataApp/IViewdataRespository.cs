﻿using SimpleTvSeriesViewdataApp.models;
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
        List<Viewdata> getTheMostPopularInYear2018();
        List<Viewdata> getAllDataOnOneSeriesIdAtDate(string seriesId, DateTime date);
    }
}

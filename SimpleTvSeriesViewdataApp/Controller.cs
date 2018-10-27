using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using SimpleTvSeriesViewdataApp.models;
// source https://stackoverflow.com/questions/51521508/apicontroller-not-found-in-net-core-webapi-project

namespace SimpleTvSeriesViewdataApp
{
    [Route("api/")]
    [ApiController]
    public class Controller : ControllerBase
    {
        private IViewdataRespository _data;
        public Controller()
        {
            _data = new ViewdataRepository(new List<Viewdata>
            {
                new Viewdata
                {
                    SeriesId = "id1",
                    Date = new DateTime(2018, 1, 1, 0, 0, 0, 0),
                    Screen = "tv",
                    Views = 100
                },
                new Viewdata
                {
                    SeriesId = "id2",
                    Date = new DateTime(2018, 1, 3, 0, 0, 0, 0),
                    Screen = "mobile",
                    Views = 100
                },
                new Viewdata
                {
                    SeriesId = "id2",
                    Date = new DateTime(2018, 1, 3, 0, 0, 0, 0),
                    Screen = "desktop",
                    Views = 100
                },
                new Viewdata
                {
                    SeriesId = "id2",
                    Date = new DateTime(2018, 1, 2, 0, 0, 0, 0),
                    Screen = "mobile",
                    Views = 100
                },
                new Viewdata
                {
                    SeriesId = "id2",
                    Date = new DateTime(2018, 1, 2, 0, 0, 0, 0),
                    Screen = "tablet",
                    Views = 200
                },
                new Viewdata
                {
                    SeriesId = "id3",
                    Date = new DateTime(2018, 1, 2, 0, 0, 0, 0),
                    Screen = "tv",
                    Views = 500
                },
                new Viewdata
                {
                    SeriesId = "id3",
                    Date = new DateTime(2018, 1, 2, 0, 0, 0, 0),
                    Screen = "tv",
                    Views = 500
                }
            });
        }

        [HttpGet("getAllSeriesIdAndViews")]
        public List<Viewdata> getAllSeriesIdAndViews()
        {
            return _data.getAllSeriesIdAndViews();
        }

        [HttpGet("getAllSeriesIdAndViewsSortedOnDate")]
        public List<Viewdata> getAllSeriesIdAndViewsSortedOnDate()
        {
            return _data.getAllSeriesIdAndViewsSortedOnDate();
        }

        [HttpGet("getAllSeriesIdViewdOnTv")]
        public List<Viewdata> getAllSeriesIdViewdOnTv()
        {
            return _data.getAllSeriesIdViewdOnTv();
        }

        [HttpGet("getTheMostPopularInYear2018")]
        public Viewdata getTheMostPopularInYear2018()
        {
            return _data.getTheMostPopularInYear2018();
        }

        [HttpGet("getAllData/{id}/{date}")]
        public List<Viewdata> getAllData(string id, DateTime date)
        {
            return _data.getAllDataOnOneSeriesIdAtDate(id, date);
        }
    }
}

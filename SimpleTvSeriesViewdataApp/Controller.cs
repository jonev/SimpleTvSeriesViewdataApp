using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using SimpleTvSeriesViewdataApp.models;
// source https://stackoverflow.com/questions/51521508/apicontroller-not-found-in-net-core-webapi-project

namespace SimpleTvSeriesViewdataApp
{
    [Route("api/")]
    [ApiController]
    public class Controller : ControllerBase
    {
        private static IViewdataRespository _data;
        static Controller() // prevents reading file for each connection
        {
            // todo dependency injection !?
            try
            {
                var reader = new StreamReader("./data/data.csv");
                var csv = new CsvReader(reader);
                csv.Configuration.RegisterClassMap<ViewdataMap>();
                _data = new ViewdataRepository(csv.GetRecords<Viewdata>().ToList());
            }
            catch (Exception ex)
            {
                // todo error logging
            }
            // test data if reading file failes
            if (_data is null)
            {

                _data = new ViewdataRepository(new List<Viewdata>
                {
                new Viewdata
                {
                    seriesId = "id1",
                    date = new DateTime(2018, 1, 1, 0, 0, 0, 0),
                    screen = "tv",
                    views = 100
                },
                new Viewdata
                {
                    seriesId = "id2",
                    date = new DateTime(2018, 1, 3, 0, 0, 0, 0),
                    screen = "mobile",
                    views = 100
                },
                new Viewdata
                {
                    seriesId = "id2",
                    date = new DateTime(2018, 1, 3, 0, 0, 0, 0),
                    screen = "desktop",
                    views = 100
                },
                new Viewdata
                {
                    seriesId = "id2",
                    date = new DateTime(2018, 1, 2, 0, 0, 0, 0),
                    screen = "mobile",
                    views = 100
                },
                new Viewdata
                {
                    seriesId = "id2",
                    date = new DateTime(2018, 1, 2, 0, 0, 0, 0),
                    screen = "tablet",
                    views = 200
                },
                new Viewdata
                {
                    seriesId = "id3",
                    date = new DateTime(2018, 1, 2, 0, 0, 0, 0),
                    screen = "tv",
                    views = 500
                },
                new Viewdata
                {
                    seriesId = "id3",
                    date = new DateTime(2018, 1, 2, 0, 0, 0, 0),
                    screen = "tv",
                    views = 500
                }
            });
            }

        }
        public Controller()
        {
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
        public List<Viewdata> getTheMostPopularInYear2018()
        {
            return _data.getTheMostPopularInYear2018();
        }

        [HttpGet("getAllDataOnOneSeriesIdAtDate/{id}/{date}")]
        public List<Viewdata> getAllDataOnOneSeriesIdAtDate(string id, DateTime date)
        {
            return _data.getAllDataOnOneSeriesIdAtDate(id, date);
        }
    }
}

using SimpleTvSeriesViewdataApp;
using SimpleTvSeriesViewdataApp.models;
using System;
using System.Collections.Generic;
using Xunit;

namespace XUnitTestsSimpleTvSeriesViewdataApp
{
    public class ViewdataRepositoryTest
    {
        private static IViewdataRespository _instance;
        static ViewdataRepositoryTest()
        {
            // Testdataset
            // Should be unique for each test
            _instance = new ViewdataRepository(new List<Viewdata>
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

        [Fact]
        public void Test_getAllSeriesIdAndViews()
        {
            var res = _instance.getAllSeriesIdAndViews();
            Assert.Equal(3, res.Count);
            Assert.Equal(100, res[0].Views);
            Assert.Equal(500, res[1].Views);
            Assert.Equal(1000, res[2].Views);
        }

        [Fact]
        public void Test_getAllSeriesIdAndViewsSortedOnDate()
        {
            var res = _instance.getAllSeriesIdAndViewsSortedOnDate();
            Assert.Equal(4, res.Count);
            Assert.Equal(100, res[0].Views);
            Assert.Equal(300, res[1].Views);
            Assert.Equal(1000, res[2].Views);
            Assert.Equal(200, res[3].Views);
        }

        [Fact]
        public void Test_getAllSeriesIdViewdOnTv()
        {
            var res = _instance.getAllSeriesIdViewdOnTv();
            Assert.Equal(2, res.Count);
            Assert.Equal(100, res[0].Views);
            Assert.Equal(1000, res[1].Views);
        }

        [Fact]
        public void Test_getTheMostPopularInYear2018()
        {
            var res = _instance.getTheMostPopularInYear2018();
            Assert.Equal(1000, res.Views);
        }

        [Theory]
        [InlineData("id1", "2018.01.01", 1)]
        [InlineData("id3", "2018.01.02", 2)]
        public void Test_getAllData(string seriesId, string date, int entries)
        {
            DateTime dt = DateTime.Parse(date);
            var res = _instance.getAllData(seriesId, dt);
            Assert.Equal(entries, res.Count);
        }
    }
}

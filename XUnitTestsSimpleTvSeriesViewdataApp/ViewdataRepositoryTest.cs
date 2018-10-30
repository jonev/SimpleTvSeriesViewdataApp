using SimpleTvSeriesViewdataApp;
using SimpleTvSeriesViewdataApp.models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [Fact]
        public void Test_getAllSeriesIdAndViews()
        {
            var res = _instance.getAllSeriesIdAndViews();
            Assert.Equal(3, res.Count);
            Assert.Equal(100, res[0].views);
            Assert.Equal(500, res[1].views);
            Assert.Equal(1000, res[2].views);
        }

        [Fact]
        public void Test_getAllSeriesIdAndViewsSortedOnDate()
        {
            var res = _instance.getAllSeriesIdAndViewsSortedOnDate();
            Assert.Equal(4, res.Count);
            Assert.Equal(100, res[0].views);
            Assert.Equal(300, res[1].views);
            Assert.Equal(1000, res[2].views);
            Assert.Equal(200, res[3].views);
        }

        [Fact]
        public void Test_getAllSeriesIdViewdOnTv()
        {
            var res = _instance.getAllSeriesIdViewdOnTv();
            Assert.Equal(2, res.Count);
            Assert.Equal(100, res[0].views);
            Assert.Equal(1000, res[1].views);
        }

        [Fact]
        public void Test_getTheMostPopularInYear2018()
        {
            var res = _instance.getTheMostPopularInYear2018();
            Assert.Equal(1000, res.Sum(v => v.views));
        }

        [Theory]
        [InlineData("id1", "2018.01.01", 1)]
        [InlineData("id3", "2018.01.02", 2)]
        public void Test_getAllData(string seriesId, string date, int entries)
        {
            DateTime dt = DateTime.Parse(date);
            var res = _instance.getAllDataOnOneSeriesIdAtDate(seriesId, dt);
            Assert.Equal(entries, res.Count);
        }
    }
}

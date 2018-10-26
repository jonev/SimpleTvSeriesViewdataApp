using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using SimpleTvSeriesViewdataApp.models;

[assembly: InternalsVisibleTo("XUnitTestsSimpleTvSeriesViewdataApp")]
namespace SimpleTvSeriesViewdataApp
{
    internal class ViewdataRepository : IViewdataRespository
    {
        private List<Viewdata> _data;
        public ViewdataRepository(List<Viewdata> data)
        {
            _data = data;
        }
        public List<Viewdata> getAllData(string seriesId, DateTime date)
        {
            return _data.Where(s => s.SeriesId == seriesId && s.Date.Equals(date)).ToList();
        }

        // source https://stackoverflow.com/questions/35662319/linq-sum-distinct-values-quantity-and-total
        public List<Viewdata> getAllSeriesIdAndViews()
        {
            return _data.GroupBy(d => d.SeriesId)
                            .Select(v => new Viewdata
                            {
                                SeriesId = v.First().SeriesId,
                                Date = new DateTime(),
                                Screen = "All",
                                Views = v.Sum(t => t.Views)
                            }).ToList();
        }

        // source https://stackoverflow.com/questions/5231845/c-sharp-linq-group-by-on-multiple-columns/5232194
        public List<Viewdata> getAllSeriesIdAndViewsSortedOnDate()
        {
         return _data.GroupBy(d => new { d.Date, d.SeriesId })
                        .Select(v => new Viewdata
                        {
                            SeriesId = v.Key.SeriesId,
                            Date = v.Key.Date,
                            Screen = "All",
                            Views = v.Sum(x => x.Views)
                        }).OrderBy(y => y.Date)
                        .ToList();
        }

        public List<Viewdata> getAllSeriesIdViewdOnTv()
        {
            return _data.Where(s => s.Screen == "tv")
                            .GroupBy(g => g.SeriesId)
                            .Select(d => new Viewdata
                            {
                                SeriesId = d.First().SeriesId,
                                Date = new DateTime(),
                                Screen = "tv",
                                Views = d.Sum(v => v.Views)
                            }).ToList();
        }

        public Viewdata getTheMostPopularInYear2018()
        {
            return getAllSeriesIdAndViews().OrderByDescending(x => x.Views).First();
        }
    }
}

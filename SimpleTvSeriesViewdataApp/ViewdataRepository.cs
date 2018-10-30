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

        // source https://stackoverflow.com/questions/35662319/linq-sum-distinct-values-quantity-and-total
        public List<Viewdata> getAllSeriesIdAndViews()
        {
            return _data.GroupBy(d => d.seriesId)
                            .Select(v => new Viewdata
                            {
                                seriesId = v.First().seriesId,
                                date = new DateTime(),
                                screen = "All",
                                views = v.Sum(t => t.views)
                            }).ToList();
        }

        // source https://stackoverflow.com/questions/5231845/c-sharp-linq-group-by-on-multiple-columns/5232194
        public List<Viewdata> getAllSeriesIdAndViewsSortedOnDate()
        {
         return _data.GroupBy(d => new { d.date, d.seriesId })
                        .Select(v => new Viewdata
                        {
                            seriesId = v.Key.seriesId,
                            date = v.Key.date,
                            screen = "All",
                            views = v.Sum(x => x.views)
                        }).OrderBy(y => y.date)
                        .ToList();
        }

        public List<Viewdata> getAllSeriesIdViewdOnTv()
        {
            return _data.Where(s => s.screen == "tv")
                            .GroupBy(g => g.seriesId)
                            .Select(d => new Viewdata
                            {
                                seriesId = d.First().seriesId,
                                date = new DateTime(),
                                screen = "tv",
                                views = d.Sum(v => v.views)
                            }).ToList();
        }

        public List<Viewdata> getTheMostPopularInYear2018()
        {
            Viewdata mostPopular = getAllSeriesIdAndViews().OrderByDescending(x => x.views).First();
            return _data.Where(s => s.seriesId == mostPopular.seriesId)
                        .GroupBy(g => g.screen)
                        .Select(d => new Viewdata
                        {
                            seriesId = d.First().seriesId,
                            date = new DateTime(),
                            screen = d.First().screen,
                            views = d.Sum(v => v.views)
                        }).ToList();
        }

        public List<Viewdata> getAllDataOnOneSeriesIdAtDate(string seriesId, DateTime date)
        {
            return _data.Where(s => s.seriesId == seriesId && s.date.Equals(date)).ToList();
        }
    }
}

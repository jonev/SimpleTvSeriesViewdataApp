using System;
using System.Collections.Generic;
using System.Text;
using CsvHelper.Configuration;

namespace SimpleTvSeriesViewdataApp.models
{
    // example data
    // seriesId,date,screen,views
    // tvSeriesName,20180101,tv,2
    public class Viewdata
    {
        public string seriesId { get; set; }
        public DateTime date { get; set; }
        public string screen { get; set; }
        public int views { get; set; }

        public Viewdata()
        {
        }

        public Viewdata(string seriesId, string date, string screen, int views)
        {
            this.seriesId = seriesId;
            this.date = new DateTime(int.Parse(date.Substring(0, 4)),
                int.Parse(date.Substring(4, 2)), int.Parse(date.Substring(6, 2)));
            this.screen = screen;
            this.views = views;
        }

        public Viewdata(string seriesId, DateTime date, string screen, int views)
        {
            this.seriesId = seriesId;
            this.date = date;
            this.screen = screen;
            this.views = views;
        }
    }
    // source https://joshclose.github.io/CsvHelper/mapping/
    public sealed class ViewdataMap : ClassMap<Viewdata>
    {
        public ViewdataMap()
        {
            Map(m => m.seriesId);
            Map(m => m.date).ConvertUsing( m =>
            {
                var d = m.GetField<string>(1);
                return new DateTime(int.Parse(d.Substring(0, 4)),
                int.Parse(d.Substring(4, 2)), int.Parse(d.Substring(6, 2)));
            });
            Map(m => m.screen);
            Map(m => m.views);
        }
    }
    
}

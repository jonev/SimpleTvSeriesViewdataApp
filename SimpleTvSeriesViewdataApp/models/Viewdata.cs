using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTvSeriesViewdataApp.models
{
    public class Viewdata
    {
        public string SeriesId { get; set; }
        public DateTime Date { get; set; }
        public string Screen { get; set; }
        public int Views { get; set; }
    }
}

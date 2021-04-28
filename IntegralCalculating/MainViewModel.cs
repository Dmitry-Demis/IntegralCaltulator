using System;
using System.Collections.Generic;
using OxyPlot;
using OxyPlot.Series;

namespace IntegralCalculating
{
    class MainViewModel
    {
        public MainViewModel()
        {
            this.Title = "Example 2";
            this.Points = new List<DataPoint>();


        }
        public string Title
        {
            get; private set;
        }

        public IList<DataPoint> Points { get; private set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable MemberCanBePrivate.Global

namespace SimpleProgram.Lib.JSInterop
{
    public class Plotly<TX, TY>
    {
        public Plotly(int count = 1)
        {
            data = new Data[count];
            for (var i = 0; i < count; i++)
            {
                data[i] = new Data();
            }
        }


        public PlotConfig config { get; set; } = new PlotConfig();
        public Data[] data { get; set; }
        public PlotLayout layout { get; set; } = new PlotLayout();


        public class Data
        {
            public Data()
            {
                x = new List<TX>();
                y = new List<TY>();
                z = new List<TY>();
            }

            /// <summary>
            ///     Sets the legend group for this trace. Traces part of the same legend group hide/show at the same time when toggling
            ///     legend items.
            ///     <para>value: string</para>
            ///     <para>default: "" </para>
            /// </summary>
            public string legendgroup { get; set; }

            /// <summary>
            ///     Sets the trace name. The trace name appear as the legend item and on hover.
            /// </summary>
            public string name { get; set; }

            /// <summary>
            ///     Sets the opacity of the trace.
            ///     <para>value: number between or equal to 0 and 1</para>
            ///     <para>default: 1</para>
            /// </summary>
            public double opacity { get; set; } = 1.0;

            public string type { get; set; } = PlotlyTypes.scatter;

            /// <summary>
            ///     Determines whether or not an item corresponding to this trace is shown in the legend.
            ///     <para>value: boolean</para>
            ///     <para>default: true</para>
            /// </summary>
            public bool showlegend { get; set; } = true;

            /// <summary>
            ///     Determines whether or not this trace is visible. If "legendonly", the trace is not
            ///     drawn, but can appear as a legend item (provided that the legend itself is visible).
            ///     <para>value : true | false | "legendonly"</para>
            ///     <para>default: true</para>
            /// </summary>
            public object visible { get; set; } = PlotlyVisibles.true_;

            public List<TX> x { get; set; }

            public List<TY> y { get; set; }
            
            public List<TY> z { get; set; }
            
        }

        public class PlotConfig
        {
            public bool displaylogo { get; set; } = false;
            public bool editable { get; set; } = false;
            public string linkText { get; set; } = "Edit chart";
            public bool responsive { get; set; } = true;
            public bool scrollZoom { get; set; } = false;
            public bool showLink { get; set; } = false;
            public bool staticPlot { get; set; } = false;


            //public bool? displayModeBar { get; set; } = null;
        }

        public class PlotLayout
        {
            /// <summary>
            ///     Sets the plot's title.
            /// </summary>
            public string title { get; set; }
        }
    }
    
    public static class PlotlyTypes
    {
        public const string scatter = "scatter";
        public const string scattergl = "scattergl";
        public const string bar = "bar";
        public const string box = "box";
        public const string pie = "pie";
        public const string area = "area";
        public const string heatmap = "heatmap";
        public const string contour = "contour";
        public const string histogram = "histogram";
        public const string histogram2d = "histogram2d";
        public const string histogram2dcontour = "histogram2dcontour";
        public const string ohlc = "ohlc";
        public const string candlestick = "candlestick";
        public const string table = "table";

        public static List<string> GetTypesList()
        {
            return typeof(PlotlyTypes).GetFields().Select(fieldInfo => fieldInfo.Name).ToList();
        }
    }

    public static class PlotlyVisibles
    {
        public const bool false_ = false;
        public const string legendonly = "legendonly";
        public const bool true_ = true;
    }

    public class PlotlyBlalzorParam
    {
        public string tagId { get; set; } = "";
        public string plotlyType { get; set; }
        public PlotlyTransform transform { get; set; }
        public int transformTime { get; set; }
    }

    public enum PlotlyTransform
    {
        Without,
        Increment
    }
}
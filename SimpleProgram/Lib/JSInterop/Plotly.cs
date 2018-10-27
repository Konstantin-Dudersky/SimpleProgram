using System.Collections.Generic;
using System.Linq;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable MemberCanBePrivate.Global

namespace SimpleProgram.Lib.JSInterop
{
    public class Plotly
    {
        public Plotly(int count = 1)
        {
            data = new Data[count];
            for (var i = 0; i < count; i++) data[i] = new Data();
        }


        public Config config { get; set; } = new Config();
        public Data[] data { get; set; }
        public Layout layout { get; set; } = new Layout();


        public class Data
        {
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

            /// <summary>
            ///     Sets a reference between this trace's y coordinates and a 2D cartesian y axis. If "y" (the default value), the y
            ///     coordinates refer to `layout.yaxis`. If "y2", the y coordinates refer to `layout.yaxis2`, and so on.
            ///     <para>value: subplotid</para>
            ///     <para>default: y</para>
            /// </summary>
            public string yaxis { get; set; } = YaxisEnum.y;

            public object x { get; set; } = new object();

            public object y { get; set; } = new object();

            public object z { get; set; } = new object();


            public static class YaxisEnum
            {
                public const string y = "y";
                public const string y2 = "y2";
                public const string y3 = "y3";
                public const string y4 = "y4";
                public const string y5 = "y5";
                public const string y6 = "y6";

                public static IEnumerable<string> Values =>
                    typeof(YaxisEnum).GetFields().Select(fieldInfo => fieldInfo.Name).ToList();
            }
        }

        public class Config
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

        public class Layout
        {
            public readonly Yaxis yaxis = new Yaxis();
            public readonly Yaxis yaxis2 = new Yaxis();
            public readonly Yaxis yaxis3 = new Yaxis();
            public readonly Yaxis yaxis4 = new Yaxis();

            public Layout()
            {
                yaxis2.overlaying = "y";
                yaxis3.overlaying = "y";
                yaxis4.overlaying = "y";
            }

            /// <summary>
            ///     Sets the plot's title.
            /// </summary>
            public string title { get; set; }

            public class Yaxis
            {
                /// <summary>
                ///     If set to an opposite-letter axis id (e.g. `x2`, `y`), this axis is bound to the corresponding opposite-letter
                ///     axis. If set to "free", this axis' position is determined by `position`.
                ///     <para>enumerated : "free" | "/^x([2-9]|[1-9][0-9]+)?$/" | "/^y([2-9]|[1-9][0-9]+)?$/"</para>
                /// </summary>
                public string anchor { get; set; }

                /// <summary>
                ///     Determines whether a x (y) axis is positioned at the "bottom" ("left") or "top" ("right") of the plotting area.
                ///     <para>enumerated : "top" | "bottom" | "left" | "right"</para>
                /// </summary>
                public string side { get; set; } = SideEnum.left;

                /// <summary>
                ///     If set a same-letter axis id, this axis is overlaid on top of the corresponding same-letter axis. If "false", this
                ///     axis does not overlay any same-letter axes.
                ///     <para>enumerated : "free" | "/^x([2-9]|[1-9][0-9]+)?$/" | "/^y([2-9]|[1-9][0-9]+)?$/"</para>
                /// </summary>
                public string overlaying { get; set; } = "";
                
                /// <summary>
                /// Sets the position of this axis in the plotting space (in normalized coordinates). Only has an effect if `anchor` is set to "free".
                /// <para>number between or equal to 0 and 1</para>
                /// <para>default: 0</para>
                /// </summary>
                public string position { get; set; }

                public static class SideEnum
                {
                    public const string top = "top";
                    public const string bottom = "bottom";
                    public const string left = "left";
                    public const string right = "right";

                    public static IEnumerable<string> Values =>
                        typeof(SideEnum).GetFields().Select(fieldInfo => fieldInfo.Name).ToList();
                }
            }
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
        public string plotlyType { get; set; } = PlotlyTypes.scatter;

        public PlotlyTransform transform { get; set; } = PlotlyTransform.Without;
        public int transformTime { get; set; } = 1;
        public int transformTimeCoef { get; set; } = 3600;

        public string yaxis { get; set; } = Plotly.Data.YaxisEnum.y;
    }

    public enum PlotlyTransform
    {
        Without,
        Increment
    }
}
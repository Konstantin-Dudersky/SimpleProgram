using System.Collections.Generic;
using System.Linq;
using SimpleProgram.Lib.Archives;

// ReSharper disable CommentTypo
// ReSharper disable IdentifierTypo
// ReSharper disable CollectionNeverQueried.Global

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable MemberCanBePrivate.Global

namespace SimpleProgram.Lib.JSInterop
{
    public class Plotly
    {
        public Config config { get; set; } = new Config();
        public List<Data> data { get; set; } = new List<Data>();
        public Layout layout { get; set; } = new Layout();

        public Data LastData => data.Last();

        public void AddData()
        {
            data.Add(new Data());
        }

        public void ClearData()
        {
            data.Clear();
        }

        public class Data
        {
            public Cells cells { get; set; } = new Cells();

            public Header header { get; set; } = new Header();

            public Link link { get; } = new Link();

            public Node node { get; } = new Node();

            /// <summary>
            ///     If value is `snap` (the default), the node arrangement is assisted by automatic snapping of elements to preserve
            ///     space between nodes specified via `nodepad`. If value is `perpendicular`, the nodes can only move along a line
            ///     perpendicular to the flow. If value is `freeform`, the nodes can freely move on the plane. If value is `fixed`, the
            ///     nodes are stationary.
            ///     <para>enumerated : "snap" | "perpendicular" | "freeform" | "fixed"</para>
            ///     <para>default: "snap"</para>
            /// </summary>
            public string arrangement { get; set; } = "snap";

            /// <summary>
            ///     Sets the legend group for this trace. Traces part of the same legend group hide/show at the same time when toggling
            ///     legend items.
            ///     <para>value: string</para>
            ///     <para>default: "" </para>
            /// </summary>
            public string legendgroup { get; set; }

            public string mode { get; set; }

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

            /// <summary>
            ///     Sets the orientation of the Sankey diagram.
            ///     <para>values: enumerated : "v" | "h"</para>
            ///     <para>default: "h"</para>
            /// </summary>
            public string orientation { get; set; } = "v";

            public string type { get; set; } = "";

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

            public void Mode(bool lines, bool markers, bool text)
            {
                var str = "";
                if (lines) str += "lines";

                if (markers)
                {
                    if (str != "")
                        str += "+";
                    str += "markers";
                }

                if (text)
                {
                    if (str != "")
                        str += "+";
                    str += "text";
                }

                if (str == "")
                    str = "none";

                mode = str;
            }


            public class Cells
            {
                /// <summary>
                ///     Cell values. `values[m][n]` represents the value of the `n`th point in column `m`, therefore the `values[m]` vector
                ///     length for all columns must be the same (longer vectors will be truncated). Each value must be a finite number or a
                ///     string.
                ///     <para>value: data array</para>
                /// </summary>
                public List<List<object>> values { get; } = new List<List<object>>();
            }

            public class Header
            {
                /// <summary>
                ///     Header cell values. `values[m][n]` represents the value of the `n`th point in column `m`, therefore the `values[m]`
                ///     vector length for all columns must be the same (longer vectors will be truncated). Each value must be a finite
                ///     number or a string.
                ///     <para>value: data array</para>
                /// </summary>
                public List<object> values { get; } = new List<object>();
            }

            /// <summary>
            ///     The links of the Sankey plot.
            /// </summary>
            public class Link
            {
                /// <summary>
                ///     The shown name of the link.
                ///     <para>values: data array</para>
                /// </summary>
                public List<string> label { get; set; } = new List<string>();

                /// <summary>
                ///     An integer number `[0..nodes.length - 1]` that represents the source node.
                ///     <para>values: data array</para>
                /// </summary>
                public List<int> source { get; set; } = new List<int>();

                /// <summary>
                ///     An integer number `[0..nodes.length - 1]` that represents the source node.
                ///     <para>values: data array</para>
                /// </summary>
                public List<int> target { get; set; } = new List<int>();

                /// <summary>
                ///     A numeric value representing the flow volume value.
                ///     <para>values: data array</para>
                /// </summary>
                public List<double> value { get; set; } = new List<double>();
            }

            /// <summary>
            ///     The nodes of the Sankey plot.
            /// </summary>
            public class Node
            {
                /// <summary>
                ///     The shown name of the node.
                ///     <para>values: data array</para>
                /// </summary>
                public List<string> label { get; set; } = new List<string>();

                /// <summary>
                ///     Sets the `node` color. It can be a single value, or an array for specifying color for each `node`. If `node.color`
                ///     is omitted, then the default `Plotly` color palette will be cycled through to have a variety of colors. These
                ///     defaults are not fully opaque, to allow some visibility of what is beneath the node.
                ///     <para>values: color or array of colors</para>
                /// </summary>
                public List<string> color { get; set; }
            }

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

            /// <summary>
            ///     true - Always Display the Modebar
            ///     false - Hide the Modebar
            /// </summary>
            public bool displayModeBar { get; set; } = true;

            public bool editable { get; set; } = false;

            public string linkText { get; set; } = "Edit chart";

            public bool responsive { get; set; } = true;

            public bool scrollZoom { get; set; } = false;

            public bool showLink { get; set; } = false;

            public bool staticPlot { get; set; } = false;
        }

        public class Layout
        {
            /*/// <summary>
            /// Sets the plot's height (in px).
            /// <para>values: number greater than or equal to 10</para>
            /// <para>default: 450</para>
            /// </summary>
            public int height { get; set; } = 450;*/

            public readonly Margin margin = new Margin();

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
            ///     Determines whether or not a legend is drawn. Default is `true` if there is a trace to show and any of these: a) Two
            ///     or more traces would by default be shown in the legend. b) One pie trace is shown in the legend. c) One trace is
            ///     explicitly given with `showlegend: true`.
            /// </summary>
            public bool showlegend { get; set; } = true;


            /// <summary>
            ///     Sets the plot's title.
            /// </summary>
            public string title { get; set; }

            public class Margin
            {
                /// <summary>
                ///     Sets the left margin (in px).
                ///     <para>values: number greater than or equal to 0</para>
                ///     <para>default: 80</para>
                /// </summary>
                public int l { get; set; } = 80;

                /// <summary>
                ///     Sets the right margin (in px).
                ///     <para>values: number greater than or equal to 0</para>
                ///     <para>default: 80</para>
                /// </summary>
                public int r { get; set; } = 80;

                /// <summary>
                ///     Sets the top margin (in px).
                ///     <para>values: number greater than or equal to 0</para>
                ///     <para>default: 100</para>
                /// </summary>
                public int t { get; set; } = 100;

                /// <summary>
                ///     Sets the bottom margin (in px).
                ///     <para>values: number greater than or equal to 0</para>
                ///     <para>default: 80</para>
                /// </summary>
                public int b { get; set; } = 80;

                /// <summary>
                ///     Sets the amount of padding (in px) between the plotting area and the axis lines.
                ///     <para>values: number greater than or equal to 0</para>
                ///     <para>default: 0</para>
                /// </summary>
                public int pad { get; set; } = 0;

                /// <summary>
                ///     <para>default: true</para>
                /// </summary>
                public bool autoexpand { get; set; } = true;
            }

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
                ///     Sets the position of this axis in the plotting space (in normalized coordinates). Only has an effect if `anchor` is
                ///     set to "free".
                ///     <para>number between or equal to 0 and 1</para>
                ///     <para>default: 0</para>
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
        public const string area = "area";
        public const string bar = "bar";
        public const string box = "box";
        public const string candlestick = "candlestick";
        public const string contour = "contour";
        public const string heatmap = "heatmap";
        public const string histogram = "histogram";
        public const string histogram2d = "histogram2d";
        public const string histogram2dcontour = "histogram2dcontour";
        public const string ohlc = "ohlc";
        public const string pie = "pie";
        public const string sankey = "sankey";
        public const string scatter = "scatter";
        public const string scattergl = "scattergl";
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
        public string plotlyType { get; set; } = PlotlyTypes.scatter;
        public bool DataModeLines { get; set; } = true;
        public bool DataModeMarkers { get; set; }
        public bool DataModeText { get; set; }

        public string tagId { get; set; } = "";
        public string tagIdX { get; set; } = "";

        public SimplifyType transform { get; set; } = SimplifyType.None;
        public SimplifyType transformX { get; set; } = SimplifyType.Average;
        public int transformTime { get; set; } = 1;
        public int transformTimeCoef { get; set; } = 3600;

        public string yaxis { get; set; } = Plotly.Data.YaxisEnum.y;
    }
}
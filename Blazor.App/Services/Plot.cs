using System.Collections.Generic;

namespace Blazor.App.Services
{
    public class Plot<Tx, Ty>
    {
        #region Public Constructors

        public Plot()
        {
            data = new Data[1];
            data[0] = new Data();
        }

        #endregion Public Constructors



        #region Public Properties

        public PlotConfig config { get; set; } = new PlotConfig();
        public Data[] data { get; set; }
        public object layout { get; set; }

        #endregion Public Properties



        #region Public Classes

        public class Data
        {
            #region Public Constructors

            public Data()
            {
                x = new List<Tx>();
                y = new List<Ty>();
            }

            #endregion Public Constructors



            #region Public Properties

            /// <summary>
            /// Determines whether or not an item corresponding to this trace is shown in the legend.
            /// <para>value: boolean</para>
            /// <para>default: true</para>
            /// </summary>
            public bool showlegend { get; set; } = true;

            /// <summary>
            /// Sets the legend group for this trace. Traces part of the same legend group hide/show at the same time when toggling legend items.
            /// <para>value: string</para>
            /// <para>default: "" </para>
            /// </summary>
            public string legendgroup { get; set; }

            /// <summary>
            /// Sets the opacity of the trace.
            /// <para>value: number between or equal to 0 and 1</para>
            /// <para>default: 1</para>
            /// </summary>
            public double opacity { get; set; } = 1.0;


            public string type { get; set; } = Types.scatter;

            /// <summary>
            /// Determines whether or not this trace is visible. If "legendonly", the trace is not
            /// drawn, but can appear as a legend item (provided that the legend itself is visible).
            /// <para>value : true | false | "legendonly"</para>
            /// <para>default: true</para>
            /// </summary>
            public object visible { get; set; } = Visibles.true_;

            //public object[] x { get; set; }
            public List<Tx> x { get; set; }

            //public object[] y { get; set; }
            public List<Ty> y { get; set; }

            #endregion Public Properties



            #region Public Classes

            public static class Types
            {
                #region Public Fields

                public const string scatter = "scatter";

                #endregion Public Fields
            }

            public static class Visibles
            {
                #region Public Fields

                public const bool false_ = false;
                public const string legendonly = "legendonly";
                public const bool true_ = true;

                #endregion Public Fields
            }

            #endregion Public Classes
        }

        public class PlotConfig
        {
            #region Public Properties

            public bool displaylogo { get; set; } = false;
            public bool editable { get; set; } = false;
            public string linkText { get; set; } = "Edit chart";
            public bool responsive { get; set; } = true;
            public bool scrollZoom { get; set; } = false;
            public bool showLink { get; set; } = false;
            public bool staticPlot { get; set; } = false;

            #endregion Public Properties

            //public bool? displayModeBar { get; set; } = null;
        }

        #endregion Public Classes
    }
}
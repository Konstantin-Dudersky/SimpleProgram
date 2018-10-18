using System;
using System.Threading;
using SimpleProgram.Lib.Archives;
using SimpleProgram.Lib.Archives.MasterScada;

namespace Blazor.App.Services
{
    public static class Data
    {
        #region Public Fields

        public static readonly TagGroup1 TagGroup1;
        private static readonly Archive MsArchive = new Archive();

        #endregion Public Fields


        #region Private Fields

        private const int RefreshTime = 1000;

        private static readonly Timer RefreshTimer;

        #endregion Private Fields


        #region Public Constructors

        static Data()
        {
            RefreshTimer = new Timer(new TimerCallback(obj => OnRefresh?.Invoke()), null, 0, RefreshTime);

            MsArchive.SetParams<MasterScadaDb>(Providers.PostgreSql,
                "Host=localhost;Database=energy;Username=postgres;Password=123");

            TagGroup1 = new TagGroup1(archiveDefault: MsArchive);
        }

        #endregion Public Constructors


        #region Public Events

        public static event Action OnRefresh;

        #endregion Public Events


        #region Public Methods

        public static void StartUp()
        {
        }

        #endregion Public Methods
    }
}
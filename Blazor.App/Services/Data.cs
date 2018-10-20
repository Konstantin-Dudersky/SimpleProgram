using SimpleProgram.Lib;
using SimpleProgram.Lib.Archives;
using SimpleProgram.Lib.Archives.MasterScada;

namespace Blazor.App.Services
{
    public class Data : DataBase
    {
        public static readonly Archive MsArchive = new Archive();
        public TagGroup1 TagGroup1;


        public Data()
        {
            MsArchive.SetParams<MasterScadaDb>(Providers.PostgreSql,
                "Host=localhost;Database=energy;Username=postgres;Password=123");

            TagGroup1 = new TagGroup1();


            // время обновления экрана в мс
            RefreshTime = 100;

            // находим ссылки на архивы
            InitTagDict();
        }
    }
}
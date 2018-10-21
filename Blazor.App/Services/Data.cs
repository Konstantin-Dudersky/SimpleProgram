using SimpleProgram.Lib;
using SimpleProgram.Lib.Archives;
using SimpleProgram.Lib.Archives.MasterScada;

namespace Blazor.App.Services
{
    public class Data : DataBase
    {
        public static readonly Archive MsArchive = new Archive()
        {
            ArchiveName = "Архив MasterScada",
        };
        public readonly TagGroup1 TagGroup1;


        public Data() : base(500)
        {
            MsArchive.SetProvider<MasterScadaDb>(
                Providers.PostgreSql,
                "Host=localhost;Database=energy;Username=postgres;Password=123");

            TagGroup1 = new TagGroup1();


            // находим ссылки на архивы
            InitTagDict();
        }
    }
}
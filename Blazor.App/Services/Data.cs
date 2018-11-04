using Opc.Ua;
using SimpleProgram.Lib;
using SimpleProgram.Lib.Archives;
using SimpleProgram.Lib.Archives.MasterScada;
using SimpleProgram.Lib.OpcUa;

namespace Blazor.App.Services
{
    public class Data : DataBase
    {
        public static readonly Archive MsArchive = new Archive
        {
            ArchiveName = "Архив MasterScada"
        };

        public MySampleClient client;

        public readonly TagGroup1 TagGroup1;


        public Data() : base(500)
        {
            MsArchive.SetProvider<MasterScadaDb>(
                Providers.PostgreSql,
                "Host=localhost;Database=energy;Username=postgres;Password=123");
            
            client = new MySampleClient("opc.tcp://localhost:48010", false, 10);


            TagGroup1 = new TagGroup1();

//            var bot = new TelegramBotClient("611768794:AAE1RZMstPcBkrjIZq2h2pzwgK8qAKMR-yU");
//            var me = bot.SendTextMessageAsync("@saria_channel", "123123");

            
            // находим ссылки на архивы
            InitTagDict();
        }


    }
}
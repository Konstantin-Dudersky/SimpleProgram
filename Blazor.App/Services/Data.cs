using SimpleProgram.Lib;
using SimpleProgram.Lib.Archives;
using SimpleProgram.Lib.Archives.MasterScada;
using SimpleProgram.Lib.OpcUa;

namespace Blazor.App.Services
{
    public class Data : DataBase
    {
        public static readonly Archive<MasterScadaDb> MsArchive = new Archive<MasterScadaDb>(Providers.PostgreSql,
            "Host=localhost;Database=energy;Username=postgres;Password=123")
        {
            ArchiveName = "Архив MasterScada"
        };

        public static readonly OpcUaClient OpcClient = new OpcUaClient("opc.tcp://localhost:48010", false, 10);

        public readonly TGEnergy TGEnergy;
        public readonly TGOpcItems TGOpcItems;


        public Data() : base(500)
        {
            TGEnergy = new TGEnergy
            {
                Name = "Энергоменеждмент",
            };
            TGOpcItems = new TGOpcItems
            {
                Name = "OPC UA",
            };


//            var bot = new TelegramBotClient("611768794:AAE1RZMstPcBkrjIZq2h2pzwgK8qAKMR-yU");
//            var me = bot.SendTextMessageAsync("@saria_channel", "123123");


            // находим ссылки на архивы
            InitTagDict();
        }
    }
}
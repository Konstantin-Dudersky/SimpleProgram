using System;
using SimpleProgram.Channels.DatabaseClient;
using SimpleProgram.Channels.ModbusTcpClient;
using SimpleProgram.Channels.OpcUaClient;
using SimpleProgram.Lib;
using SimpleProgram.Lib.Archives.MasterScada;
using SimpleProgram.Lib.Messages;

// ReSharper disable InconsistentNaming
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable IdentifierTypo

namespace Blazor.App.Services
{
    public class Data : DataBase
    {
        public static readonly DatabaseClient<MasterScadaDb> MsDatabaseClient = new DatabaseClient<MasterScadaDb>(
            Providers.PostgreSql,
            "Host=localhost;Database=energy;Username=postgres;Password=123")
        {
            ArchiveName = "Архив MasterScada"
        };

        public static readonly OpcUaClient OpcClient =
            new OpcUaClient("Test OPC UA channel", "opc.tcp://localhost:48010");

        public static readonly OpcUaClient OpcWinCC =
            new OpcUaClient("WinCC OPC UA channel", "opc.tcp://VirtualWin7:4861", disabled: true);

        public static readonly ModbusTcpClient ModbusTcpClient =
            new ModbusTcpClient("mod_RSsim","127.0.0.1", 502, 0, disabled: true);

        public static readonly TelegramClient TelegramClient =
            new TelegramClient("Рассылка сообщений в Telegram", "611768794:AAE1RZMstPcBkrjIZq2h2pzwgK8qAKMR-yU");
        
        public static readonly TelegramClient SimpleProgramTelegramClient = 
            new TelegramClient("Тестовый бот Telegram", "712777006:AAFaGZCCjGa_PH4vq37KxOAPytNO0cF1DlY");

        public readonly TGEnergy TGEnergy;
        public readonly TGOpcItems TGOpcItems;
        public readonly TagGroupWinCC TagGroupWinCc;
        public readonly TgModbus TgModbus = new TgModbus();
        public readonly TgTelegram TgTelegram = new TgTelegram();


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
            TagGroupWinCc = new TagGroupWinCC
            {
                Name = "WinCC OPC UA"
            };

            // находим ссылки на архивы
            InitTagDict();
        }
    }
}
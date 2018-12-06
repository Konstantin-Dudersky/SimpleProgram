using SimpleProgram.Lib;
using SimpleProgram.Lib.Archives;
using SimpleProgram.Lib.Tag;

// ReSharper disable UnusedMember.Global
// ReSharper disable StringLiteralTypo
// ReSharper disable InconsistentNaming
// ReSharper disable FieldCanBeMadeReadOnly.Global
// ReSharper disable IdentifierTypo
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable RedundantArgumentDefaultValue

namespace Blazor.App.Services
{
    public class TGEnergy : TagGroupBase
    {
        public Tag<double> MDB_A__QS1 = new Tag<double>
        {
            TagName = "ГРЩ-А, QS1, Ввод",
            TagChannelDatabase = new TagChannelDatabase(Data.MsDatabase, 
                "Энергоменеджмент.Счетчики.Модуль 1, MDB-A, QS1, PAC")
        };
        
        public Tag<double> MDB_A__QF1_1 = new Tag<double>
        {
            TagName = "ГРЩ-А, QF1.1, РЩБП-AB",
            TagChannelDatabase = new TagChannelDatabase(Data.MsDatabase, 
                "Энергоменеджмент.Счетчики.Модуль 1, MDB-A, QF1_1, PAC")
        };
        
        public Tag<double> MDB_A__QF1_2 = new Tag<double>
        {
            TagName = "ГРЩ-А, QF1.2, UPS-1A",
            TagChannelDatabase = new TagChannelDatabase(Data.MsDatabase, 
                "Энергоменеджмент.Счетчики.Модуль 1, MDB-A, QF1_2, PAC")
        };
        
        public Tag<double> MDB_A__QF1_3 = new Tag<double>
        {
            TagName = "ГРЩ-А, QF1.3, UPS-2A",
            TagChannelDatabase = new TagChannelDatabase(Data.MsDatabase, 
                "Энергоменеджмент.Счетчики.Модуль 1, MDB-A, QF1_3, PAC")
        };
        
        public Tag<double> MDB_A__QF1_4 = new Tag<double>
        {
            TagName = "ГРЩ-А, QF1.4, UPS-3A",
            TagChannelDatabase = new TagChannelDatabase(Data.MsDatabase, 
                "Энергоменеджмент.Счетчики.Модуль 1, MDB-A, QF1_4, PAC")
        };
        
        public Tag<double> MDB_A__QF1_5 = new Tag<double>
        {
            TagName = "ГРЩ-А, QF1.5, UPS-4A",
            TagChannelDatabase = new TagChannelDatabase(Data.MsDatabase, 
                "Энергоменеджмент.Счетчики.Модуль 1, MDB-A, QF1_5, PAC")
        };
        
        public Tag<double> MDB_A__QF2_1 = new Tag<double>
        {
            TagName = "ГРЩ-А, QF2.1, Чиллер №1",
            TagChannelDatabase = new TagChannelDatabase(Data.MsDatabase, 
                "Энергоменеджмент.Счетчики.Модуль 1, MDB-A, QF2_1, PAC")
        };
        
        
        public Tag<double> MDB_A__QF2_2 = new Tag<double>
        {
            TagName = "ГРЩ-А, QF2.2, Чиллер №2",
            TagChannelDatabase = new TagChannelDatabase(Data.MsDatabase, 
                "Энергоменеджмент.Счетчики.Модуль 1, MDB-A, QF2_2, PAC")
        };
        
        public Tag<double> MDB_A__QF2_3 = new Tag<double>
        {
            TagName = "ГРЩ-А, QF2.3, Чиллер №3",
            TagChannelDatabase = new TagChannelDatabase(Data.MsDatabase, 
                "Энергоменеджмент.Счетчики.Модуль 1, MDB-A, QF2_3, PAC")
        };
        
        public Tag<double> MDB_A__QF2_4 = new Tag<double>
        {
            TagName = "ГРЩ-А, QF2.4, Резерв",
            TagChannelDatabase = new TagChannelDatabase(Data.MsDatabase, 
                "Энергоменеджмент.Счетчики.Модуль 1, MDB-A, QF2_4, PAC")
        };
        
        public Tag<double> MDB_A__QF2_5 = new Tag<double>
        {
            TagName = "ГРЩ-А, QF2.5, BATT-DB-AB",
            TagChannelDatabase = new TagChannelDatabase(Data.MsDatabase, 
                "Энергоменеджмент.Счетчики.Модуль 1, MDB-A, QF2_5, PAC")
        };
        
        public Tag<double> MDB_A__QF2_6 = new Tag<double>
        {
            TagName = "ГРЩ-А, QF2.6, Резерв",
            TagChannelDatabase = new TagChannelDatabase(Data.MsDatabase, 
                "Энергоменеджмент.Счетчики.Модуль 1, MDB-A, QF2_6, PAC")
        };
        
        public Tag<double> MDB_A__QF2_7 = new Tag<double>
        {
            TagName = "ГРЩ-А, QF2.7, ER-LSP-DB-AB",
            TagChannelDatabase = new TagChannelDatabase(Data.MsDatabase, 
                "Энергоменеджмент.Счетчики.Модуль 1, MDB-A, QF2_7, PAC")
        };
        
        public Tag<double> MDB_A__QF2_8 = new Tag<double>
        {
            TagName = "ГРЩ-А, QF2.8, IT-LSP-DB-AB",
            TagChannelDatabase = new TagChannelDatabase(Data.MsDatabase, 
                "Энергоменеджмент.Счетчики.Модуль 1, MDB-A, QF2_8, PAC")
        };
        
        public Tag<double> MDB_A__QF3_1 = new Tag<double>
        {
            TagName = "ГРЩ-А, QF3.1, Резерв",
            TagChannelDatabase = new TagChannelDatabase(Data.MsDatabase, 
                "Энергоменеджмент.Счетчики.Модуль 1, MDB-A, QF3_1, PAC")
        };
        
        public Tag<double> MDB_A__QF3_2 = new Tag<double>
        {
            TagName = "ГРЩ-А, QF3.2, Резерв",
            TagChannelDatabase = new TagChannelDatabase(Data.MsDatabase, 
                "Энергоменеджмент.Счетчики.Модуль 1, MDB-A, QF3_2, PAC")
        };
        
        public Tag<double> MDB_A__QF3_3 = new Tag<double>
        {
            TagName = "ГРЩ-А, QF3.3, Резерв",
            TagChannelDatabase = new TagChannelDatabase(Data.MsDatabase, 
                "Энергоменеджмент.Счетчики.Модуль 1, MDB-A, QF3_3, PAC")
        };
        
        public Tag<double> MDB_A__QF3_4 = new Tag<double>
        {
            TagName = "ГРЩ-А, QF3.4, ЩО",
            TagChannelDatabase = new TagChannelDatabase(Data.MsDatabase, 
                "Энергоменеджмент.Счетчики.Модуль 1, MDB-A, QF3_4, PAC")
        };
        
        public Tag<double> MDB_A__QF3_5 = new Tag<double>
        {
            TagName = "ГРЩ-А, QF3.5, Резерв",
            TagChannelDatabase = new TagChannelDatabase(Data.MsDatabase, 
                "Энергоменеджмент.Счетчики.Модуль 1, MDB-A, QF3_5, PAC")
        };
        
        public Tag<double> MDB_A__QF3_6 = new Tag<double>
        {
            TagName = "ГРЩ-А, QF3.6, FIRE-DB-AB",
            TagChannelDatabase = new TagChannelDatabase(Data.MsDatabase, 
                "Энергоменеджмент.Счетчики.Модуль 1, MDB-A, QF3_6, PAC")
        };

        public Tag<double> MDB_B__QS1 = new Tag<double>
        {
            TagName = "ГРЩ-B, QS1, Ввод",
            TagChannelDatabase = new TagChannelDatabase(Data.MsDatabase, 
                "Энергоменеджмент.Счетчики.Модуль 1, MDB-B, QS1, PAC")
        };
        
        public Tag<double> MDB_B__QF1_1 = new Tag<double>
        {
            TagName = "ГРЩ-B, QF1.1, ЩР-АСДУ",
            TagChannelDatabase = new TagChannelDatabase(Data.MsDatabase, 
                "Энергоменеджмент.Счетчики.Модуль 1, MDB-B, QF1_1, PAC")
        };
        
        public Tag<double> MDB_B__QF1_2 = new Tag<double>
        {
            TagName = "ГРЩ-B, QF1.2, ЩРЭ1",
            TagChannelDatabase = new TagChannelDatabase(Data.MsDatabase, 
                "Энергоменеджмент.Счетчики.Модуль 1, MDB-B, QF1_2, PAC")
        };
        
        public Tag<double> MDB_B__QF1_3 = new Tag<double>
        {
            TagName = "ГРЩ-B, QF1.3, РЩБП-B",
            TagChannelDatabase = new TagChannelDatabase(Data.MsDatabase, 
                "Энергоменеджмент.Счетчики.Модуль 1, MDB-B, QF1_3, PAC")
        };
        
        public Tag<double> MDB_B__QF1_4 = new Tag<double>
        {
            TagName = "ГРЩ-B, QF1.4, FIRE-DB-AB",
            TagChannelDatabase = new TagChannelDatabase(Data.MsDatabase, 
                "Энергоменеджмент.Счетчики.Модуль 1, MDB-B, QF1_4, PAC")
        };
        
        public Tag<double> MDB_B__QF1_5 = new Tag<double>
        {
            TagName = "ГРЩ-B, QF1.5, ЩАО1",
            TagChannelDatabase = new TagChannelDatabase(Data.MsDatabase, 
                "Энергоменеджмент.Счетчики.Модуль 1, MDB-B, QF1_5, PAC")
        };
        
        public Tag<double> MDB_B__QF1_6 = new Tag<double>
        {
            TagName = "ГРЩ-B, QF1.6, ЩР-УВ2-В",
            TagChannelDatabase = new TagChannelDatabase(Data.MsDatabase, 
                "Энергоменеджмент.Счетчики.Модуль 1, MDB-B, QF1_6, PAC")
        };
        
        public Tag<double> MDB_B__QF1_7 = new Tag<double>
        {
            TagName = "ГРЩ-B, QF1.7, ЩР-УВ1-В",
            TagChannelDatabase = new TagChannelDatabase(Data.MsDatabase, 
                "Энергоменеджмент.Счетчики.Модуль 1, MDB-B, QF1_7, PAC")
        };
        
        public Tag<double> MDB_B__QF1_8 = new Tag<double>
        {
            TagName = "ГРЩ-B, QF1.8, Резерв",
            TagChannelDatabase = new TagChannelDatabase(Data.MsDatabase, 
                "Энергоменеджмент.Счетчики.Модуль 1, MDB-B, QF1_8, PAC")
        };
        
        public Tag<double> MDB_B__QF2_1 = new Tag<double>
        {
            TagName = "ГРЩ-B, QF2.1, Чиллер №1",
            TagChannelDatabase = new TagChannelDatabase(Data.MsDatabase, 
                "Энергоменеджмент.Счетчики.Модуль 1, MDB-B, QF2_1, PAC")
        };
        
        
        public Tag<double> MDB_B__QF2_2 = new Tag<double>
        {
            TagName = "ГРЩ-B, QF2.2, Чиллер №2",
            TagChannelDatabase = new TagChannelDatabase(Data.MsDatabase, 
                "Энергоменеджмент.Счетчики.Модуль 1, MDB-B, QF2_2, PAC")
        };
        
        
        public Tag<double> MDB_B__QF2_3 = new Tag<double>
        {
            TagName = "ГРЩ-B, QF2.3, Чиллер №3",
            TagChannelDatabase = new TagChannelDatabase(Data.MsDatabase, 
                "Энергоменеджмент.Счетчики.Модуль 1, MDB-B, QF2_3, PAC")
        };
        
        public Tag<double> MDB_B__QF2_4 = new Tag<double>
        {
            TagName = "ГРЩ-B, QF2.4, Гидромодуль №1",
            TagChannelDatabase = new TagChannelDatabase(Data.MsDatabase, 
                "Энергоменеджмент.Счетчики.Модуль 1, MDB-A, QF2_4, PAC")
        };
        
        public Tag<double> MDB_B__QF2_5 = new Tag<double>
        {
            TagName = "ГРЩ-B, QF2.5, Гидромодуль №2",
            TagChannelDatabase = new TagChannelDatabase(Data.MsDatabase, 
                "Энергоменеджмент.Счетчики.Модуль 1, MDB-A, QF2_5, PAC")
        };
        
        public Tag<double> MDB_B__QF2_6 = new Tag<double>
        {
            TagName = "ГРЩ-B, QF2.6, Гидромодуль №3",
            TagChannelDatabase = new TagChannelDatabase(Data.MsDatabase, 
                "Энергоменеджмент.Счетчики.Модуль 1, MDB-A, QF2_6, PAC")
        };
        
        public Tag<double> MDB_B__QF2_7 = new Tag<double>
        {
            TagName = "ГРЩ-B, QF2.7, Резерв",
            TagChannelDatabase = new TagChannelDatabase(Data.MsDatabase, 
                "Энергоменеджмент.Счетчики.Модуль 1, MDB-B, QF2_7, PAC")
        };
        
        public Tag<double> MDB_B__QF2_8 = new Tag<double>
        {
            TagName = "ГРЩ-B, QF2.8, ЩСН-ДЭС №1",
            TagChannelDatabase = new TagChannelDatabase(Data.MsDatabase, 
                "Энергоменеджмент.Счетчики.Модуль 1, MDB-B, QF2_8, PAC")
        };
        
        public Tag<double> MDB_B__QF2_9 = new Tag<double>
        {
            TagName = "ГРЩ-B, QF2.9, ЩСН-ДЭС №2",
            TagChannelDatabase = new TagChannelDatabase(Data.MsDatabase, 
                "Энергоменеджмент.Счетчики.Модуль 1, MDB-B, QF2_9, PAC")
        };
        
        public Tag<double> MDB_B__QF2_10 = new Tag<double>
        {
            TagName = "ГРЩ-B, QF2.10, IT-HVAC-DB-B",
            TagChannelDatabase = new TagChannelDatabase(Data.MsDatabase, 
                "Энергоменеджмент.Счетчики.Модуль 1, MDB-B, QF2_10, PAC")
        };
        
        public Tag<double> MDB_B__QF2_11 = new Tag<double>
        {
            TagName = "ГРЩ-B, QF2.11, IT-LSP-DB-AB",
            TagChannelDatabase = new TagChannelDatabase(Data.MsDatabase, 
                "Энергоменеджмент.Счетчики.Модуль 1, MDB-B, QF2_11, PAC")
        };
        
        public Tag<double> MDB_B__QF2_12 = new Tag<double>
        {
            TagName = "ГРЩ-B, QF2.12, ER-LSP-DB-AB",
            TagChannelDatabase = new TagChannelDatabase(Data.MsDatabase, 
                "Энергоменеджмент.Счетчики.Модуль 1, MDB-B, QF2_12, PAC")
        };
        
        public Tag<double> MDB_B__QF2_13 = new Tag<double>
        {
            TagName = "ГРЩ-B, QF2.13, ЩР-ТК",
            TagChannelDatabase = new TagChannelDatabase(Data.MsDatabase, 
                "Энергоменеджмент.Счетчики.Модуль 1, MDB-B, QF2_13, PAC")
        };
        
        public Tag<double> MDB_B__QF2_14 = new Tag<double>
        {
            TagName = "ГРЩ-B, QF2.14, BATT-DB-AB",
            TagChannelDatabase = new TagChannelDatabase(Data.MsDatabase, 
                "Энергоменеджмент.Счетчики.Модуль 1, MDB-B, QF2_14, PAC")
        };
        
        public Tag<double> UPS_MDB_A__QF3_1 = new Tag<double>
        {
            TagName = "РЩБП-А, QF3.1, Машзал",
            TagChannelDatabase = new TagChannelDatabase(Data.MsDatabase, 
                "Энергоменеджмент.Счетчики.Модуль 1, UPS-MDB-A, QF3_1, PAC")
        };
        
        public Tag<double> UPS_MDB_A__QF4_1 = new Tag<double>
        {
            TagName = "РЩБП-А, QF4.1, Гидромодуль №1",
            TagChannelDatabase = new TagChannelDatabase(Data.MsDatabase, 
                "Энергоменеджмент.Счетчики.Модуль 1, UPS-MDB-A, QF4_1, PAC")
        };
        
        public Tag<double> UPS_MDB_A__QF4_2 = new Tag<double>
        {
            TagName = "РЩБП-А, QF4.2, Гидромодуль №2",
            TagChannelDatabase = new TagChannelDatabase(Data.MsDatabase, 
                "Энергоменеджмент.Счетчики.Модуль 1, UPS-MDB-A, QF4_2, PAC")
        };
        
        public Tag<double> UPS_MDB_A__QF4_3 = new Tag<double>
        {
            TagName = "РЩБП-А, QF4.3, Гидромодуль №3",
            TagChannelDatabase = new TagChannelDatabase(Data.MsDatabase, 
                "Энергоменеджмент.Счетчики.Модуль 1, UPS-MDB-A, QF4_3, PAC")
        };
        
        public Tag<double> UPS_MDB_A__QF4_4 = new Tag<double>
        {
            TagName = "РЩБП-А, QF4.4, IT-HVAC-UPS-DB-AB",
            TagChannelDatabase = new TagChannelDatabase(Data.MsDatabase, 
                "Энергоменеджмент.Счетчики.Модуль 1, UPS-MDB-A, QF4_4, PAC")
        };
        
        public Tag<double> UPS_MDB_A__QF4_5 = new Tag<double>
        {
            TagName = "РЩБП-А, QF4.5, ER-UPS-DB-A",
            TagChannelDatabase = new TagChannelDatabase(Data.MsDatabase, 
                "Энергоменеджмент.Счетчики.Модуль 1, UPS-MDB-A, QF4_5, PAC")
        };
        
        public Tag<double> UPS_MDB_A__QF4_6 = new Tag<double>
        {
            TagName = "РЩБП-А, QF4.6, ЩСН-ДЭС №1",
            TagChannelDatabase = new TagChannelDatabase(Data.MsDatabase, 
                "Энергоменеджмент.Счетчики.Модуль 1, UPS-MDB-A, QF4_6, PAC")
        };
        
        public Tag<double> UPS_MDB_A__QF4_7 = new Tag<double>
        {
            TagName = "РЩБП-А, QF4.7, ЩСН-ДЭС №2",
            TagChannelDatabase = new TagChannelDatabase(Data.MsDatabase, 
                "Энергоменеджмент.Счетчики.Модуль 1, UPS-MDB-A, QF4_7, PAC")
        };
        
        public Tag<double> UPS_MDB_A__QF4_8 = new Tag<double>
        {
            TagName = "РЩБП-А, QF4.8, ЩР-ТК",
            TagChannelDatabase = new TagChannelDatabase(Data.MsDatabase, 
                "Энергоменеджмент.Счетчики.Модуль 1, UPS-MDB-A, QF4_8, PAC")
        };
        
        public Tag<double> UPS_MDB_A__QF4_9 = new Tag<double>
        {
            TagName = "РЩБП-А, QF4.9, ЩР-УВ1-А",
            TagChannelDatabase = new TagChannelDatabase(Data.MsDatabase, 
                "Энергоменеджмент.Счетчики.Модуль 1, UPS-MDB-A, QF4_9, PAC")
        };
        
        public Tag<double> UPS_MDB_A__QF4_10 = new Tag<double>
        {
            TagName = "РЩБП-А, QF4.10, ЩР-УВ2-А",
            TagChannelDatabase = new TagChannelDatabase(Data.MsDatabase, 
                "Энергоменеджмент.Счетчики.Модуль 1, UPS-MDB-A, QF4_10, PAC")
        };
        
        public Tag<double> UPS_MDB_A__QF4_11 = new Tag<double>
        {
            TagName = "РЩБП-А, QF4.11, Резерв",
            TagChannelDatabase = new TagChannelDatabase(Data.MsDatabase, 
                "Энергоменеджмент.Счетчики.Модуль 1, UPS-MDB-A, QF4_11, PAC")
        };
        
        public Tag<double> UPS_MDB_A__QF4_12 = new Tag<double>
        {
            TagName = "РЩБП-А, QF4.12, Резерв",
            TagChannelDatabase = new TagChannelDatabase(Data.MsDatabase, 
                "Энергоменеджмент.Счетчики.Модуль 1, UPS-MDB-A, QF4_12, PAC")
        };
        
        public Tag<double> UPS_MDB_A__QF4_13 = new Tag<double>
        {
            TagName = "РЩБП-А, QF4.13, Резерв",
            TagChannelDatabase = new TagChannelDatabase(Data.MsDatabase, 
                "Энергоменеджмент.Счетчики.Модуль 1, UPS-MDB-A, QF4_13, PAC")
        };
        
        public Tag<double> UPS_MDB_A__QF4_14 = new Tag<double>
        {
            TagName = "РЩБП-А, QF4.14, Резерв",
            TagChannelDatabase = new TagChannelDatabase(Data.MsDatabase, 
                "Энергоменеджмент.Счетчики.Модуль 1, UPS-MDB-A, QF4_14, PAC")
        };
        
        public Tag<double> UPS_MDB_A__QF4_15 = new Tag<double>
        {
            TagName = "РЩБП-А, QF4.15, Резерв",
            TagChannelDatabase = new TagChannelDatabase(Data.MsDatabase, 
                "Энергоменеджмент.Счетчики.Модуль 1, UPS-MDB-A, QF4_15, PAC")
        };
        
        public Tag<double> UPS_MDB_A__QF4_16 = new Tag<double>
        {
            TagName = "РЩБП-А, QF4.16, ЩР-АСДУ",
            TagChannelDatabase = new TagChannelDatabase(Data.MsDatabase, 
                "Энергоменеджмент.Счетчики.Модуль 1, UPS-MDB-A, QF4_16, PAC")
        };
        
        public Tag<double> UPS_MDB_B__QF3_1 = new Tag<double>
        {
            TagName = "РЩБП-B, QF3.1, Машзал",
            TagChannelDatabase = new TagChannelDatabase(Data.MsDatabase, 
                "Энергоменеджмент.Счетчики.Модуль 1, UPS-MDB-B, QF3_1, PAC")
        };
        
        public Tag<double> UPS_MDB_AB__QF2_1 = new Tag<double>
        {
            TagName = "РЩБП-B, QF2.1, РЩБП-A",
            TagChannelDatabase = new TagChannelDatabase(Data.MsDatabase, 
                "Энергоменеджмент.Счетчики.Модуль 1, UPS-MDB-AB, QF2_1, PAC")
        };
        
        public Tag<double> UPS_MDB_AB__QF2_2 = new Tag<double>
        {
            TagName = "РЩБП-B, QF2.2, РЩБП-B",
            TagChannelDatabase = new TagChannelDatabase(Data.MsDatabase, 
                "Энергоменеджмент.Счетчики.Модуль 1, UPS-MDB-AB, QF2_2, PAC")
        };

        public Tag<double> temperature = new Tag<double>
        {
            TagName = "Темп. наружного воздуха",
            TagChannelDatabase = new TagChannelDatabase(Data.MsDatabase, 
                "Энергоменеджмент.Темп наружного воздуха.Средняя темп.Выходы.Average_temp")
        };

        public Tag<double> tagSum = new Tag<double>
        {
            TagName = "Суммарное потребление"
        };


        public Tag<double> chiller1 = new Tag<double>
        {
            TagName = "Модуль 1, чиллер 1"
        };
        
        public Tag<double> chiller2 = new Tag<double>
        {
            TagName = "Модуль 1, чиллер 2"
        };
        
        public Tag<double> chiller3 = new Tag<double>
        {
            TagName = "Модуль 1, чиллер 3"
        };
        
        public Tag<double> chillers = new Tag<double>
        {
            TagName = "Модуль 1, чиллеры"
        };
        
        public Tag<double> hydro1 = new Tag<double>
        {
            TagName = "Модуль 1, гидромодуль 1"
        };
        
        public Tag<double> hydro2 = new Tag<double>
        {
            TagName = "Модуль 1, гидромодуль 2"
        };
        
        public Tag<double> hydro3 = new Tag<double>
        {
            TagName = "Модуль 1, гидромодуль 3"
        };
        
        public Tag<double> hydros = new Tag<double>
        {
            TagName = "Модуль 1, гидромодули"
        };


        public Tag<double> PUE = new Tag<double>
        {
            TagName = "Процент Э/Э на машзал"
        };

        public Tag<double> MachineHall = new Tag<double>
        {
            TagName = "Нагрузка на машзал"
        };

        public TGEnergy()
        {
            tagSum.ConfDerivedFromTags(
                "[Tag1] + [Tag2]",
                MDB_A__QS1, SimplifyType.Increment,
                MDB_B__QS1, SimplifyType.Increment);
            
            chiller1.ConfDerivedFromTags(
                "[Tag1] + [Tag2]",
                MDB_A__QF2_1, SimplifyType.Increment,
                MDB_B__QF2_1, SimplifyType.Increment
                );
            
            chiller2.ConfDerivedFromTags(
                "[Tag1] + [Tag2]",
                MDB_A__QF2_2, SimplifyType.Increment,
                MDB_B__QF2_2, SimplifyType.Increment
            );
            
            chiller3.ConfDerivedFromTags(
                "[Tag1] + [Tag2]",
                MDB_A__QF2_3, SimplifyType.Increment,
                MDB_B__QF2_3, SimplifyType.Increment
            );
            
            chillers.ConfDerivedFromTags(
                "[Tag1] + [Tag2] + [Tag3]",
                chiller1, SimplifyType.Increment,
                chiller2, SimplifyType.Increment,
                chiller3, SimplifyType.Increment
            );
            
            hydro1.ConfDerivedFromTags(
                "[Tag1] + [Tag2]",
                MDB_B__QF2_4, SimplifyType.Increment,
                UPS_MDB_A__QF4_1, SimplifyType.Increment
            );
            
            hydro2.ConfDerivedFromTags(
                "[Tag1] + [Tag2]",
                MDB_B__QF2_5, SimplifyType.Increment,
                UPS_MDB_A__QF4_2, SimplifyType.Increment
            );
            
            hydro3.ConfDerivedFromTags(
                "[Tag1] + [Tag2]",
                MDB_B__QF2_6, SimplifyType.Increment,
                UPS_MDB_A__QF4_3, SimplifyType.Increment
            );
            
            hydros.ConfDerivedFromTags(
                "[Tag1] + [Tag2] + [Tag3]",
                hydro1, SimplifyType.Increment,
                hydro2, SimplifyType.Increment,
                hydro3, SimplifyType.Increment
            );
            
            PUE.ConfDerivedFromTags(
                "([Tag1] + [Tag2]) / ([Tag3] + [Tag4])",
                MDB_A__QS1, SimplifyType.Increment,
                MDB_B__QS1, SimplifyType.Increment,
                UPS_MDB_A__QF3_1, SimplifyType.Increment,
                UPS_MDB_B__QF3_1, SimplifyType.Increment
                );
            
            MachineHall.ConfDerivedFromTags(
                "[Tag1] + [Tag2]",
                UPS_MDB_A__QF3_1, SimplifyType.Increment,
                UPS_MDB_B__QF3_1, SimplifyType.Increment);
        }
    }
}
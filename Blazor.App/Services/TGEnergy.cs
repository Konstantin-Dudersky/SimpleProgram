using SimpleProgram.Lib;
using SimpleProgram.Lib.Archives;
using SimpleProgram.Lib.Tag;

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
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, MDB-A, QS1, PAC",
            TagName = "ГРЩ-А, QS1, Ввод"
        };
        
        public Tag<double> MDB_A__QF1_1 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, MDB-A, QF1_1, PAC",
            TagName = "ГРЩ-А, QF1.1, РЩБП-AB"
        };
        
        public Tag<double> MDB_A__QF1_2 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, MDB-A, QF1_2, PAC",
            TagName = "ГРЩ-А, QF1.2, UPS-1A"
        };
        
        public Tag<double> MDB_A__QF1_3 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, MDB-A, QF1_3, PAC",
            TagName = "ГРЩ-А, QF1.3, UPS-2A"
        };
        
        public Tag<double> MDB_A__QF1_4 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, MDB-A, QF1_4, PAC",
            TagName = "ГРЩ-А, QF1.4, UPS-3A"
        };
        
        public Tag<double> MDB_A__QF1_5 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, MDB-A, QF1_5, PAC",
            TagName = "ГРЩ-А, QF1.5, UPS-4A"
        };
        
        public Tag<double> MDB_A__QF2_1 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, MDB-A, QF2_1, PAC",
            TagName = "ГРЩ-А, QF2.1, Чиллер №1"
        };
        
        
        public Tag<double> MDB_A__QF2_2 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, MDB-A, QF2_2, PAC",
            TagName = "ГРЩ-А, QF2.2, Чиллер №2"
        };
        
        public Tag<double> MDB_A__QF2_3 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, MDB-A, QF2_3, PAC",
            TagName = "ГРЩ-А, QF2.3, Чиллер №3"
        };
        
        public Tag<double> MDB_A__QF2_4 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, MDB-A, QF2_4, PAC",
            TagName = "ГРЩ-А, QF2.4, Резерв"
        };
        
        public Tag<double> MDB_A__QF2_5 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, MDB-A, QF2_5, PAC",
            TagName = "ГРЩ-А, QF2.5, BATT-DB-AB"
        };
        
        public Tag<double> MDB_A__QF2_6 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, MDB-A, QF2_6, PAC",
            TagName = "ГРЩ-А, QF2.6, Резерв"
        };
        
        public Tag<double> MDB_A__QF2_7 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, MDB-A, QF2_7, PAC",
            TagName = "ГРЩ-А, QF2.7, ER-LSP-DB-AB"
        };
        
        public Tag<double> MDB_A__QF2_8 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, MDB-A, QF2_8, PAC",
            TagName = "ГРЩ-А, QF2.8, IT-LSP-DB-AB"
        };
        
        public Tag<double> MDB_A__QF3_1 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, MDB-A, QF3_1, PAC",
            TagName = "ГРЩ-А, QF3.1, Резерв"
        };
        
        public Tag<double> MDB_A__QF3_2 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, MDB-A, QF3_2, PAC",
            TagName = "ГРЩ-А, QF3.2, Резерв"
        };
        
        public Tag<double> MDB_A__QF3_3 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, MDB-A, QF3_3, PAC",
            TagName = "ГРЩ-А, QF3.3, Резерв"
        };
        
        public Tag<double> MDB_A__QF3_4 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, MDB-A, QF3_4, PAC",
            TagName = "ГРЩ-А, QF3.4, ЩО"
        };
        
        public Tag<double> MDB_A__QF3_5 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, MDB-A, QF3_5, PAC",
            TagName = "ГРЩ-А, QF3.5, Резерв"
        };
        
        public Tag<double> MDB_A__QF3_6 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, MDB-A, QF3_6, PAC",
            TagName = "ГРЩ-А, QF3.6, FIRE-DB-AB"
        };

        public Tag<double> MDB_B__QS1 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, MDB-B, QS1, PAC",
            TagName = "ГРЩ-B, QS1, Ввод"
        };
        
        public Tag<double> MDB_B__QF1_1 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, MDB-B, QF1_1, PAC",
            TagName = "ГРЩ-B, QF1.1, ЩР-АСДУ"
        };
        
        public Tag<double> MDB_B__QF1_2 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, MDB-B, QF1_2, PAC",
            TagName = "ГРЩ-B, QF1.2, ЩРЭ1"
        };
        
        public Tag<double> MDB_B__QF1_3 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, MDB-B, QF1_3, PAC",
            TagName = "ГРЩ-B, QF1.3, РЩБП-B"
        };
        
        public Tag<double> MDB_B__QF1_4 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, MDB-B, QF1_4, PAC",
            TagName = "ГРЩ-B, QF1.4, FIRE-DB-AB"
        };
        
        public Tag<double> MDB_B__QF1_5 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, MDB-B, QF1_5, PAC",
            TagName = "ГРЩ-B, QF1.5, ЩАО1"
        };
        
        public Tag<double> MDB_B__QF1_6 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, MDB-B, QF1_6, PAC",
            TagName = "ГРЩ-B, QF1.6, ЩР-УВ2-В"
        };
        
        public Tag<double> MDB_B__QF1_7 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, MDB-B, QF1_7, PAC",
            TagName = "ГРЩ-B, QF1.7, ЩР-УВ1-В"
        };
        
        public Tag<double> MDB_B__QF1_8 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, MDB-B, QF1_8, PAC",
            TagName = "ГРЩ-B, QF1.8, Резерв"
        };
        
        public Tag<double> MDB_B__QF2_1 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, MDB-B, QF2_1, PAC",
            TagName = "ГРЩ-B, QF2.1, Чиллер №1"
        };
        
        
        public Tag<double> MDB_B__QF2_2 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, MDB-B, QF2_2, PAC",
            TagName = "ГРЩ-B, QF2.2, Чиллер №2"
        };
        
        
        public Tag<double> MDB_B__QF2_3 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, MDB-B, QF2_3, PAC",
            TagName = "ГРЩ-B, QF2.3, Чиллер №3"
        };
        
        public Tag<double> MDB_B__QF2_4 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, MDB-A, QF2_4, PAC",
            TagName = "ГРЩ-B, QF2.4, Гидромодуль №1"
        };
        
        public Tag<double> MDB_B__QF2_5 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, MDB-A, QF2_5, PAC",
            TagName = "ГРЩ-B, QF2.5, Гидромодуль №2"
        };
        
        public Tag<double> MDB_B__QF2_6 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, MDB-A, QF2_6, PAC",
            TagName = "ГРЩ-B, QF2.6, Гидромодуль №3"
        };
        
        public Tag<double> MDB_B__QF2_7 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, MDB-B, QF2_7, PAC",
            TagName = "ГРЩ-B, QF2.7, Резерв"
        };
        
        public Tag<double> MDB_B__QF2_8 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, MDB-B, QF2_8, PAC",
            TagName = "ГРЩ-B, QF2.8, ЩСН-ДЭС №1"
        };
        
        public Tag<double> MDB_B__QF2_9 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, MDB-B, QF2_9, PAC",
            TagName = "ГРЩ-B, QF2.9, ЩСН-ДЭС №2"
        };
        
        public Tag<double> MDB_B__QF2_10 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, MDB-B, QF2_10, PAC",
            TagName = "ГРЩ-B, QF2.10, IT-HVAC-DB-B"
        };
        
        public Tag<double> MDB_B__QF2_11 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, MDB-B, QF2_11, PAC",
            TagName = "ГРЩ-B, QF2.11, IT-LSP-DB-AB"
        };
        
        public Tag<double> MDB_B__QF2_12 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, MDB-B, QF2_12, PAC",
            TagName = "ГРЩ-B, QF2.12, ER-LSP-DB-AB"
        };
        
        public Tag<double> MDB_B__QF2_13 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, MDB-B, QF2_13, PAC",
            TagName = "ГРЩ-B, QF2.13, ЩР-ТК"
        };
        
        public Tag<double> MDB_B__QF2_14 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, MDB-B, QF2_14, PAC",
            TagName = "ГРЩ-B, QF2.14, BATT-DB-AB"
        };
        
        public Tag<double> UPS_MDB_A__QF3_1 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, UPS-MDB-A, QF3_1, PAC",
            TagName = "РЩБП-А, QF3.1, Машзал"
        };
        
        public Tag<double> UPS_MDB_A__QF4_1 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, UPS-MDB-A, QF4_1, PAC",
            TagName = "РЩБП-А, QF4.1, Гидромодуль №1"
        };
        
        public Tag<double> UPS_MDB_A__QF4_2 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, UPS-MDB-A, QF4_2, PAC",
            TagName = "РЩБП-А, QF4.1, Гидромодуль №2"
        };
        
        public Tag<double> UPS_MDB_A__QF4_3 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, UPS-MDB-A, QF4_3, PAC",
            TagName = "РЩБП-А, QF4.1, Гидромодуль №3"
        };
        
        public Tag<double> UPS_MDB_A__QF4_4 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, UPS-MDB-A, QF4_4, PAC",
            TagName = "РЩБП-А, QF4.4, IT-HVAC-UPS-DB-AB"
        };
        
        public Tag<double> UPS_MDB_A__QF4_5 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, UPS-MDB-A, QF4_5, PAC",
            TagName = "РЩБП-А, QF4.5, ER-UPS-DB-A"
        };
        
        public Tag<double> UPS_MDB_A__QF4_6 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, UPS-MDB-A, QF4_6, PAC",
            TagName = "РЩБП-А, QF4.6, ЩСН-ДЭС №1"
        };
        
        public Tag<double> UPS_MDB_A__QF4_7 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, UPS-MDB-A, QF4_7, PAC",
            TagName = "РЩБП-А, QF4.7, ЩСН-ДЭС №2"
        };
        
        public Tag<double> UPS_MDB_A__QF4_8 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, UPS-MDB-A, QF4_8, PAC",
            TagName = "РЩБП-А, QF4.8, ЩР-ТК"
        };
        
        public Tag<double> UPS_MDB_A__QF4_9 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, UPS-MDB-A, QF4_9, PAC",
            TagName = "РЩБП-А, QF4.9, ЩР-УВ1-А"
        };
        
        public Tag<double> UPS_MDB_A__QF4_10 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, UPS-MDB-A, QF4_10, PAC",
            TagName = "РЩБП-А, QF4.10, ЩР-УВ2-А"
        };
        
        public Tag<double> UPS_MDB_A__QF4_11 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, UPS-MDB-A, QF4_11, PAC",
            TagName = "РЩБП-А, QF4.11, Резерв"
        };
        
        public Tag<double> UPS_MDB_A__QF4_12 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, UPS-MDB-A, QF4_12, PAC",
            TagName = "РЩБП-А, QF4.12, Резерв"
        };
        
        public Tag<double> UPS_MDB_A__QF4_13 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, UPS-MDB-A, QF4_13, PAC",
            TagName = "РЩБП-А, QF4.13, Резерв"
        };
        
        public Tag<double> UPS_MDB_A__QF4_14 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, UPS-MDB-A, QF4_14, PAC",
            TagName = "РЩБП-А, QF4.14, Резерв"
        };
        
        public Tag<double> UPS_MDB_A__QF4_15 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, UPS-MDB-A, QF4_15, PAC",
            TagName = "РЩБП-А, QF4.15, Резерв"
        };
        
        public Tag<double> UPS_MDB_A__QF4_16 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, UPS-MDB-A, QF4_16, PAC",
            TagName = "РЩБП-А, QF4.16, ЩР-АСДУ"
        };
        
        public Tag<double> UPS_MDB_B__QF3_1 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, UPS-MDB-B, QF3_1, PAC",
            TagName = "РЩБП-B, QF3.1, Машзал"
        };
        
        public Tag<double> UPS_MDB_AB__QF2_1 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, UPS-MDB-AB, QF2_1, PAC",
            TagName = "РЩБП-B, QF2.1, РЩБП-A"
        };
        
        public Tag<double> UPS_MDB_AB__QF2_2 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, UPS-MDB-AB, QF2_2, PAC",
            TagName = "РЩБП-B, QF2.2, РЩБП-B"
        };

        public Tag<double> temperature = new Tag<double>
        {
            TagName = "Темп. наружного воздуха",
            ArchiveTagId = "Энергоменеджмент.Темп наружного воздуха.Средняя темп.Выходы.Average_temp"
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


        public TGEnergy()
        {
            ArchiveDefault = Data.MsArchive;

            
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
        }
    }
}
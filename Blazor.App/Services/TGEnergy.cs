using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using SimpleProgram.Lib;
using SimpleProgram.Lib.Archives;
using SimpleProgram.Lib.OpcUa;
using SimpleProgram.Lib.Tag;
// ReSharper disable StringLiteralTypo
// ReSharper disable InconsistentNaming
// ReSharper disable FieldCanBeMadeReadOnly.Global
// ReSharper disable IdentifierTypo

namespace Blazor.App.Services
{
    public class TGEnergy : TagGroupBase
    {
        public Tag<double> MDB_A__QS1 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, MDB-A, QS1, PAC",
            TagName = "ГРЩ-А, QS1, Ввод"
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
        
        public Tag<double> MDB_A__QF2_7 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, MDB-A, QF2_7, PAC",
            TagName = "ГРЩ-А, QF2.7, ER-LSP-DB-AB"
        };

        public Tag<double> MDB_B__QS1 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, MDB-B, QS1, PAC",
            TagName = "ГРЩ-B, QS1, Ввод"
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
        
        public Tag<double> MDB_B__QF2_10 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, MDB-B, QF2_10, PAC",
            TagName = "ГРЩ-B, QF2.10, IT-HVAC-DB-B"
        };
        
        public Tag<double> MDB_B__QF2_12 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, MDB-B, QF2_10, PAC",
            TagName = "ГРЩ-B, QF2.12, ER-LSP-DB-AB"
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
        
        public Tag<double> UPS_MDB_B__QF3_1 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, UPS-MDB-B, QF3_1, PAC",
            TagName = "РЩБП-B, QF3.1, Машзал"
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
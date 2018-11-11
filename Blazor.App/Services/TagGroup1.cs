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
    public class TagGroup1 : TagGroupBase
    {
        public int count;

        public Tag<double> MDBA_QS1 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, MDB-A, QS1, PAC",
        };

        public Tag<double> MDBB_QS1 = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Счетчики.Модуль 1, MDB-B, QS1, PAC"
        };
        

        public readonly Tag<int> tag1 = new Tag<int>();
        public Tag<int> tag2 = new Tag<int>();

        public readonly Tag<bool> tagBool = new Tag<bool>();

        public Tag<double> temperature = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Темп наружного воздуха.Средняя темп.Выходы.Average_temp"
        };

        public Tag<double> tagSum = new Tag<double>();


        private Timer timer;
        private Timer timer2;

        public TagGroup1(Archive archiveDefault = null)
        {
            ArchiveDefault = Data.MsArchive;

            timer = new Timer(obj => tag1.SetValue(tag1.GetValue<int>() + 1), null, 0, 5);

            var tagLink = MDBB_QS1.ConvertTo<int>();

            timer2 = new Timer(obj => tagLink.Value += 2, null, 0, 500);
            
            tagSum.ConfDerivedFromTags(
                (t1, t2, t3, t4, t5, t6, t7, t8, t9, t10) => t1 + t2,
                MDBA_QS1, SimplifyType.Increment,
                MDBB_QS1, SimplifyType.Increment);
        }
    }
}
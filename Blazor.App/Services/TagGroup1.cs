using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using SimpleProgram.Lib;
using SimpleProgram.Lib.Archives;

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

        public Tag<int> tag1 = new Tag<int>();
        public Tag<int> tag2 = new Tag<int>();

        public Tag<bool> tagBool = new Tag<bool>();
        public TagGroup2 TagGroup2 = new TagGroup2();

        public Tag<double> temperature = new Tag<double>
        {
            ArchiveTagId = "Энергоменеджмент.Темп наружного воздуха.Средняя темп.Выходы.Average_temp"
        };


        public Timer timer;
        public Timer timer2;

        public TagGroup1(Archive archiveDefault = null)
        {
            ArchiveDefault = Data.MsArchive;

            timer = new Timer(obj => tag1.SetValue(tag1.GetValue<int>() + 1), null, 0, 5);

            var tagLink = MDBB_QS1.Conv<int>();

            timer2 = new Timer(obj => tagLink.Value += 2, null, 0, 500);
        }
    }
}
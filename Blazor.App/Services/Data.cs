using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using SimpleProgram.Lib;
using SimpleProgram.Lib.Archives;
using SimpleProgram.Lib.Archives.MasterScada;
using System.Text;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Blazor.App.Services
{
    public class Data
    {
        public readonly Dictionary<string, ITag> TagDict = new Dictionary<string, ITag>();

        public TagGroup1 TagGroup1;
        public static readonly Archive MsArchive = new Archive();


        private const int RefreshTime = 1000;

        private readonly Timer RefreshTimer;


        public Data()
        {
            MsArchive.SetParams<MasterScadaDb>(Providers.PostgreSql,
                "Host=localhost;Database=energy;Username=postgres;Password=123");

            TagGroup1 = new TagGroup1();

            RefreshTimer = new Timer(obj => OnRefresh?.Invoke(), null, 0, RefreshTime);

            // находим ссылки на архивы
            FillTagArchives();
        }


        public event Action OnRefresh;


        public static void StartUp()
        {
        }

        private void FillTagArchives()
        {
            TapGroupProcessing(this, "");

            // для вывода в консоли
            StringBuilder str = new StringBuilder("----------\n");
            str.AppendLine("TagDict:");

            foreach (KeyValuePair<string, ITag> tag in TagDict)
            {
                str.AppendLine($"{tag.Key}:\t{tag.Value.TagId}\t{tag.Value.Archive}");
            }

            Console.WriteLine(str);
        }

        private void TapGroupProcessing(object rootTagGroup, string prefix)
        {
            Console.WriteLine("prefix: " + prefix);

            foreach (FieldInfo field in rootTagGroup.GetType().GetFields())
            {
                // находим группы тегов
                if (typeof(TagGroupBase).IsAssignableFrom(field.FieldType))
                {
                    // ссылка на группу тегов
                    TagGroupBase obj = (TagGroupBase) field.GetValue(rootTagGroup);

                    TapGroupProcessing(obj, (prefix == "" ? "" : $"{prefix}.") + field.Name);
                }
                else if (typeof(ITag).IsAssignableFrom(field.FieldType))
                {
                    // ссылка на тег
                    object obj = field.GetValue(rootTagGroup);

                    ITag tag = (ITag) obj;

                    // ID тега
                    tag.TagId = prefix + "." + field.Name;

                    // имя тега
                    tag.TagName = tag.TagName ?? tag.TagId;

                    // ID архивного тега
                    tag.ArchiveTagId = tag.ArchiveTagId ?? tag.TagId;
                    
                    // ссылка на архив
                    tag.Archive = tag.Archive ?? ((TagGroupBase) rootTagGroup).ArchiveDefault;

                    // добавляем в словарь архивных тегов
                    TagDict.Add(tag.TagId, tag);
                }
            }
        }
    }
}
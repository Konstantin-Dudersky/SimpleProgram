using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.Extensions.Configuration;
using SimpleProgram.Lib.Tag;

namespace SimpleProgram.Lib
{
    public class DataBase
    {
        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        private Timer RefreshTimer { get; }
        public readonly SortedDictionary<string, ITag> TagDict = new SortedDictionary<string, ITag>();

        /// <summary>
        /// Опциональный файл конфигурации appsettings.local.json
        /// </summary>
        protected static readonly IConfiguration Config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.local.json", true, true)
            .Build();

        protected DataBase(int refreshTime = 5000)
        {
            RefreshTime = refreshTime;
            RefreshTimer = new Timer(obj => OnRefresh?.Invoke(), null, 0, RefreshTime);
        }

        private int RefreshTime { get; }

        public event Action OnRefresh;

        protected void InitTagDict()
        {
            TapGroupProcessing(this, "");
        }

        private void TapGroupProcessing(object rootTagGroup, string prefix)
        {
            foreach (var field in rootTagGroup.GetType().GetFields())
                // находим группы тегов
                if (typeof(TagGroupBase).IsAssignableFrom(field.FieldType))
                {
                    // ссылка на группу тегов
                    var tagGroup = (TagGroupBase) field.GetValue(rootTagGroup);

                    TapGroupProcessing(tagGroup, (prefix == "" ? "" : $"{prefix}.") + field.Name);
                }
                else if (typeof(ITag).IsAssignableFrom(field.FieldType))
                {
                    // ссылка на тег
                    var tag = (ITag) field.GetValue(rootTagGroup);

                    // ID тега
                    tag.TagId = prefix + "." + field.Name;

                    // имя тега
                    tag.TagName = tag.TagName ?? tag.TagId;

                    // ID архивного тега
//                    tag.ArchiveTagId = tag.ArchiveTagId ?? tag.TagId;

                    // ссылка на архив
//                    tag.Archive = tag.Archive ?? ((TagGroupBase) rootTagGroup).ArchiveDefault;

                    // добавляем в словарь архивных тегов
                    TagDict.Add(tag.TagId, tag);
                }
        }
    }
}
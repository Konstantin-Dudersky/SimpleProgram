using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Text;
using System.Threading;

namespace SimpleProgram.Lib
{
    public class DataBase
    {
        private readonly Timer _refreshTimer;
        public readonly Dictionary<string, ITag> TagDict = new Dictionary<string, ITag>();

        /// <summary>
        /// 4 23423 234 2
        /// </summary>
        /// <param name="refreshTime"> 3423423423 4</param>
        protected DataBase(int refreshTime = 1000)
        {
            RefreshTime = refreshTime;
            _refreshTimer = new Timer(obj => OnRefresh?.Invoke(), null, 0, RefreshTime);
        }

        private int RefreshTime { get; }

        public event Action OnRefresh;

        protected void InitTagDict()
        {
            TapGroupProcessing(this, "");

            return;
            // для вывода в консоли
            var str = new StringBuilder("----------\n");
            str.AppendLine("TagDict:");

            foreach (var tag in TagDict) str.AppendLine($"{tag.Key}:\t{tag.Value.TagId}\t{tag.Value.Archive}\t{tag.Value.GetValue<double>()}");

            Console.WriteLine(str);
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
                    tag.ArchiveTagId = tag.ArchiveTagId ?? tag.TagId;

                    // ссылка на архив
                    tag.Archive = tag.Archive ?? ((TagGroupBase) rootTagGroup).ArchiveDefault;

                    // добавляем в словарь архивных тегов
                    TagDict.Add(tag.TagId, tag);
                }
        }
    }
}
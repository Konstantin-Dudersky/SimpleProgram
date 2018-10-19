using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SimpleProgram.Lib
{
    public class DataBase
    {
        private readonly Timer _refreshTimer;
        public readonly Dictionary<string, ITag> TagDict = new Dictionary<string, ITag>();

        protected DataBase()
        {
            _refreshTimer = new Timer(obj => OnRefresh?.Invoke(), null, 0, RefreshTime);
        }

        protected int RefreshTime { private get; set; } = 1000;

        public event Action OnRefresh;

        protected void InitTagDict()
        {
            TapGroupProcessing(this, "");

            // для вывода в консоли
            var str = new StringBuilder("----------\n");
            str.AppendLine("TagDict:");

            foreach (var tag in TagDict) str.AppendLine($"{tag.Key}:\t{tag.Value.TagId}\t{tag.Value.Archive}");

            Console.WriteLine(str);
        }

        private void TapGroupProcessing(object rootTagGroup, string prefix)
        {
            Console.WriteLine("prefix: " + prefix);

            foreach (var field in rootTagGroup.GetType().GetFields())
                // находим группы тегов
                if (typeof(TagGroupBase).IsAssignableFrom(field.FieldType))
                {
                    // ссылка на группу тегов
                    var obj = (TagGroupBase) field.GetValue(rootTagGroup);

                    TapGroupProcessing(obj, (prefix == "" ? "" : $"{prefix}.") + field.Name);
                }
                else if (typeof(ITag).IsAssignableFrom(field.FieldType))
                {
                    // ссылка на тег
                    var obj = field.GetValue(rootTagGroup);

                    var tag = (ITag) obj;

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
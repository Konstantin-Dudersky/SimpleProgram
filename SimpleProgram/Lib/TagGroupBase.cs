using System;
using System.Collections.Generic;
using SimpleProgram.Lib.Archives;
using System.Reflection;

namespace SimpleProgram.Lib
{
    public class TagGroupBase
    {
//        public readonly Dictionary<string, ITag> TagArchives = new Dictionary<string, ITag>();

        protected TagGroupBase()
        {
            return;
            
            // проходим по всем полям класса
//            foreach (FieldInfo field in GetType().GetFields())
//            {
//                if (!typeof(ITag).IsAssignableFrom(field.FieldType)) continue;
//
//                // ссылка на тег
//                object obj = field.GetValue(this);
//
//                // название архивного тега
//                PropertyInfo propArchiveName = obj.GetType().GetProperty(nameof(ITag.ArchiveTagId));
//                if (propArchiveName.GetValue(obj) == null)
//                {
//                    propArchiveName.SetValue(obj, $"{GetType().Name}.{field.Name}");
//                }
//                
//                // добавляем в словарь архивных тегов
//                ITag tag = (ITag) obj;
//                TagArchives.Add(tag.ArchiveTagId, tag);
//
//                // ссылка на архив
//                PropertyInfo propArchive = obj.GetType().GetProperty(nameof(ITag.Archive));
//                if (propArchive.GetValue(obj) == null && ArchiveDefault != null)
//                {
//                    propArchive.SetValue(obj, ArchiveDefault);
//                }
//            }
        }

        public Archive ArchiveDefault { get; set; }
    }
}
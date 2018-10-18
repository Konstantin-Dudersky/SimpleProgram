using SimpleProgram.Lib.Archives;
using System.Reflection;

namespace SimpleProgram.Lib
{
    public class TagGroupBase
    {
        public TagGroupBase(Archives.Archive archiveDefault = null)
        {
            ArchiveDefault = archiveDefault;

            // проходим по всем полям класса
            foreach (FieldInfo field in GetType().GetFields())
            {
                if (!typeof(ITagArchive).IsAssignableFrom(field.FieldType)) continue;

                // ссылка на тег
                object obj = field.GetValue(this);

                // название архивного тега
                PropertyInfo propArchiveName = obj.GetType().GetProperty(nameof(ITagArchive.ArchiveTagName));
                if (propArchiveName.GetValue(obj) == null)
                {
                    propArchiveName.SetValue(obj, $"{GetType().Name}.{field.Name}");
                }

                // ссылка на архив
                PropertyInfo propArchive = obj.GetType().GetProperty(nameof(ITagArchive.Archive));
                if (propArchive.GetValue(obj) == null && ArchiveDefault != null)
                {
                    propArchive.SetValue(obj, ArchiveDefault);
                }
            }
        }


        private Archive ArchiveDefault { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using SimpleProgram.Lib;
using SimpleProgram.Lib.Archives;
using SimpleProgram.Lib.Archives.MasterScada;

namespace Blazor.App.Services
{
    public static class Data
    {
        public static readonly Dictionary<string, ITagArchive> TagArchives = new Dictionary<string, ITagArchive>();


        public static readonly TagGroup1 TagGroup1;
        private static readonly Archive MsArchive = new Archive();


        private const int RefreshTime = 1000;

        private static readonly Timer RefreshTimer;


        static Data()
        {
            RefreshTimer = new Timer(new TimerCallback(obj => OnRefresh?.Invoke()), null, 0, RefreshTime);

            MsArchive.SetParams<MasterScadaDb>(Providers.PostgreSql,
                "Host=localhost;Database=energy;Username=postgres;Password=123");

            TagGroup1 = new TagGroup1(archiveDefault: MsArchive);
            
            
            // находим ссылки на архивы
            FillTagArchives();
        }


        public static event Action OnRefresh;


        public static void StartUp()
        {
        }

        private static void FillTagArchives()
        {
            foreach (FieldInfo field in typeof(Data).GetFields())
            {
                // находим группы тегов
                if(!typeof(TagGroupBase).IsAssignableFrom(field.FieldType)) continue;
                
                // ссылка на группу тегов
                TagGroupBase obj = (TagGroupBase)field.GetValue(typeof(Data));
                
                // добавляем ссылки
                foreach (KeyValuePair<string,ITagArchive> archive in obj.TagArchives)
                {
                    TagArchives.Add(archive.Key, archive.Value);
                }
            }
            
        }
    }
}
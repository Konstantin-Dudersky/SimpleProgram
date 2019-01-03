using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SimpleProgram.Lib.Tag;

namespace SimpleProgram.Lib.Archives
{
    public sealed class Table<T> : IEnumerable<TableGroup<T>>
        where T : ITableRow, new()
    {
        private readonly List<TableGroup<T>> _groups = new List<TableGroup<T>>();

        public event Action UpdatedEvent;

        public void Update(DateTime begin, DateTime end)
        {
            _groups.ForEach(g => g.Updated = false);
            _groups.ForEach(g => g.Update(begin, end));
        }

        private void OnUpdatedEvent()
        {
            if (_groups.Any(g => !g.Updated)) return;
            
            UpdatedEvent?.Invoke();
        }

        public void AddGroup(string title, IEnumerable<ITag> tags)
        {
            var group = new TableGroup<T>(title, tags);
            _groups.Add(group);
            group.UpdatedEvent += OnUpdatedEvent;
        }

        #region IEnumerable

        public IEnumerator<TableGroup<T>> GetEnumerator()
        {
            return _groups.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }

    public sealed class TableGroup<T> : IEnumerable<T>
        where T : ITableRow, new()
    {
        public TableGroup(string title, IEnumerable<ITag> tags)
        {
            Title = title;

            foreach (var tag in tags)
            {
                var row = new T {tag = tag};
                this.tags.Add(row);
                row.UpdatedEvent += OnUpdatedEvent;
            }
        }

        public string Title { get; }
        private List<T> tags { get; } = new List<T>();

        internal bool Updated { get; set; } = false;

        #region IEnumerable<T>
        public IEnumerator<T> GetEnumerator()
        {
            return tags.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        
        #endregion

        internal void Update(DateTime begin, DateTime end)
        {
            tags.ForEach(t => t.Updated = false);
            tags.ForEach(t => t.Update(begin, end));
        }

        public event Action UpdatedEvent;

        private void OnUpdatedEvent()
        {
            if (tags.Any(t => !t.Updated)) return;
            
            Updated = true;
            UpdatedEvent?.Invoke();
        }
    }

    public interface ITableRow
    {
        bool Updated { get; set; }
        ITag tag { get; set; }
        void Update(DateTime begin, DateTime end);
        event Action UpdatedEvent;
    }
}
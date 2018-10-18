using System;
using System.Collections.Generic;

namespace SimpleProgram.Lib
{
    public class TagArray
    {
        private readonly Dictionary<Type, List<Tag<Type>>> _dict = new Dictionary<Type, List<Tag<Type>>>();
        Tag<int> tagInt = new Tag<int>();

        public TagArray()
        {
            _dict[typeof(int)] = new List<Tag<typeof(int)>>();
            
            if(!_dict.ContainsKey(typeof(int)))
                _dict[typeof(int)] = new List<Tag<Type>>();
            _dict[typeof(int)].Add(tagInt);
        }
        
        private void AddItem<T>()
        {
            Tag<T> tag = new Tag<T>();
            List<Tag<T>> list = new List<Tag<T>>();
            _dict[typeof(T)] = new List<Tag<Type>>();
            _dict[typeof(T)].Add(tag);
        }
    }
}
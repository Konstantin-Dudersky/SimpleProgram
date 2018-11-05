using System;
using SimpleProgram.Lib.Archives;

namespace SimpleProgram.Lib
{
    public class TagLink<TOld, TNew> : ITag<TNew>
        where TNew : IConvertible
        where TOld : IConvertible
    {
        private readonly Tag<TOld> _tagLink;

        public TNew Value
        {
            get => (TNew) Convert.ChangeType(_tagLink.Value, typeof(TNew));
            set => _tagLink.Value =  (TOld) Convert.ChangeType(value, typeof(TOld));
        }

        public ITag<TNew1> Conv<TNew1>() where TNew1 : IConvertible
        {
            throw new NotImplementedException();
        }

        public Archive Archive { get; set; }
        public string ArchiveTagId { get; set; }
        public string TagId { get; set; }
        public string TagName { get; set; }

        public TimeSeries GetTimeSeries()
        {
            throw new NotImplementedException();
        }

        object ITag.Value
        {
            get => Value;
            set => throw new NotImplementedException();
        }

        public T1 GetValue<T1>()
        {
            throw new NotImplementedException();
        }

        public void SetValue<T1>(T1 value)
        {
            throw new NotImplementedException();
        }

        public string ValueString { get; set; }
        public Type GenericType { get; }
        public bool InputValid { get; }


        public TagLink(Tag<TOld> tagLink)
        {
            _tagLink = tagLink;
        }
    }
}
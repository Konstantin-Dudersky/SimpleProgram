using System;
using SimpleProgram.Lib.Archives;
using SimpleProgram.Lib.OpcUa;

namespace SimpleProgram.Lib
{
    public class TagLink<TOld, TNew> : ITag<TNew>
        where TNew : IConvertible
        where TOld : IConvertible
    {
        private readonly Tag<TOld> _tagLink;

        public TagLink(Tag<TOld> tagLink)
        {
            _tagLink = tagLink;
        }

        public TNew Value
        {
            get => (TNew) Convert.ChangeType(_tagLink.Value, typeof(TNew));
            set => _tagLink.Value = (TOld) Convert.ChangeType(value, typeof(TOld));
        }

        public Archive Archive
        {
            get => _tagLink.Archive;
            set => _tagLink.Archive = value;
        }

        public string ArchiveTagId
        {
            get => _tagLink.ArchiveTagId;
            set => _tagLink.ArchiveTagId = value;
        }

        public string TagId
        {
            get => _tagLink.TagId;
            set => _tagLink.TagId = value;
        }

        public string TagName
        {
            get => _tagLink.TagName;
            set => _tagLink.TagName = value;
        }

        public ITag<TNew1> ConvertTo<TNew1>() where TNew1 : IConvertible
        {
            return _tagLink.ConvertTo<TNew1>();
        }

        public TimeSeries GetTimeSeries()
        {
            return _tagLink.GetTimeSeries();
        }

        public T1 GetValue<T1>()
        {
            return _tagLink.GetValue<T1>();
        }

        public void SetValue<T1>(T1 value)
        {
            _tagLink.SetValue(value);
        }

        public string ValueString
        {
            get => _tagLink.ValueString;
            set => _tagLink.ValueString = value;
        }

        public Type GenericType => typeof(TNew);
        public DateTime TimeStamp => _tagLink.TimeStamp;
        public TagOpcUaClient OpcUaClient { get; set; }
    }
}
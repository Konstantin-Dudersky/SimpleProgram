using System;
using SimpleProgram.Lib.Archives;

namespace SimpleProgram.Lib
{
//    public class TagLink<TIn, TOut> : Tag<TOut>
//        where TIn : IConvertible
//        where TOut : IConvertible
//    {
//        private readonly Tag<TIn> _tagLink;
//
//        public TOut Value
//        {
//            get => _tagLink.GetValue<TOut>();
//            set => _tagLink.SetValue(value);
//        }
//
//        public TagLink(Tag<TIn> tagLink)
//        {
//            _tagLink = tagLink;
//        }
//    }
    public class TagLink<TOld, TNew> : ITag<TNew>
        where TNew : IConvertible
        where TOld : IConvertible
    {
        private Tag<TOld> _tagLink;

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

        public T1 GetValue<T1>()
        {
            throw new NotImplementedException();
        }

        public void SetValue<T1>(T1 value)
        {
            throw new NotImplementedException();
        }

        public TagLink(Tag<TOld> tagLink)
        {
            _tagLink = tagLink;
        }
    }
}
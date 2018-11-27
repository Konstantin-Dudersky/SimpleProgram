// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable IdentifierTypo
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace SimpleProgram.Lib.Archives.MasterScada
{
    public class masterscadadataraw
    {
        public int projectid { get; set; }
        public int layer { get; set; }
        public int itemid { get; set; }
        public long Time { get; set; }
        public double? value { get; set; }
        public string stringvalue { get; set; }
        public int? quality { get; set; }
        public int? flags { get; set; }
    }
}
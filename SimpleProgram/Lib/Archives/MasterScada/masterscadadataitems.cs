using System.ComponentModel.DataAnnotations;


namespace SimpleProgram.Lib.Archives.MasterScada
{
    public class masterscadadataitems
    {
        public int projectid { get; set; }
        public int itemid { get; set; }

        [Required]
        public string name { get; set; }

        public int? vartype { get; set; }
        public int? intervalid { get; set; }
        public long? firsttime { get; set; }
        public long? lasttime { get; set; }
        public long? valuescount { get; set; }
    }
}

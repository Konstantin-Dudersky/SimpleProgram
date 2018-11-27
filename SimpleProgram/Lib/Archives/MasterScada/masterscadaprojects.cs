using System.ComponentModel.DataAnnotations;
// ReSharper disable InconsistentNaming
// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable IdentifierTypo

namespace SimpleProgram.Lib.Archives.MasterScada
{
    public class masterscadaprojects
    {
        [Key]
        public int projectid { get; set; }

        [Required]
        public string name { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
// ReSharper disable InconsistentNaming
// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable IdentifierTypo
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace SimpleProgram.Lib.Archives.MasterScada
{
    public class masterscadaproperties
    {
        [Key]
        public int propertyid { get; set; }

        [Required]
        public string name { get; set; }

        public string value { get; set; }
    }
}

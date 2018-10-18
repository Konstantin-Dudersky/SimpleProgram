using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

using System.ComponentModel.DataAnnotations;

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

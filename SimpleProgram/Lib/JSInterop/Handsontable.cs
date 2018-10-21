using System.Collections.Generic;

/*
<script>
    window.handontablehelpers = {
        create: function (render, id, data) {
            var hot = new Handsontable(document.getElementById(id), data);
            return true;
        }
    };
</script>
*/

namespace SimpleProgram.Lib.JSInterop
{
    public class Handsontable
    {
        public List<List<object>> data { get; set; }
        public bool rowHeaders { get; set; } = true;
        public bool colHeaders { get; set; } = true;

        public Handsontable()
        {
            data = new List<List<object>>();
        }


        public void AddRow(List<object> list)
        {
            data.Add(list);
        }
    }
}
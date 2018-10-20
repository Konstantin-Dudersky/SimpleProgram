using System;
using System.Collections.Generic;

namespace SimpleProgram.Lib
{
    public class Table
    {
        public List<List<object>> data { get; set; }
        public bool rowHeaders { get; set; } = true;
        public bool colHeaders { get; set; } = true;

        public Table()
        {
            data = new List<List<object>>();
        }


        public void AddRow(List<object> list)
        {
            data.Add(list);
        }
    }
}
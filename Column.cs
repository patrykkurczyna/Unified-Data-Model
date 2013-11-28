using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM
{
    class Column
    {
        protected List<Cell> cells;
        protected string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public List<Cell> Cells
        {
            get { return cells; }
            set { cells = value; }
        }

        public Column(string name, List<Cell> cells)
        {
            this._name = name;
            this.cells = cells;
        }

        public void AddCell(Cell cell)
        {
            this.cells.Add(cell);
        }

        public bool RemoveCell(Cell cell)
        {
            return cells.Remove(cell);
        }
        public void Normalize()
        {
            // TODO
        }
    }
}

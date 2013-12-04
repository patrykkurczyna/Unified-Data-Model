using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM
{
    class Column<T> :AbstractColumn
    {
        protected List<AbstractCell> cells;
        protected string _name;
        protected DataType _type;
        public DataType Type
        {
            get { return _type; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public List<AbstractCell> Cells
        {
            get { return cells; }
            set { cells = value; }
        }

        public Column(String name, List<AbstractCell> cells, DataType _type)
        {
            this._name = name;
            this.cells = cells;
            this._type = _type;
        }

        public override void AddCell(AbstractCell cell)
        {
            this.cells.Add(cell);
        }

        public override bool RemoveCell(AbstractCell cell)
        {
            return cells.Remove(cell);
        }

        public override String ToString()
        {
            String result = this.Name;
            result += "\n";
            foreach (AbstractCell cell in this.cells)
            {
                result += cell.ToString();
                result += " ";
            }
            return result;
        }
    }
}

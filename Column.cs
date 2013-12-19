using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM
{
    [Serializable]
    public class Column
    {
        protected List<Cell> cells;
        protected string _name;
        protected DataType _type;
        public Column()
        {
            cells = new List<Cell>();
            _name = "Untitled";
            _type = DataType.IntegerFact;
        }
        public virtual DataType Type
        {
            get { return _type; }
        }
        public virtual string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public virtual List<Cell> Cells
        {
            get { return cells; }
            set { cells = value; }
        }

        public Column(string name, DataType type, List<Cell> cells = null)
        {
            this._name = name;
            if (cells == null) this.cells = new List<Cell>();
            else this.cells = cells;
            this._type = type;
        }

        public virtual void AddCell(Cell cell)
        {
            this.cells.Add(cell);
        }

        public virtual bool RemoveCell(Cell cell)
        {
            return cells.Remove(cell);
        }

        public override String ToString()
        {
            String result = this.Name;
            result += "\n";
            foreach (Cell cell in this.cells)
            {
                result += cell.ToString();
                result += " ";
            }
            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM
{
    class Table
    {
        protected List<AbstractColumn> columns;
        protected string _name;
        protected Table previous;
        public string Name
        {
            get { return _name; }
        }

        public List<AbstractColumn> Columns
        {
            get { return columns; }
            set { columns = value; }
        }

        public Table(String _name, List<AbstractColumn> columns, Table previous = null)
        {
            this._name = _name;
            this.columns = columns;
            this.previous = previous;
        }

        public void AddColumn(AbstractColumn column)
        {
            this.columns.Add(column);
        }

        public bool RemoveColumn(AbstractColumn column)
        {
            return columns.Remove(column);
        }

        public Table Execute(Command command)
        {
            return command.Execute(this);
        }

        public String ToString()
        {
            String table = this.Name + "\n";
            foreach (AbstractColumn column in this.columns)
            {
                table += column.ToString();
                table += "\n";
            }
            return table;
        }

        public Table Undo()
        {
            return previous;
        }
        public Table Normalize()
        {
            return null;
        }
    }
}

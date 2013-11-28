using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM
{
    class Table
    {
        protected List<Column> columns;
        protected string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public List<Column> Columns
        {
            get { return columns; }
            set { columns = value; }
        }

        public Table(String _name, List<Column> columns)
        {
            this._name = _name;
            this.columns = columns;
        }

        public void AddColumn(Column column)
        {
            this.columns.Add(column);
        }

        public bool RemoveColumn(Column column)
        {
            return columns.Remove(column);
        }

        public Table Select(List<Column> selectedColumns)
        {   
            return new Table(this._name, this.columns.FindAll(delegate(Column column)
            {
                return (selectedColumns.IndexOf(column) != -1);
            }));
        }

        public Table Join(Table table)
        {
            //TODO
            return new Table("todo", new List<Column>(););
        }
        public Table Group(Table table)
        {
            //TODO
            return new Table("todo", new List<Column>(););
        }
        public Table Filter(Table table)
        {
            //TODO
            return new Table("todo", new List<Column>(););
        }
    }
}

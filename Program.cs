using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM
{
    class Program
    {
        static void Main(string[] args)
        {
            Cell<String> s1 = new Cell<String>("Kraków");
            Cell<String> s2 = new Cell<String>("Gdańsk");
            Cell<String> s3 = new Cell<String>("Wrocław");
            Cell<String> s4 = new Cell<String>("Poznań");
            Cell<String> s5 = new Cell<String>("Warszawa");


            Cell<int> l1 = new Cell<int>(10);
            Cell<int> l2 = new Cell<int>(20);
            Cell<int> l3 = new Cell<int>(30);
            Cell<int> l4 = new Cell<int>(40);
            Cell<int> l5 = new Cell<int>(50);

            Column<String> s = new Column<String>("Miasto", null, DataType.Dimension);
            s.AddCell(s1);
            s.AddCell(s2);
            s.AddCell(s3);
            s.AddCell(s4);
            s.AddCell(s5);

            Column<int> l = new Column<int>("Sprzedaż", null, DataType.Fact);
            l.AddCell(l1);
            l.AddCell(l2);
            l.AddCell(l3);
            l.AddCell(l4);
            l.AddCell(l5);


            List<AbstractColumn> mylist = new List<AbstractColumn>();
            mylist.Add(s);
            mylist.Add(l);

            Table first_table = new Table("Dane1", mylist);


        }
    }
}

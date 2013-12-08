using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UDM
{
    public class Program
    {
        static void Main(string[] args)
        {
            Cell s1 = new Cell("Kraków");
            Cell s2 = new Cell("Gdańsk");
            Cell s3 = new Cell("Wrocław");
            Cell s4 = new Cell("Poznań");
            Cell s5 = new Cell("Warszawa");


            Cell l1 = new Cell(10);
            Cell l2 = new Cell(20);
            Cell l3 = new Cell(30);
            Cell l4 = new Cell(40);
            Cell l5 = new Cell(50);

            Column s = new Column("Miasto", DataType.StringDimension);
            s.AddCell(s1);
            s.AddCell(s2);
            s.AddCell(s3);
            s.AddCell(s4);
            s.AddCell(s5);
            

            Column l = new Column("Sprzedaż", DataType.IntegerFact);
            l.AddCell(l1);
            l.AddCell(l2);
            l.AddCell(l3);
            l.AddCell(l4);
            l.AddCell(l5);


            List<Column> mylist = new List<Column>();
            mylist.Add(s);
            mylist.Add(l);

            Table first_table = new Table("Dane1", null, mylist);


            Console.WriteLine(first_table);
            
            Console.WriteLine(first_table.Execute(new SelectCommand(new List<int>{0})));
            Console.WriteLine(first_table.Execute(new SelectCommand(new List<int> {1})));

            Console.WriteLine(first_table.Execute(new FilterCommand(first_table.Columns[1],cellContent => (int)cellContent > 20)));



            
            Console.ReadKey();
        }
    }
}

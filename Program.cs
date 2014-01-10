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
            // ------------------------ FIRST TABLE --------------------------------------
            Cell c1 = new Cell(2011);
            Cell c2 = new Cell(2012);
            Cell c3 = new Cell(2013);

            Cell s1 = new Cell("Kraków");
            Cell s2 = new Cell("Kraków");
            Cell s3 = new Cell("Gdańsk");
            Cell s4 = new Cell("Gdańsk");
            Cell s5 = new Cell("Wrocław");
            Cell s6 = new Cell("Poznań");
            Cell s7 = new Cell("Wawa");
            Cell s8 = new Cell("Gdańsk");
            Cell s9 = new Cell("Rzym");

            Cell l1 = new Cell((int)15);
            Cell l2 = new Cell((int)20);
            Cell l3 = new Cell((int)20);
            Cell l4 = new Cell((int)30);
            Cell l5 = new Cell((int)40);
            Cell l6 = new Cell((int)50);
            Cell l7 = new Cell((int)60);
            Cell l8 = new Cell((int)80);
            Cell l9 = new Cell((int)11);

            Cell p1 = new Cell(2);

            Column c = new Column("Rok", DataType.StringDimension);
            c.AddCell(c1);
            c.AddCell(c1);
            c.AddCell(c2);
            c.AddCell(c3);
            c.AddCell(c2);
            c.AddCell(c3);
            c.AddCell(c1);
            c.AddCell(c1);

            Column s = new Column("Miasto", DataType.StringDimension);
            s.AddCell(s1);
            s.AddCell(s2);
            s.AddCell(s3);
            s.AddCell(s4);
            s.AddCell(s5);
            s.AddCell(s6);
            s.AddCell(s7);
            s.AddCell(s8);

            Column l = new Column("Sprzedaż", DataType.FloatFact);
            l.AddCell(l1);
            l.AddCell(l2);
            l.AddCell(l3);
            l.AddCell(l4);
            l.AddCell(l5);
            l.AddCell(l6);
            l.AddCell(l7);
            l.AddCell(l8);


            Column p = new Column("Coś", DataType.IntegerFact);
            p.AddCell(p1);
            p.AddCell(p1);
            p.AddCell(p1);
            p.AddCell(p1);
            p.AddCell(p1);
            p.AddCell(p1);
            p.AddCell(p1);
            p.AddCell(p1);

            List<Column> mylist = new List<Column>();
            //mylist.Add(c);
            mylist.Add(s);
            mylist.Add(l);
            mylist.Add(p);

            Table first_table = new Table("Dane1", null, mylist);
            //Console.WriteLine(first_table);
            first_table.print();

            // ------------------------ SECOND TABLE --------------------------------------

            Cell s11 = new Cell("Berlin");
            Cell s21 = new Cell("Kolonia");
            Cell s31 = new Cell("Hamburg");


            Cell l11 = new Cell(70.5);
            Cell l21 = new Cell(65);
            Cell l31 = new Cell((double)15);


            Column ss = new Column("Miasto", DataType.StringDimension);
            ss.AddCell(s11);
            ss.AddCell(s21);
            ss.AddCell(s31);

            Column ll = new Column("Sprzedaż", DataType.FloatFact);
            ll.AddCell(l11);
            ll.AddCell(l21);
            ll.AddCell(l31);

            Column pp = new Column("Coś", DataType.IntegerFact);
            pp.AddCell(p1);
            pp.AddCell(p1);
            pp.AddCell(p1);

            List<Column> mylist1 = new List<Column>();
            mylist1.Add(ss);
            mylist1.Add(ll);
            mylist1.Add(pp);

            Table second_table = new Table("Dane2", null, mylist1);

            // ------------------------ TABLE --------------------------------------------
            mylist = new List<Column>();
            mylist.Add(c);
            mylist.Add(s);
            mylist.Add(l);
            mylist.Add(p);
            Table second = new Table("Tabeleczka", null, mylist);
            //Console.WriteLine(second);
            second.print();

            // ------------------------ GROUP COMMAND -----------------------------------
            Dictionary<Column, Aggregation> dict = new Dictionary<Column, Aggregation>();
            dict.Add(l, new AverageAggregation());
            dict.Add(p, new SumAggregation());
            Command cmd = new GroupCommand(new List<Column> { s }, dict);
            first_table.Execute(cmd).print();
            //Console.WriteLine(first_table.Execute(cmd));
            dict[l] = new CountAggregation();
            //Console.WriteLine(first_table.Execute(cmd));
            first_table.Execute(cmd).print();
                   
                      
            dict = new Dictionary<Column, Aggregation>();
            dict.Add(l, new AverageAggregation());
            dict.Add(p, new SumAggregation());
            cmd = new GroupCommand(new List<Column> { c, s }, dict);
            //Console.WriteLine(second.Execute(cmd));
            second.Execute(cmd).print();

            //------------------------- OTHER COMMANDS -----------------------------------

            first_table.Execute(new SelectCommand(new List<int>{0})).print();
            first_table.Execute(new SelectCommand(new List<int>{1})).print();

            Table result = first_table.Execute(new FilterCommand(first_table.Columns[1],cellContent => (double)cellContent > 20));
            Table modified = new Table(result.Name,first_table,result.Columns);
            modified.print();
            modified.Undo().print();
            
            first_table.Execute(new VerticalJoinCommand(second_table)).print();

            // ------------------------ AGGREGATION TESTS ---------------------------------------
            List<Cell> cells = new List<Cell>();
            cells.Add(l11);
            cells.Add(l21);
            cells.Add(l31);

            Console.WriteLine((double)(new SumAggregation()).GetAggregatedValue(cells));
            Console.WriteLine((double)(new MaxAggregation()).GetAggregatedValue(cells));
            Console.WriteLine((int)(new CountAggregation()).GetAggregatedValue(cells));
            Console.WriteLine((double)(new MinAggregation()).GetAggregatedValue(cells));
            Console.WriteLine((double)(new AverageAggregation()).GetAggregatedValue(cells));

            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MatrixSync
{
    class Program
    {
        public class Point
        {
            public int x;
            public int y;
        }
        static void Main(string[] args)
        {

            int[] mask = new int[Console.WindowWidth];
         
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Green;

            List<Point> field = new List<Point>();

            Random rn = new Random();
            while(true)
            {
                // генерирую новую волну
                int row = rn.Next(0, Console.WindowWidth);

                if (mask[row] == 1)
                    goto x1;

                Point p = new Point();
                p.y = 0;
                p.x = row;
                mask[row] = 1;

                field.Add(p);
                
                x1:
                for(int i = 0; i < field.Count; i++)
                {
                    if (field[i].y > Console.WindowHeight-2)
                    {
                        field.RemoveAt(i);
                        continue;
                    }
                    Console.SetCursorPosition(field[i].x, field[i].y);
                    Console.Write(rn.Next(0, 2).ToString());
                    field[i].y++;
                }
                Thread.Sleep(150);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA211008
{
    class Macska : IMatrixElem
    {
        public string Nev { get; set; }
        public DateTime Szul { get; set; }
        public (int X, int Y) Hely { get; set; }
        public List<Vaza> OsszetortVazak { get; set; } = new List<Vaza>();
        public bool Osszetor(Vaza vaza)
            => vaza.Hely == this.Hely;
        public string GetInfo() 
            => $"{Nev} a macska {DateTime.Now.Year - Szul.Year} éves [{Hely.X};{Hely.Y}]";
    }

    class Vaza : IMatrixElem
    {
        public (int X, int Y) Hely { get; set; }
        public string Tipus { get; set; }
        public int Meret { get; set; }
        public string Anyag { get; set; }

        public string GetInfo()
            => $"{Tipus} {Anyag} váza, [{Hely.X};{Hely.Y}] {Meret} cm";
    }

    interface IMatrixElem
    {
        (int X, int Y) Hely { get; set; }
        string GetInfo();
    }


    class Program
    {
        static IMatrixElem[,] matrix = new IMatrixElem[10, 10];
        static Random rnd = new Random();
        static void Main()
        {
            InitMatrix();
            MatrixKiir();
            //RndLoop();
            Console.ReadKey();
        }

        private static void RndLoop()
        {
            for (int i = 0; i < 400; i++)
            {
                int x1 = rnd.Next(matrix.GetLength(0));
                int y1 = rnd.Next(matrix.GetLength(1));

                int x2 = rnd.Next(matrix.GetLength(0));
                int y2 = rnd.Next(matrix.GetLength(1));



            }
        }

        private static void MatrixKiir()
        {
            for (int x = 0; x < matrix.GetLength(0); x++)
            {
                for (int y = 0; y < matrix.GetLength(1); y++)
                {
                    if (matrix[x, y] is Macska) Console.Write('M');
                    else if (matrix[x, y] is Vaza) Console.Write('V');
                    else Console.Write('.');
                }
                Console.Write("\n");
            }
        }

        private static void InitMatrix()
        {
            for (int x = 0; x < matrix.GetLength(0); x++)
            {
                for (int y = 0; y < matrix.GetLength(1); y++)
                {
                    if (rnd.Next(100) < 20)
                    {
                        if (rnd.Next(100) < 50)
                            matrix[x, y] = new Macska() { Hely = (x, y) };
                        else matrix[x, y] = new Vaza() { Hely = (x, y) };
                    }
                }
            }





        }

        //Tuple<int, int> t = new Tuple<int, int>(10, 10);
        //(int X, string Szoveg, int Y) t2 = (10, "banán", 20);
        //Console.WriteLine(t2.Item3);
        //Macska m = new Macska();
        //m.Hely = (20, m.Hely.Item2);
        //m.Hely = (20, m.Hely.Y);
    }
}

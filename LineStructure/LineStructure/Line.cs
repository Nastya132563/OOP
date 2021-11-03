using System;

namespace LineStructure
{
    public struct Line
    {
        public double VarA;
        public double VarB;
        public readonly double Angle;
        public Line(double varA, double varB)
        {
            if (varA == 0)
            {
                throw new Exception("Значение А должно быть ненулевым.");
            }

            VarA = varA;
            VarB = varB;
            Angle = Math.Round(Math.Atan(varA) / Math.PI * 180, 2);
        }
        public static Line Read()
        {
            double varA;
            double varB;

            while (true)
            {
                Console.WriteLine("Введите переменную А:");
                varA = int.Parse(Console.ReadLine());

                Console.WriteLine("Введите переменную В:");
                varB = int.Parse(Console.ReadLine());

                if (varA == 0)
                {
                    throw new Exception("Значение А должно быть ненулевым.");
                }
                else break;
            }

            return new Line(varA, varB);
        }

        public override string ToString()
        {
            if (VarB == 0) return $"y={VarA}x";
            else if (VarB < 0) return $"y={VarA}x{VarB}";
            else return $"y={VarA}x+{VarB}";
        }

        public override bool Equals(object obj1)
        {
            if (obj1 is Line)
            {
                Line l1 = (Line)obj1;

                return (VarA == l1.VarA && VarB == l1.VarB);
            }
            else return false;

        }

        public override int GetHashCode()
        {
            return Angle.GetHashCode();
        }
        public void Display()
        {
            Console.WriteLine($"Структура Line, var A = {VarA}, var B = {VarB}");
        }
        public static Line operator ~(Line l1)
        {
            if (l1.VarA == 0) throw new ArgumentException("a не может быть равным нулю.");
            else
            {
                double NewVarA = Math.Round(-(1.0 / l1.VarA),4);
                return new Line(NewVarA, 0);
            }
        }
    }
}

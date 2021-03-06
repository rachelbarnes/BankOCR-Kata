﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    public class TestInterfaces
    {
        public double GetTotalArea(List<HasArea> pans)
        {
            //            return pans.Aggregate(0d, (ret, pan) => ret + pan.GetArea());
            var total = 0d;
            foreach (var pan in pans)
            {
                total += pan.GetArea();
            }
            return total;
            //these two logics say the same thing. aggregate goes through a looping motion? Is it a part
            //of the ienumerables idea? 
        }
    }
    public interface HasArea
    {
        double GetArea();
    }
    
    public interface TakesFields
    {
        HasArea GetInput();
    }
    
    public class RoundPan : HasArea
    {
        private int Radius;
        public RoundPan(int radius)
        {
            this.Radius = radius;
        }//create the constructor as an object; the Radius is a class field, and the constructor
        //takes this field and defines it as it's own by assigning the parameter to that field (if 
        //you call them different names, it may make things easier to start). This means,
        //whenever the Radius is changed, the roundpan is called and the Radius gets changed 
        //whenever that that constructor is called with a defined parameter.

        public double GetArea()
        {
            return (Radius * 2) * Math.PI;
        }
        public HasArea GetInput()
        {
            Console.WriteLine("Input the Radius:");
            var input = Console.ReadLine();
            Radius = int.Parse(input);
            return this;
        }

    }
    public class SquarePan : HasArea
    {
        private int Length;
        public SquarePan(int length)
        {
            this.Length = length;
        }
        public double GetArea()
        {
            return Length * Length;
        }

    }
    public class RectPan : HasArea
    {
        private int Width;
        private int Length;
        public RectPan(int length, int width)
        {
            this.Length = length;
            this.Width = width;
        }

        public double GetArea()
        {
            return Length * Width;
        }
        public HasArea GetInput()
        {
            Console.WriteLine("Input the Width:");
            var input = Console.ReadLine();
            Width = int.Parse(input);
            Console.WriteLine("Input the Length:");
            input = Console.ReadLine();
            Length = int.Parse(input);
            return this;
        }
    }
}

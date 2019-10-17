using System;
using System.Collections.Generic;

namespace LINQLearning
{
    class Program
    {

        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            IEnumerable<string> cities = new[] {"Ghent","London","Las Vegas","Hydebad"};

            IEnumerable<string> query = 
            cities.StringThatStartWith("L");
        }
    }
}

namespace Extensions
{
    public static class FilterExtensions
    {
        public static IEnumerable<string> StringsThatStartWith
        (this IEnumerable<string> input,string start)
        {
            
        }
    }
}
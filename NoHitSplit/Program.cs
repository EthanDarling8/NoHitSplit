using System;
using System.Collections.Specialized;
using System.Threading;

namespace NoHitSplit {
    internal class Program {
        public static void Main(string[] args) {
            Split.GenerateList("/home/ethan/Documents/NoHitSplit/NoHitSplit/NoHitSplit/bin/Release");
            Console.WriteLine(Split.GetListLength());
            Intro.Instructions();
        }
    }
}
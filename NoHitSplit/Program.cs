using System;
using System.Collections.Specialized;
using System.IO;
using System.Threading;

namespace NoHitSplit {
    internal class Program {
        public static void Main(string[] args) {
            Split.GenerateList(Directory.GetCurrentDirectory() + "/splits/");
            Console.WriteLine(Split.GetListLength());
            Intro.Instructions();
        }
    }
}
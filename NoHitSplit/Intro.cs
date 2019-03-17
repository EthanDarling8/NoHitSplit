using System;
using System.CodeDom.Compiler;
using System.Net.Security;
using System.Runtime.InteropServices;

namespace NoHitSplit {
    public class Intro {
        public static void Instructions() {
            IntroText();

            string choice = Console.ReadLine();
            if (int.TryParse(choice, out int result) && result >= 0 && result <= 3) {
                if (result == 0) {
                    Environment.Exit(0);
                }
                if (result == 1) {
                    Console.Clear();
                    Console.WriteLine("Select a split number:");
                    DisplaySplit.LoadSplits();
                    string splitChoice = Console.ReadLine();
                    if (int.TryParse(splitChoice, out int splitResult) && splitResult >= 0 
                        && splitResult <= Split.GetListLength()) {
                        DisplaySplit.SplitChoice(splitResult);
                    }
                    else {
                        Console.WriteLine("Please choose an existing split.");
                    }
                   
                }
                if (result == 2) {
                    CreateSplit.SplitCreator();
                }
                if (result == 3) {
                    //TODO
                }
                
                //TODO Add option to edit splits
            }
        }

        public static void IntroText() {
            Console.WriteLine("Please choose and option:");
            Console.WriteLine("1: Open Existing Splits");
            Console.WriteLine("2: Create new Splits.");
            Console.WriteLine("3: View Statistics.");
            Console.WriteLine("0: Exit.");
        }
    }
}
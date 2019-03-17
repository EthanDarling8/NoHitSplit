using System;
using System.IO;

namespace NoHitSplit {
    public class DisplaySplit {
        public static void LoadSplits() {
            for (int i = 0; i < Split.GetListLength(); i++) {
                ReadSplitNames(i);
            }
        }

        public static void SplitChoice(int intended) {
            Console.Clear();
            try {
                using (StreamReader reader = new StreamReader(
                    "/home/ethan/Documents/NoHitSplit/NoHitSplit/NoHitSplit/bin/Release/" + Split.GetName(intended) + ".txt")) {
                    while (!reader.EndOfStream) {
                        string temp = reader.ReadLine();
                        if (temp != null && temp.StartsWith("~")) {
                            Console.WriteLine(temp.Substring(1));
                            Console.WriteLine("------------------------------");
                        }
                        else 
                            Console.WriteLine(temp);
                    }
                }
            }
            catch (Exception e) {
                Console.WriteLine("Could not load split or pathing is incorrect.");
                Console.WriteLine(e);
                throw;
            }
        }

        private static void ReadSplitNames(int s) {
            try {
                using (StreamReader reader = new StreamReader(
                    "/home/ethan/Documents/NoHitSplit/NoHitSplit/NoHitSplit/bin/Release/" + Split.GetName(s) + ".txt")) {
                    while (!reader.EndOfStream) {
                        string temp = reader.ReadLine();
                        if (temp != null && temp.StartsWith("~")) {
                            Console.WriteLine(s + " : " + temp.Substring(1));
                        }
                    }
                }
            }
            catch (Exception e) {
                Console.WriteLine("Could not load split or pathing is incorrect.");
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
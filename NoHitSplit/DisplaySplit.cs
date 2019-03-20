using System;
using System.IO;

namespace NoHitSplit {
    public class DisplaySplit {
        public static void LoadSplits() {
            for (int i = 0; i < Split.GetListLength(); i++) {
                ReadSplitNames(i);
            }
        }

        public static void SplitChoice(int n) {
            Console.Clear();
            try {
                using (StreamReader reader = new StreamReader(
                    Directory.GetCurrentDirectory() + "/splits/" + Split.GetName(n) + ".txt")) {
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
                    Directory.GetCurrentDirectory() + "/splits/" + Split.GetName(s) + ".txt")) {
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
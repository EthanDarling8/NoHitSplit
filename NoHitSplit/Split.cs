using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Reflection;
using System.Text;

namespace NoHitSplit {
    public class Split {
        private string Name;
        private string Content;
        private static IList<Split> splitList = new List<Split>();

        public Split(string name, string content) { //TODO add statistics such as pb, last, and current.
            Name = name;
            Content = content;
        }

        public static void GenerateList(string filePath) {
            StringBuilder sb = new StringBuilder();
            string[] files = Directory.GetFiles(filePath, "*.txt");
            string splitFileName = "";
            foreach (string file in files) {
                try {
                    using (StreamReader reader = new StreamReader(file)) {
                        while (!reader.EndOfStream) { 
                            string temp = reader.ReadLine();
                            if (temp.StartsWith("~")) {
                                temp = temp.Substring(1);
                                splitFileName = temp;
                                sb.Append(temp + "\n");
                            }
                            else 
                                sb.Append(temp + "\n");
                        }
                        Split split = new Split(splitFileName, sb.ToString());
                        AddSplit(split);
                    }
                }
                catch (Exception e) {
                    Console.WriteLine("Error when generating list on startup.");
                    Console.WriteLine(e.Message);
                    throw;
                }
                
            }
        }
        
        public static void AddSplit(Split s) {
            splitList.Add(s);
         }

        public static void DeleteSplit(int n, string f) {
            splitList.RemoveAt(n);
            File.Delete(f);
        }
        
        public static IList<Split> GetList() {
            return splitList;
        }

        public static string GetName(int i) {
           return splitList[i].Name;
        }

        public static int GetListLength() {
            return splitList.Count;
        }
    }
}
using System;
using System.Dynamic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading;
using System.Xml.Serialization;
// ReSharper disable InconsistentNaming

namespace NoHitSplit {
    public class CreateSplit {
        private static string filePath;
        private static string splitName;

        public static void SplitCreator() {
            Console.Clear();
            Console.WriteLine("Please enter a name for the split file (not the names for the splits themselves).");
            splitName = Console.ReadLine();

            //Check for duplicate name and overwrite if necessary. \
            if (Split.GetListLength() > 0) { //If the list actually has something in it, continue
                for (int i = 0; i < Split.GetListLength(); i++) {
                    if (Split.GetName(i).Equals(splitName)) {
                        Console.WriteLine("A split file with this name already exists. Overwrite (y) or try another name (any other key).");
                        string choice = Console.ReadLine();
                        if (choice.ToLower().Equals("y")) {
                            Console.WriteLine("Overwriting File!");
                            filePath = "/home/ethan/Documents/NoHitSplit/NoHitSplit/NoHitSplit/bin/Release/" + splitName + ".txt";
                            Split.DeleteSplit(i, filePath);
                            
                            Thread.Sleep(100);
                        }
                    }
                    Console.Clear();
                }
                filePath = "/home/ethan/Documents/NoHitSplit/NoHitSplit/NoHitSplit/bin/Release/" + splitName + ".txt";
                WriteSplit(splitName);
            }
            else if (Split.GetListLength() == 0) { //If the list doesn't have anything in it
                filePath = "/home/ethan/Documents/NoHitSplit/NoHitSplit/NoHitSplit/bin/Release/" + splitName + ".txt";
                WriteSplit(splitName);

            }
        }

        private static void WriteSplit(string splitFileName) {
            try { //Writing to file 
                using (StreamWriter writer = new StreamWriter(File.Create(splitFileName + ".txt"))) {
                    writer.WriteLine("~" + splitFileName); //Write the name of the split to the first line with a delimiter.
                    Console.WriteLine("Would you like to add splits (1), delete a split (2), or save and exit (0)?");

                    string choice = Console.ReadLine();
                    if (int.TryParse(choice, out int result) && result >= 0 && result <= 2) {
                        if (result == 1) {
                            string userInput = "";
                            Console.WriteLine("Enter a name for the split or type \"esc\" to save and go to the menu.");
                            do {
                                userInput = Console.ReadLine();
                                if (userInput.Equals("esc")) 
                                    break;
                                if (!userInput.Equals("esc"))
                                    writer.WriteLine(userInput);
                            } while (userInput != null && !userInput.Equals("esc"));
                        }
                    }
                }
                
                StringBuilder sb = new StringBuilder();
                using (StreamReader reader = new StreamReader(splitFileName + ".txt")) {
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
                }

                Split split = new Split(splitFileName, sb.ToString());
                Split.AddSplit(split);
            }
            catch (Exception e) {
                Console.WriteLine("File could not be written or pathing is incorrect.");
                Console.WriteLine(e.Message);
                throw;
            }
            Console.Clear();
            Intro.Instructions();
        }
    }
}
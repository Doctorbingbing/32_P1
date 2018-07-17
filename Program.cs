using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace _32_P1
{
    class Program
    {
       
        
        static void StepTwo(List<string> files)        
                                            //Anything else | Error on line by itself and readinput again
        {
            
            bool checker2 = false; 
            string key  = null; 
            while (checker2 == false)
            {
                string newinput = TakeInput();
                string[] sep = newinput.Split(' ');
                key = sep[0].ToString();
                checker2 = ValidateInput(key);
            }

            if (key == "A")
            {
            //A|       ALL FILES found in the previous step to be considered
                return;
            }
            else if (key == "E")
            {
            //E + EXTENSION| FILES with the desired extension
                return;
            }
            else if (key == "T")
            {
             //T + GIVEN TEXT| FILES that are text files 
                return;
            }
            else if (key == "N")
            {
            //N + NAME| FILES whose names exactly match include extensions
                return;
            }
            else if (key == "<")
            {
            //< + SIZE| FILES that have a size smaller than threshold
                return;
            }
            else if (key == ">")
            {
            //> + SIZE| FILES that have a size larger than threshold
                return;
            }
    


        }

       

        static string TakeInput()
        {
            return Console.ReadLine();

        }

        static bool ValidateInput(string key) //LATER MAKE THIS CHECK IF A PATH IS VALID
        {
            if (key == "D")
            {
                return true;
            }
            else if (key == "R")
            {
                return true;
            }
            else if (key == "A")
            {
                return true;
            }
            else if (key == "N")
            {
                return true;
            }
            else if (key == "E")
            {
                return true;
            }
            else if (key == "T")
            {
                return true;
            }
            else if (key == "<")
            {
                return true;
            }
            else if (key == ">")
            {
                return true;
            }
            else
            {
                Console.WriteLine("ERROR");
                return false;
            }
        }
            
        
        static List<string> FindFiles(string path)                          // Creates a list of strings of Files in a specified path
        {
            List<string> files = new List<string>(Directory.EnumerateFiles(path));
            return files;
        }

        static List<string> FindDirs(string path)                           // Creates a list of strings of Directories in a specified path 
        {
            List<string> dirs = new List<string>(Directory.EnumerateDirectories(path));
            return dirs;
        }

        static void RecursiveSearch(List<string> directories, List<string> files)               //Finds Files and SubDirectories in Directories, prints the Files, then recursively searches for 
                                                                            //more Files in each SubDirectory
        {
            foreach (var  dir in directories)
            {
                List<string> towrite = FindFiles(dir);
                List<string> subdirectory = FindDirs(dir);
                foreach (var file in towrite)
                {
                    Console.WriteLine(file);
                    files.AddRange(towrite);
                    
                }
                foreach (var subdir in subdirectory)
                {
                    RecursiveSearch(subdirectory, files);
                }
                
            }
            return;
        }
        static void Main(string[] args)
        {
             string key = null;
             string path = null;
             string[] sep = null;
             string input = null;
             bool checker = false;
             List<string> files;
             List<string> dirs;
                
            while (checker == false)
            {
                input = TakeInput();
                sep = input.Split(' ');
                key = sep[0].ToString();
                checker = ValidateInput(key);
            }
            path = input.Substring(2,input.Length-2);

                                                     // user input minus the qualifier
             if (key == "D")   //Directory
            {
                files = FindFiles(path);
                //List<string> files = new List<string>(Directory.EnumerateFiles(path));         
              //  List<string> dirs = new List<string>(Directory.EnumerateDirectories(path));                                              
                files.Sort();                                                                   // Sorts the combined list in lexographic order
                foreach (var item in files) 
                {
                    Console.WriteLine(item);                                                    //Prints all the files within the specified path in the now sorted order
                }
                StepTwo(files);
               
                

            }
            else if (sep[0] == "R") //Recursive Searches
            {
               files = FindFiles(path);
               dirs = FindDirs(path);
               foreach (var item in files)
               {
                  Console.WriteLine(item);
               }

               RecursiveSearch(dirs, files);

              //  List<string> dirs = new List<string>(Directory.EnumerateDirectories(path));
               // foreach (var item in dirs)
              StepTwo(files);
            }

             else
        
           {
                Console.WriteLine("ERROR");
                //Print "ERROR" and read line for input. 
                //Continue until the input is valid.
                input = Console.ReadLine();
                
           } 
        }
    }
}

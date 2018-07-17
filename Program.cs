using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace _32_P1
{
    class Program
    {
       
        static List<string> EnumerateContents(string path)
        {

                List<string> files = new List<string>(Directory.EnumerateFiles(path));
                List<string> dirs = new List<string>(Directory.EnumerateDirectories(path));
            
                
                files.AddRange(dirs);
                return files;
            
        }
        static List<string> FindFiles(string path)
        {
            List<string> files = new List<string>(Directory.EnumerateFiles(path));
            return files;
        }

        static List<string> FindDirs(string path)
        {
            List<string> dirs = new List<string>(Directory.EnumerateDirectories(path));
            return dirs;
        }

        static void RecursiveSearch(List<string> directories)
        {
            foreach (var  dir in directories)
            {
                List<string> towrite = FindFiles(dir);
                List<string> subdirectory = FindDirs(dir);
                foreach (var file in towrite)
                {
                    Console.WriteLine(file);
                }
                foreach (var subdir in subdirectory)
                {
                    RecursiveSearch(subdirectory);
                }
                
            }
            return;
        }

        static void Main(string[] args)
        {
           // Console.WriteLine("Hello World!");

             string key;
             string path;
             string[] sep;
             string input;
             List<string> files;
             List<string> dirs;
             
            
             input = Console.ReadLine();
             
             sep = input.Split(' ');
             key = sep[0].ToString();
             path = input.Substring(2,input.Length-2);                                          // user input minus the qualifier
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
               
                string nextinput = Console.ReadLine();


            }
            else if (sep[0] == "R") //Recursive
            {
               files = FindFiles(path);
               dirs = FindDirs(path);
               foreach (var item in files)
               {
                  Console.WriteLine(item);
               }

               RecursiveSearch(dirs);

              //  List<string> dirs = new List<string>(Directory.EnumerateDirectories(path));
               // foreach (var item in dirs)
                {
                    
                }
                Console.WriteLine(path);
            }



            // FUNCTIONS
           
             


             else
        
           {
                Console.WriteLine("ERROR");
                //Print "ERROR" and read line for input. 
                //Continue until the input is valid.
           } 
        }
    }
}

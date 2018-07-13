using System;

namespace _32_P1
{
    class Program
    {
        static void Main(string[] args)
        {
           // Console.WriteLine("Hello World!");

             string key;
             string path;
             string[] sep;
             string input;
             input = Console.ReadLine();
             sep = Console.ReadLine().Split(' ');
             key = sep[0].ToString();
             path = input.Substring(3,input.Length);
             if (key == "D")   //Directory
            {
                // Print the path to directory and 
                // print all the files and subdirectories 
                // in that directory
                Console.WriteLine(path);

            }
            else if (sep[0] == "R") //Recursive
            {

            }
          //  else if
        
         //   {
          //       Console.WriteLine('ERROR')   
                //Print "ERROR" and read line for input. 
                //Continue until the input is valid.
         //   } 
        }
    }
}

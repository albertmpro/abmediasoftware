using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Albert
{
    /// <summary>
    /// Begin Console App  
    /// </summary>
    public static class ABConsole
    {
        /// <summary>
        /// Tuple to begin the Console Application         /// </summary>
        /// <param name="_title"></param>
        /// <returns></returns>
        public static (string Title, string Line)WriteBegin(string _title)
        {
      

            //Create a Line 
            var line = "-----------------------";

            //Clear your Console 
            Clear();
            WriteLine(_title);
            WriteLine(line);

            return (_title, line);

        }
        /// <summary>
        /// Clear console and Create a Title
        /// </summary>
        /// <param name="_title">Title</param>
        public static void WriteTitle(string _title)
        {
            //Create a Title
            Clear();
            WriteLine(_title);
            WriteLine("--------------------");



        }


        /// <summary>
        /// Method to exit or return to part  of aconsole application 
        /// </summary>
        /// <param name="_program">Method you want ot go to</param>
        public static void WriteExit(Action _program)
        {
            Write("Do you want to exit?(y/n)\nAnswer:");
            var ans = ReadLine();
            switch (ans)
            {
                case "y":
                    WriteLine("Goodbye!");
                    break;
                case "n":
                    _program.Invoke();
                    break;
            }

        }

        /// <summary>
        /// WriteExit Method for going to another part of the Pragram
        /// </summary>
        /// <param name="_start"></param>
        /// <param name="_program"></param>
        public static void WriteExit(Action _start,Action _program)
        {
            Write("Do you want to exit?(y/n)\nAnswer: ");
            var choice = ReadLine();

            switch(choice)
            {
                case "y":
                    _start.Invoke();
                    break;
                default:
                    _program.Invoke();
                    break;
            }
        }
         
           
       


    }
}

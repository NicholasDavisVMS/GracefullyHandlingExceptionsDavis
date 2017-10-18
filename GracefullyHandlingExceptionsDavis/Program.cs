using System;
using System.IO;

namespace GracefullyHandlingExceptionsDavis
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            ///This lesson will be on handling exceptions that occur within 
            /// your applications. We will discuss what can go wrong, why they
            /// go wrong, and how to build resilient applications that will
            /// be imperious to crashing. When the compiler catches an error,
            /// it will refuse to compile your source code into a .NET assembly
            /// until you fix the problem(compolation errors). However there are 
            /// other types of problems, such as unable to write to disk, etc.
            /// Countless problems that can cause an exception at runtime. 
            /// Sometimes problems are not foreseen. As a software developer,
            /// it is your job to account for possibilities. "80% of all code
            /// exists to solve 20% of problems". Pessimistic of reliabiltiy of
            /// all outside input of code, etc. Like defensive driving, via a 
            /// try catch block. DONT WANT USERS SEEING ERRORS!

            //You can sabotage the application by changing/renaming the name of 
            //the file, in Solutions explorer. WHERE IS IT?
            //Select release, then make sure you have a released version 'bin'
            //in folder. Be carful as windows explorer is not set up to show 
            //common file types. 

            //To fix it add try-catch block to fix most of code.
            try
            { 
                StreamReader myReader = new StreamReader("Value1.txt");
				//Note: Changed "Value.txt" to "Value1.txt"

				//Directory Example of error: Boo folder does not exist
				//StreamReader myReader = new StreamReader("\\boo\\Value1.txt");

				//File Not Found Example of error: In line with "Value1.txt" change
				//StreamReader myReader = new StreamReader("Value1.txt");

				//If you hover your mouse over the actual constuctor(latter part)
				//of stringreader, you can see overloads available and number
				//of exceotions that can occur with the code.
				string line = "";

                while (line != null)
                {
                    line = myReader.ReadLine();
                    if (line != null)
                    {
                        Console.WriteLine(line);
                    }
                }

                myReader.Close();

                ///It might seem tempting to wrap all of your code in a try-catch 
                /// block. However it's lazy, though some now-ostacized developers
                /// have done that which results in cryptic error messages.
                /// Like if we just relied on catch exception e. Sometimes developers
                /// leave exception handling for the very end of the software
                /// developing process. 
                /// You should strive to put the same amount of attention into 
                /// protecting your user from having to guess at what to do next
                /// or how to fix the problem. If you can fix problem without user
                /// knowing it, awesome. If you can't, identify the exact problem
                /// and then ask the user for input that you might need to handle
                /// that situation gracefully. You should protect the user from losing data
                /// or feeling stupid. AKA a reliable experience, NO SUPRISES!!!
                /// 
                /// Try to put a try-catch block around code that relies on external
                /// input like the "Values.txt" file

				//Re-write this and look for specific exceptions first
				//'DirectoryNotFOundException'
				//KEY is to look for the most specific exceptions first
                //then most generic exceptions
			}
            catch(DirectoryNotFoundException e) 
            { 
                Console.WriteLine("Couldn't find the file. Are you sure the DIRECTORY exists?");
            }
            catch(FileNotFoundException e)
            {
                Console.WriteLine("Couldn't find the file. Are you sure you are looking for the correct FILE");
            }
            catch (Exception e)
            {
                //ANY time an exception happens, we want to catch it
                //To go further add "()" after "catch"
                //There is a lot of info we can retrieve about exception "e"
                //"Message" will give the actual message. Though we want to give
                //the user as mush info a possible so they can fix it themselves.
                //To rework the code, we will have to know how type of exceptions
                //that our application can throw
                Console.WriteLine("Something didn't quite work correctly: {0}", e.Message);
            }
            finally 
            {
                //Perform any clean up to roll back the data or close connections
                // to files, database, network, etc.

                //Use "Finally" to wrap things up. Can't get to resource you need to
                // etc.
            }

            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace HelperMethods
{
    class Program
    {
        static void Main(string[] args)
        {

            //This is a collection of methods that can be reused/adjusted to fit most programs, and will serve as a reference.
            //Any helpful modifications should be listed along with the methods themselves, to allow for customization.

            //Try...Catch block for integer conversion
            bool keepGoing = true;
            string userinput = GetInput("Give us a #");

            while (keepGoing == true)
            {
                try //This part attempts whatever is in the block below.  This structure only works for actual exceptions - not any if/else scenario.
                {
                    int.Parse(userinput);
                }
                catch (FormatException e) //e represents exception error variable here - needed for syntax and often just used as 'e'
                {

                    Console.WriteLine("Bad Input.  Please use a # instead.");
                    continue; //this jumps back to the top of the while loop if we catch an exception.

                    //different exceptions can be used, and we can also use multiple catch blocks if multiple exceptions could be thrown.
                    //A "catch-all" expression could be catch (Exception e) to gather all exceptions
                    //You can print system messages tied to these exceptions with e.Message and/or e.StackTrace to find out where in the code the exception came from.  Most useful when just looking at Exception e.
                }
                keepGoing = ContinueLoop("Continue?");
            }


        }
        public static string GetInput(string prompt)
        {
            //used for any question/answer, and you can pass in any question needed within the main method
            //Would still need to be converted to another data type if looking for an int, for example

            Console.WriteLine(prompt);
            string output = Console.ReadLine();
            return output;
        }
        public static bool ContinueLoop(string question)
        {
            //This ContinueLoop() method can be called at the end of while loops to either trigger another run of the while loop, or break the user out of that loop
            //at the end of the while loop, reference the boolean that is triggering the while loop while(boolVariable) by saying boolVariable = ContinueLoop("Try again? y/n")
            //Play around w this and see if a continue keyword could be used to go back to the top of the while loop.  Check class resources from 10/14
            string answer = GetInput(question);
            if (answer.ToLower() == "y")
            {
                return true;
            }
            else if (answer.ToLower() == "n")
            {
                Console.WriteLine("OK, goodbye!");
                return false;
            }
            else
            {
                return ContinueLoop("I'm sorry, I didnt catch that.  Please input y to try again, or n to exit.");
            }
        }

​
        public static bool RangeCheck(int min, int max, int num)
        {
            //Use whenever an input should have a certain min/max.  Pass in an int variable at the end when validating a user's input is within the range.
            //Messaging can be added here if needed.
            if (num >= min && num <= max)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void Dictionary()
        {


            //Dictionaries take in two types - could have used this for the 10.12 lab!  Look @ James' code for that
            //first value = key, 2nd value = value
            //values may repeat as needed, but every key is unique per dictionary

            Dictionary<string, string> homeTowns = new Dictionary<string, string>();
            //we get red curlies if we do not have the "using System.Collections.Generic" at the top.  If that isn't there, the dictionary functionality will not work.

            List<string> students = new List<string>() { "Erin", "Ramone", "James" };

            //we created a list, and now we are going to create our dictionary.  
            //Using the add method, two parameters are taken - key and value.

            homeTowns.Add("Erin", "Texas");
            //using the key as Erin, that means when we search for Erin in the dictionary, we get her corresponding hometown
            homeTowns.Add("Ramone", "Canada");
            homeTowns.Add("James", "South Detroit");

            //printing out our list of students and their indexes
            //*Making a print list method (below)
            PrintList(students);

            PrintDictionary(homeTowns);

            // This is showing us how to use the index of one list, to then use that selected index to feed the key into the dictionary, to return the value assoc w that - the hometown in this case.
            string response = GetInput("Which student do you want to learn about?  Select by index.  ");
            int pick = int.Parse(response);  //not validating or limiting, due to time - we would normally want to account for errors here

            string name = students[pick];
            string home = homeTowns[name];

            Console.WriteLine($"{name}'s home town is {home}.");



        }
        public static void PrintList(List<string> Names) //format to print from a list/array
        {
            for (int i = 0; i < Names.Count; i++)
            {
                Console.WriteLine($"{i}: {Names[i]}");
            }
        }

        public static void PrintDictionary(Dictionary<string, string> dict)
        //"dict" above is just instantiating the name of the dictionary within this method

        {
            foreach (string key in dict.Keys) //dict.Key is a list of all the keys in the dictionary 'dict' - looping through that will allow us to see the values
            {
                Console.WriteLine("Key: " + key);
                string value = dict[key];
                Console.WriteLine("Value: " + value);
                Console.WriteLine();
            }
        }
        public static bool CheckPasswordRules(string input) //this is a good example of input rules created within a method
        {
            if (input.Length > 12 || input.Length < 7)
            {
                Console.WriteLine("I'm sorry, that password does not meet length requirements.  Please choose a password of 7-12 characters.\n");
                return false;
            }
            else if (input.ToLower() == input || input.ToUpper() == input)
            {
                Console.WriteLine("I'm sorry, that password does not meet case requirements.  Please include at least one capital and one lower-case letter.\n");
                return false;
            }
            else if (input.Any(char.IsDigit) == false)//found this .All and .Any method on stack overflow, got the lightbulb to pop up "using System.Linq"
                //Can also use input.All as well, once you are using System.Linq
            {
                Console.WriteLine("I'm sorry, but this password does not contain any numbers.  Please include at least one integer in the password.\n");
                return false;
            }
            else if (input.Any(char.IsLetter) == false)
            {
                Console.WriteLine("I'm sorry, but this password does not contain any letters.  Please include at least one letter in the password.\n");
                return false;
            }
            else if (SpecCharValidation(input) == false) //
            {
                Console.WriteLine("I'm sorry, but your password did not contain a special character.  Please include one of the following symbols and try again:\n!, @, #, $, %, ^, &, *.");
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool SpecCharValidation(string input) //there are different ways to do this, and can actually be done as a range, thanks to ASCII tables
            //This also makes the CheckPasswordRules method function, so I brought it in
        {
            string specialChar = "!@#$%^&*";
            foreach (var item in specialChar)
            {
                if (input.Contains(item))
                {
                    return true;
                }
            }
            return false;
        }
    }
}


    


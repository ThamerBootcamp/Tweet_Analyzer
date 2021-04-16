using System;
using System.Collections.Generic;

namespace Tweet_Analyzer
{
    class Program
    {
        static List<List<string>> analyzeTweet(string source)
        {
            string token = "";
            int index = 0;
            List<List<string>> result = new List<List<string>>();
            List<string> tags = new List<string>();
            List<string> users = new List<string>();


            while (index < source.Length)
            {
                token = "";

                char currentChar = source[index];

                if (currentChar == '#' && (index + 1) < source.Length) // check if #
                {
                    token += currentChar;//add # to token

                    index++;
                    currentChar = source[index];

                    if (Char.IsLetterOrDigit(currentChar) && !Char.IsWhiteSpace(currentChar)) //check if at least a char after # is int or letter
                    {
                        currentChar = source[index];//add next char to token
                        token += currentChar;
                        index++;

                        while (index < source.Length && (Char.IsLetterOrDigit(currentChar) || currentChar == '_')) //
                        {
                            currentChar = source[index];

                            if (Char.IsWhiteSpace(currentChar) || currentChar == '#')
                                break;

                            token += currentChar;

                            index++;
                        }
                    }

                    tags.Add(token); //add to tags list
                }

                if (currentChar == '@' && (index + 1) < source.Length) // check if @
                {
                    token += currentChar;//add @ to token

                    index++;
                    currentChar = source[index];

                    if (Char.IsLetterOrDigit(currentChar) && !Char.IsWhiteSpace(currentChar)) //check if at least a char after @ is int or letter
                    {
                        currentChar = source[index];//add next char to token
                        token += currentChar;
                        index++;

                        while (index < source.Length && (Char.IsLetterOrDigit(currentChar) || currentChar == '_')) //
                        {
                            currentChar = source[index];

                            if (Char.IsWhiteSpace(currentChar))
                                continue;

                            token += currentChar;

                            index++;
                        }
                    }

                    users.Add(token); // add to users list
                }
                if (currentChar != '#') // this 'if' is to not change currentChar if the loops above broke because of new hashtag right after another
                    index++;
            }//end While

            result.Add(tags);
            result.Add(users);
            return result;

        }
        static void Main(string[] args)
        {
            string tweet = @"A very close game on Vertigo with 
                    @dignitas
                     taking the half 8 - 7.

                    @NAFFLY
                     pulling out the stops to keep
                    @TeamLiquidCS
                     competitive!Fire
                      #تويتر
    
                    #happy#life
                    #BLASTPremier | http://Twitch.tv/BLASTPremier
                    ";

            List<List<string>> analysis = analyzeTweet(tweet);

            List<string> tags = analysis[0];

            List<string> users = analysis[1];

            Console.WriteLine("number of tags is {0}", tags.Count);

            foreach (var item in tags)
                Console.WriteLine("tag: {0} ", item);

            Console.WriteLine("\nnumber of users is {0}", users.Count);

            foreach (var item in users)
                Console.WriteLine("user: {0}", item);

        }

    }
}

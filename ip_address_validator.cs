/*
C#:
Program for checking if the ip addresses in the array are valid.
This has been my approach:
first I checked if the numbers are 4 in a single ip address and then 
I decided to divide the problem in 3 sub problems creating 3 methods: CheckValidNumber() - checks single number, Error()
- just for avoid repetitions, CheckIpAddress() - checks all the numbers of a single ip address

Solved by Alessandro Silvestri for Microsoft Learn - 2023 <alessandro.silvestri.work@gmail.com>
*/

using System;

namespace myProgram
{
    class Program
    {
        static void Main(string[] arg)
        {
            // ip addresses to check
            string[] ipv4Input = { "107.31.1.5", "255.0.0.255", "555..0.555", "255...255" };
            // check any ip address
            foreach (string i in ipv4Input)
            {
                //using the method I made
                CheckIpAddress(i);
            }
        }
      
        static void CheckIpAddress(string ipAddress)
        // verify the entire ip address
        {
            //converting the string in an array
            string[] ipAddressSplit = ipAddress.Split(".");
            // check if they are for numbers
            if (ipAddressSplit.Length != 4)
            {
                Error(ipAddress);
            }
            else
            {
                bool validIp = true;
                foreach (string i in ipAddressSplit)
                // for any item (number) in the array i veirfy the number using the method I made: CheckValidNumber
                {
                    if (!CheckValidNumber(i) || i == "")
                    {
                        validIp = false;
                        break;
                    }
                }
                // print the message according the result
                if (validIp)
                {
                    Console.WriteLine(ipAddress + " is a valid IPv4 address");
                }
                else
                {
                    Error(ipAddress);
                }
            }
        }
      
        static bool CheckValidNumber(string num)
        // check single number if it is between 0 an 255
        {
            bool validIp = false;
            int.TryParse(num, out int numParsed);
            if (numParsed >= 0 && numParsed <= 255)
            {
                validIp = true;
            }
            return validIp;
        }

        static void Error(string ipAddress)
        // error message
        {
            Console.WriteLine(ipAddress + " is an invalid IPv4 address");
        }
    }
}


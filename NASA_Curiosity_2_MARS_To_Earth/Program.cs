using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTransferBusinessLayer;

namespace NASA_Curiosity_2_MARS_To_Earth
{
    class Program
    {
        static void Main(string[] args)
        {
            #region to enter values of m1, m2, m3
            int m1 = -1, m2 = -1, m3 = -1;
            //Prompt user to enter value of m1
            while (m1 == -1)
            {
                Console.WriteLine("Enter Memory Capacity of Satellite 1");
                bool b1 = int.TryParse(Console.ReadLine().ToString(), out m1);
                if (b1 == false || m1 < 0)
                {
                    m1 = -1;
                    Console.WriteLine("Invalid Value Entered");
                }
            }

            Console.WriteLine("** Sorage Memory of Satellite 1 is {0} **", m1);
            Console.WriteLine(" ");

            //Prompt user to enter value of m2
            while (m2 == -1)
            {
                Console.WriteLine("Enter Memory Capacity of Satellite 2");
                bool b2 = int.TryParse(Console.ReadLine().ToString(), out m2);
                if (b2 == false || m2 < 0)
                {
                    m2 = -1;
                    Console.WriteLine("Invalid Value Entered");
                }
            }
            Console.WriteLine("** Sorage Memory of Satellite 2 is {0} **", m2);
            Console.WriteLine(" ");

            //Prompt user to enter value of m3
            while (m3 == -1)
            {
                Console.WriteLine("Enter Memory Capacity of Satellite 3");
                bool b3 = int.TryParse(Console.ReadLine().ToString(), out m3);
                if (b3 == false || m3 < 0)
                {
                    m3 = -1;
                    Console.WriteLine("Invalid Value Entered");
                }
            }
            Console.WriteLine("** Sorage Memory of Satellite 3 is {0} **", m3);
            Console.WriteLine(" ");

            #endregion


            #region hardcoding for testing
            ////// hardcoding
            //Queue<String> msgQueue = new Queue<string>();
            //int m1 = 2, m2 = 1, m3 = 1;
            //msgQueue.Enqueue("FOUND A STONE");
            //msgQueue.Enqueue("SOME UNKNOWN CREATURE DRINKING WATER");
            //msgQueue.Enqueue("FOUND AIR AND WATER NEAR SOME CREATURE");

            //msgQueue.Enqueue("MY NAME IS VINEET");
            //msgQueue.Enqueue("NAME MY VINEET");
            //msgQueue.Enqueue("MY");
            //msgQueue.Enqueue("TO VINEET IS MY FAME");
            //msgQueue.Enqueue("TO VINEET IS FAME");
            //msgQueue.Enqueue("TO IS");
            //msgQueue.Enqueue("FOUND AIR AND WATER NEAR SOME CREATURE");
            #endregion

            #region To enter messages and transfer data to Earth

            Queue<String> msgQueue = new Queue<string>();
            string moreMsg = "YES";
            bool validResponse;
            string stopExec = string.Empty;
            while (moreMsg == "YES")
            {
                Console.WriteLine(" ");
                Console.WriteLine("Enter the message to be transferred");
                msgQueue.Enqueue(Console.ReadLine().ToUpper());
                validResponse = false;
                while (!validResponse)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Want to send more messages : YES or NO");
                    moreMsg = Console.ReadLine().ToUpper();
                    if (moreMsg == "YES" || moreMsg == "NO")
                    {
                        validResponse = true;
                    }
                    else
                        Console.WriteLine("Invalid Response Entered");
                }
            }
            Console.WriteLine(" ");
            Console.WriteLine("*****************************************");
            Console.WriteLine("******* Sending Message To Earth ********");
            Console.WriteLine("*****************************************");
            Console.WriteLine("******* Sending Message To Earth ********");
            Console.WriteLine("*****************************************");
            Console.WriteLine("******* Sending Message To Earth ********");
            Console.WriteLine("*****************************************");
            Console.WriteLine("******* Sending Message To Earth ********");
            Console.WriteLine("*****************************************");
            Console.WriteLine("******* Sending Message To Earth ********");
            Console.WriteLine("*****************************************");
            Console.WriteLine(" ");

            string messageToBeTransferred = string.Empty;
            MARS_Message_Handler objSMT = new MARS_Message_Handler();
            int total = 0;
            while (msgQueue.Count > 0)
            {
                messageToBeTransferred = msgQueue.Dequeue();
                messageToBeTransferred.Trim();
                total = objSMT.messageProcessor(messageToBeTransferred, m1, m2, m3);

                Console.WriteLine("########################################################");
                Console.WriteLine("{0} : Time Taken is {1} hours", messageToBeTransferred, total);
                Console.WriteLine(" ");
            }



            #endregion

            Console.ReadLine();
        }
    }
}

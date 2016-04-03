using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saving_and_loading_data
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
             * Algorithm
             * 1. Open file for write operation
             * 2. Write data to file
             * 3. Close file 
             */

            try
            {
                //Declare variables
                int maxNumbers = 100;

                int[] Numbers = new int[maxNumbers];

                Random rnd = new Random();

                //generate numbers
                for (int currentNumber = 0; currentNumber < maxNumbers; currentNumber++)
                {
                    Numbers[currentNumber] = rnd.Next(1, 1001);

                }//End For loop

                //Save data
                //WriteNumbersToTextFile(Numbers);

                WriteNumbersToBinaryFile(Numbers);

                //Read numbers in
                //ReadNumbersFromTextFile(maxNumbers);

                ReadNumbersFromBinaryFile(maxNumbers);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //Pause
            Console.ReadKey();
            
        }//End Main



        private static void WriteNumbersToBinaryFile(int[] Numbers)
        {
            try
            {
                //Open I/O channel
                BinaryWriter bw = new BinaryWriter(File.Open("Numbers.bin", FileMode.Create));

                for (int currentNumber = 0; currentNumber < Numbers.Length; currentNumber++)
                {
                    bw.Write(Numbers[currentNumber]);

                }//End For

                //Close I/O channel and free RAM
                bw.Close();
                bw.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }            

        }//End WriteNumbersToBinaryFile



        private static void ReadNumbersFromBinaryFile(int maxNumbers)
        {
            try
            {
                //Declaration of Variables
                int numberReadIn = 0;

                //Open I/O channel
                BinaryReader br = new BinaryReader(File.Open("Numbers.bin", FileMode.Open));

                for (int currentNumber = 0; currentNumber < maxNumbers; currentNumber++)
                {
                    //Have to specify the data type for the read operation
                    numberReadIn = br.ReadInt32();

                    //Write to screen
                    Console.WriteLine(numberReadIn.ToString());

                }//End For

                //Close I/O channel and free RAM
                br.Close();
                br.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }            
        }



        private static void WriteNumbersToTextFile(int[] Numbers)
        {
            try
            {
                //Open I/O Channel
                StreamWriter sw = new StreamWriter("Numbers.txt");

                for (int currentNumber = 0; currentNumber < Numbers.Length; currentNumber++)
                {
                    sw.WriteLine(Numbers[currentNumber].ToString());

                }//End for

                //Close I/O channel and free RAM
                sw.Close();
                sw.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }//End WriteNumbersToTextFile



        private static void ReadNumbersFromTextFile(int maxNumbers)
        {
            try
            {
                //Declare variable
                string number = null;

                //Open I/O Channel
                StreamReader sr = new StreamReader("Numbers.txt");

                //Header for display
                Console.WriteLine("Numbers read from file");
                Console.WriteLine();

                //TXT file store strings not numbers
                for (int currentNumber = 0; currentNumber < maxNumbers; currentNumber++)
                {
                    //Read from file
                    number = sr.ReadLine();

                    //Write to screen
                    Console.WriteLine(number);

                }//End for

                //Close I/O channel and free RAM
                sr.Close();
                sr.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }//End ReadNumbersFromTextFile


    }
}

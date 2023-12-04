using System;
using System.IO;
using System.Linq.Expressions;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static int re;
        static int lettertonumber(string pos)
        {
            switch (pos)
            {
                case "one":
                    re = 1;
                    break;
                case "two":
                    re = 2;
                    break;
                case "three":
                    re = 3;
                    break;
                case "four":
                    re = 4;
                    break;
                case "five":
                    re = 5;
                    break;
                case "six":
                    re = 6;
                    break;
                case "seven":
                    re = 7;
                    break;
                case "eight":
                    re = 8;
                    break;
                case "nine":
                    re = 9;
                    break;
            }
            return re;
        }
        static int positionfirst;
        static int minnum;
        static void minpos(string row, string[] spo)
        {
            positionfirst = 90;
            for (int k = 0; k < 9; k++)
            {
                int ph = row.IndexOf(spo[k]);
                if (ph < positionfirst && ph != -1)
                {
                    positionfirst = row.IndexOf(spo[k]);
                    Console.WriteLine(positionfirst);
                    minnum = k;
                }
            }
            //Console.WriteLine("first: "+ positionfirst);
        }


        static int positionlast;
        static int maxnum;

        static void maxpos(string row, string[] spo )
        {
            positionlast = -1;
            for (int k = 0; k < 9; k++)
            {
                int ph = row.LastIndexOf(spo[k]);
                if (ph > positionlast && ph != -1)
                {
                    positionlast = row.LastIndexOf(spo[k]);
                    //Console.WriteLine("pos: " + positionlast);
                    maxnum = k;
                }
            }
            //Console.WriteLine("last: "+ positionlast);
        }
        static void Main(string[] args)
        {
            
            int sum = 0;
            char[] digits = new char[10] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            string[] spelledout = new string[9] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            FileStream f = new FileStream("source.txt", FileMode.Open);
            StreamReader fs = new StreamReader(f);
            while (!fs.EndOfStream)
            {
                string line = fs.ReadLine();
                string number = "";
                int i = 0; int j = 0;
                bool find = false;
                Console.WriteLine(line);
                minpos(line, spelledout);
                maxpos(line, spelledout);

                while ( i < line.Length && find != true)
                {
                    j = 0;
                    while (j < 10 && find != true)
                    {
                        if (line[i] == digits[j] && find != true)
                        {
                           // Console.WriteLine("Első: "+ digits[j]);
                           // Console.WriteLine(j);
                            //Console.WriteLine("pos " + positionfirst);
                            find = true;
                        }
                        j++;
                    }
                    i++;
                }

                i --;
                j--;

                if (i < positionfirst && find==true)
                {
                    //Console.WriteLine("Szám " + j);
                    number += digits[j];
                }
                else
                {
                    //Console.WriteLine("number " + spelledout[minnum]);
                    number += lettertonumber(spelledout[minnum]).ToString();
                }


                i = line.Length - 1; j = 0; find = false;
                while (i >= 0 && find != true)
                {
                    j = 0;
                    while (j < 10 && find != true)
                    {
                        if (line[i] == digits[j] && find != true)
                        {
                            //Console.WriteLine("Hátsó: " +line[i]);
                            find = true;
                        }
                        j++;
                    }
                    i--;
                }

                //Console.WriteLine("lastdig: " + j);
                //Console.WriteLine("last let " + maxnum);
                i++;
                j--;

                if (i > positionlast && find == true)
                {
                    
                    //Console.WriteLine("szám2 " + j);
                    number += digits[j];
                }
                else
                {
                    //Console.WriteLine("number2 " + maxnum);
                    number += lettertonumber(spelledout[maxnum]).ToString();
                }
                Console.WriteLine("number:" + number);
                sum += Convert.ToInt32(number);
            }
            Console.WriteLine("Sum: " + sum);
            fs.Close();
            f.Close();
        }
    }
}
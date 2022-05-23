using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {

        static Perceptron p;
        static Random rnd = new Random();

        static void Main(string[] args)
        {
            string data = @"C:\neural\data1.csv";
            string lastTip = @"C:\neural\lestTip.txt";
            float error = 100;

            string[] lines = File.ReadAllLines(data);

            List<float[]> input = new List<float[]>();
            List<float> output = new List<float>();

            for (int i = 0; i < lines.Length; i++)
            {
                string[] line = lines[i].Split(';'); 
                float[] inp = { float.Parse(line[0]) , float.Parse(line[1]) };
                input.Add(inp);
                float outp = float.Parse(line[2]);
                output.Add(outp);
            }
             

            p = new Perceptron();

            /*float[] input1 = { 0, 0 };
            float[] input2 = { 0, 1 };
            float[] input3 = { 1, 0 };
            float[] input4 = { 1, 1 };
            float[][] inputs = { input1, input2, input3, input4 };
            int[] output = {0, 0, 0, 1};*/

            /*for (int i = 0; i < 30; i++)
            {
                int k = rnd.Next(0,input.Count());
                for (int j = 0; j < 100000; j++)
                {
                    p.train(input[k], output[k]);
                    error += p.errors;
                }
                Console.WriteLine(error/100000);
            }*/

            
            while (true)
            {
                if (error / 10 > 1)
                {
                    int k = rnd.Next(0, input.Count());
                    error = 0;
                    for (int j = 0; j < 100; j++)
                    {
                        p.train(input[k], output[k]);
                        error += Math.Abs(p.errors);
                    }
                    Console.WriteLine(error / 1000);
                }
                else
                {
                    break;
                }
            }

            //int gues = rnd.Next(0, input.Count());
            //float guess = p.gues(input[gues]);
            //Console.WriteLine();
            //Console.WriteLine("Elvárt: " + output[gues] + "     Eredmény:" + Math.Abs(guess) + "     Súlyok:" + p.Weight());
            //File.WriteAllText(lastTip,File.ReadAllText(lastTip) + "Elvárt: " + output[gues] + "     Eredmény:" + Math.Abs(guess) + "     Súlyok:" + p.Weight() + "\n");
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Perceptron
    {
        private float[] weights = new float[2];
        static Random rnd = new Random();
        private float learningRate = 0.0001f;
        public float errors;

        public Perceptron()
        {
            for (int i = 0; i < weights.Length; i++)
            {
                weights[i] = rnd.Next(-1, 1);
            }
        }

        public float gues(float[] input)
        {
            float sum = 0;
            for (int i = 0;i < weights.Length;i++)
            {
                sum += input[i] * weights[i];
            }
            float output = sign(sum);

            return output;
        }

        public void train(float[] input, float target)
        {
            float guess = gues(input);
            float error = (float)target - guess;
            errors = error;

            for (int i = 0; i < weights.Length; i++)
            {
                weights[i] += error * input[i] * learningRate;
            }
        }

        private float sign(float n)
        {
            double sin = Math.Sinh(n);
            double tan = Math.Tanh(n);


            return n+n;
        }

        public string Weight()
        {
            string outp = "";

            for (int i = 0; i < weights.Length-1; i++)
            {
                outp += weights[i] + " , ";
            }
            outp += weights[weights.Length-1];

            return outp;
        }
    }
}

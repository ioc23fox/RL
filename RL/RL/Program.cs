using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RL
{
    public class RL
    {
        public static RL Zero
        {
            get
            {
                return new RL();
            }
        }
        public static RL operator +(RL a, RL b)
        {
            RL result = RL.Zero;
            result.Data.AddRange(a.Data);
            result.Data.AddRange(b.Data);
            result.Normalize();
            return result;
        }


        public int Count { get; private set; }
        public int Sign { get; private set; }
        public List<int> Data { get; private set; }
        public string StringValue
        {
            get
            {
                return Sign + "." + Count + "." + String.Join(".", Data);
            }
        }
        private string goodRLNumber = @"^(?<sign>(:?- )?)(?<numbers>(-?\d+?\.)*?\d+)$";

        public RL()
        {
            Count = 0;
            Sign = 0;
            Data = new List<int>();
        }
        private void Normalize()
        {
            this.Count = this.Data.Count();
            this.Sign = 0;
            this.Data = this.Data.OrderByDescending(x => x).ToList<int>();
            for (int i = 0; i < this.Data.Count() - 1; i++)
            {
                var first = this.Data[i];
                var second = this.Data[i + 1];
                if (first == second)
                {
                    this.Data[i]++;
                    this.Data.Remove(second);

                    i = 0;
                }
            }
            Console.WriteLine("normalized");
        }

        public RL(string data)
        {
            bool isGood = Regex.IsMatch(data, goodRLNumber);
            if (isGood)
            {
                var matchingResult = Regex.Match(data, goodRLNumber);
                var numbers = matchingResult.Groups["numbers"].Value;
                var sign = matchingResult.Groups["sign"].Value;

                Data = numbers.Split('.').ToList<string>().ConvertAll<int>(x => int.Parse(x)).OrderByDescending(x => x).ToList<int>();
                Count = Data.Count();
                Sign = sign == "- " ? 1 : 0;
            }
            else throw new Exception("Error: bad data in " + data);
        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            var first = new RL("14.10.9.8.5.4.3.-1.0");
            var secod = new RL("17.15.10.6");
            Console.WriteLine(first.StringValue);
            Console.WriteLine(secod.StringValue);
            //var result = first + secod;
            //Console.WriteLine(result.StringValue);
           
            Console.Read();
        }
    }
}

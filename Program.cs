using System;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace StringCreationBenchmarking
{
    class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<Bencher>();
        }
    }
    
    [MemoryDiagnoser]
    public class Bencher
    {
        private const string FullSosh = "123-45-6789";
        
        [Benchmark]
        public string MaskNaive()
        {
            var firstChars = FullSosh.Substring(0, 3);
            var maskLength = FullSosh.Length - 3;

            for (int i = 0; i < maskLength; i++)
            {
                firstChars += '*';
            }

            return firstChars;
        }

        [Benchmark]
        public string MaskStringBuilder()
        {
            var firstChars = FullSosh.Substring(0, 3);
            var maskLength = FullSosh.Length - 3;
            var stringBuilder = new StringBuilder(firstChars);
            
            for (var i = 0; i < maskLength; i++)
            {
                stringBuilder.Append('*');
            }
        
            return stringBuilder.ToString();
        }
        
        [Benchmark]
        public string MaskNewString()
        {
            var firstChars = FullSosh.Substring(0, 3);
            var maskLength = FullSosh.Length - 3;
            var mask = new string('*', maskLength);
            return firstChars + mask;
        }
        
        [Benchmark]
        public string MaskStringCreate()
        {
            return string.Create(FullSosh.Length, FullSosh, (span, state) =>
            {
                state.AsSpan().CopyTo(span);
                span[3..].Fill('*');
            });
        }
    }
}
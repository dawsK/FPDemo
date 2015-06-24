using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FsharpDemoCSharp
{
    class FizzBuzz
    {
        public static string Answer(int i)
        {
            if (i%3 == 0 && i%5 == 0) return "FizzBuzz";
            if (i%3 == 0) return "Fizz";
            if (i%5 == 0) return "Buzz";
            return i.ToString();
        }

        public static void Run()
        {
            for (var i = 1; i <= 100; i++)
            {
                Console.WriteLine(Answer(i));
            }
        }
    }

    [TestClass]
    public class FizzBuzzTest
    {
        [TestMethod]
        public void TestFizzBuzz()
        {
            FizzBuzz.Answer(1).Should().Be("1");
            FizzBuzz.Answer(2).Should().Be("2");
            FizzBuzz.Answer(3).Should().Be("Fizz");
            FizzBuzz.Answer(4).Should().Be("4");
            FizzBuzz.Answer(5).Should().Be("Buzz");
            FizzBuzz.Answer(6).Should().Be("Fizz");
            FizzBuzz.Answer(7).Should().Be("7");
            FizzBuzz.Answer(8).Should().Be("8");
            FizzBuzz.Answer(9).Should().Be("Fizz");
            FizzBuzz.Answer(10).Should().Be("Buzz");
            FizzBuzz.Answer(11).Should().Be("11");
            FizzBuzz.Answer(12).Should().Be("Fizz");
            FizzBuzz.Answer(13).Should().Be("13");
            FizzBuzz.Answer(14).Should().Be("14");
            FizzBuzz.Answer(15).Should().Be("FizzBuzz");
        }

        [TestMethod]
        public void Run()
        {
            FizzBuzz.Run();
        }
    }
}

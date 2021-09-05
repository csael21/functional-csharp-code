using System;
using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;

namespace Exercises.Chapter1
{
    static class Warmup
    {
        // Programming Exercises 
        // 1.  You are given a lower and an upper bound for a range of integer numbers.
        //     Write a program that prints the numbers that are divisible by of 2.
        // 2.  Write a simple program that can print the smallest number from the list of numbers.
        // 3.  List the evens or the odds.You are given a lower and an upper bound for a range of
        //     integer numbers.List the even numbers and list the odd numbers separately. 
        // 4. You are given a lower and an upper bound for a range of integer numbers.
        //    Write a program that prints the range of numbers in the reverse order and
        //    prints it with the original order.
        // 5. Develop a unique problem to solve using C# using Functional Paradigm.
        //    You should write the problem and it’s solution to receive credit. 

        /**
         * If the range is valid 
         * Print even numbers of specified range (lower,upper)
         * Throws ArgumentOutOfRangeException if range is invalid 
         * param lower  lower range of list
         * param upper  upper range of list
         * Returns list with specified range of even numbers only
         * */
        static public List<int> Problem1(int lower, int upper)
        {
            List<int> localList = new List<int>();
            System.Console.WriteLine("Problem1");
            if (lower < upper)
            {
                localList = Enumerable.Range(lower, upper).Where(x => x % 2 == 0).ToList();
                localList.ForEach(num => Console.Write($"{num},"));
                Console.WriteLine("");
            }
            else
            {
                throw new ArgumentOutOfRangeException("Invalid range");
            }
            return localList;
        }
        /**
         * Print smallest numbers of specified list
         * Throws ArgumentOutOfRangeException list is empty
         * Returns smallest number in list
         * */
        static public int Problem2(int[] testNums)
        {
            System.Console.WriteLine("Problem2");
            int min;
            if (testNums.Length > 0)
            {
                min = testNums.Min();
                Console.WriteLine($"Smallest Num:{min}");
            }
            else
            {
                throw new ArgumentOutOfRangeException("Empty List");
            }
            return min;
        }
        /**
          * List the evens or the odds.You are given a lower and an upper bound for a range of
          * integer numbers.List the even numbers and list the odd numbers separately. 
          * */
        static public List<List<int>> Problem3(int lower, int upper)
        {
            List<List<int>> localLists = new List<List<int>>();

            System.Console.WriteLine("Problem3");
            if (lower < upper)
            {
                Console.WriteLine("Evens:");
                localLists.Add(Enumerable.Range(lower, upper).Where(x => x % 2 == 0).ToList());
                localLists[0].ForEach(num => Console.Write($"{num},"));
                Console.WriteLine("");
                Console.WriteLine("Odds:");
                localLists.Add(Enumerable.Range(lower, upper).Where(x => x % 2 == 1).ToList());
                localLists[1].ForEach(num => Console.Write($"{num},"));
                Console.WriteLine("");
            }
            else
            {
                throw new ArgumentOutOfRangeException("Invalid range");
            }

            return localLists;
        }
        /**
         * You are given a lower and an upper bound for a range of integer numbers.
         * prints the range of numbers in the reverse order and
         * prints it with the original order.
         */
        static public List<List<int>> Problem4(int lower, int upper)
        {
            List<List<int>> localLists = new List<List<int>>();

            System.Console.WriteLine("Problem3");
            if (lower < upper)
            {
                Console.WriteLine("Org:");
                localLists.Add(Enumerable.Range(lower, upper).ToList());
                localLists[0].ForEach(num => Console.Write($"{num},"));
                Console.WriteLine("");
                Console.WriteLine("Reverse:");
                localLists.Add(Enumerable.Range(lower, upper).Reverse().ToList());
                localLists[1].ForEach(num => Console.Write($"{num},"));
                Console.WriteLine("");
            }
            else
            {
                throw new ArgumentOutOfRangeException("Invalid range");
            }
            return localLists;
        }
        /**
         * 5. Develop a unique problem to solve using C# using Functional Paradigm.
         *    You should write the problem and it’s solution to receive credit. 
         *    Problem Print range of odd number in reverse order and its even orignal order in Parallel
         */    
        static public List<List<int>> Problem5(int lower, int upper)
        {
            List<List<int>> listForTestResults = new List<List<int>>();
            List<int> localList = new List<int>();

            System.Console.WriteLine("Problem5");
            if (lower < upper)
            {
                localList=  Enumerable.Range(lower, upper).ToList();
                listForTestResults.Add(localList.Where(x => x % 2 == 0).ToList());
                listForTestResults.Add(localList.Where(x => x % 2 != 0).ToList());
                Action task1 = () =>
                {
                    localList.Where(x => x % 2 == 0).ToList().ForEach(num => Console.WriteLine($"OrgEven:{num}"));                    
                };
                Action task2 = () =>
                {
                    localList.Where(x => x % 2 != 0).Reverse().ToList().ForEach(num => Console.WriteLine($"RevOdd:{num}"));                    
                };
                System.Threading.Tasks.Parallel.Invoke(task1, task2);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Invalid range");
            }
            return listForTestResults;
        }

    }
    public class WarmUpProblemOneTest
    {
        [Test]        
        public static void Test1Problem1()
        {
            int l=0, u=10;
            bool isEven(int x) => x % 2 == 0;
            var expected = Enumerable.Range(l, u).Where(isEven).ToList(); ;
            var actual = Warmup.Problem1(l, u);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public static void Test2Problem1()
        {
            int l = -10, u = 0;
            bool isEven(int x) => x % 2 == 0;
            var expected = Enumerable.Range(l, u).Where(isEven).ToList(); ;
            var actual = Warmup.Problem1(l, u);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public static void Test1Problem2()
        {
            var expected = 0 ;
            var actual = Warmup.Problem2(new int[] { 0, 1, 2, 3, 4, 5 });
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public static void Test2Problem2()
        {
            var expected = -5;
            var actual = Warmup.Problem2(new int[] { 0, -1, 2, -3, 4, -5 });
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public static void Test1Problem3()
        {
            int l = 0, u = 10;
            bool isEven(int x) => x % 2 == 0;
            bool isOdd(int x) => x % 2 == 1;
            var expectedEven = Enumerable.Range(l, u).Where(isEven).ToList(); 
            var actual = Warmup.Problem3(l, u);
            Assert.AreEqual(expectedEven, actual[0]);
            var expectedOdd = Enumerable.Range(l, u).Where(isOdd).ToList(); 
            Assert.AreEqual(expectedOdd, actual[1]);
        }

        [Test]
        public static void Test1Problem4()
        {
            int l = 0, u = 10;
            var expectedOrg = Enumerable.Range(l, u).ToList(); ;
            var actual = Warmup.Problem4(l, u);
            Assert.AreEqual(expectedOrg, actual[0]);
            var expectedRev = Enumerable.Range(l, u).Reverse().ToList(); ;
            Assert.AreEqual(expectedRev, actual[1]);
        }
        [Test]
        public static void Test1Problem5()
        {
            int l = 0, u = 10;
            bool isEven(int x) => x % 2 == 0;
            bool isOdd(int x) => x % 2 == 1;
            var expectedOrgEven = Enumerable.Range(l, u).Where(isEven).ToList();
            var expectedRevOdd = Enumerable.Range(l, u).Where(isOdd).ToList();

            var actual = Warmup.Problem5(l, u);
            Assert.AreEqual(expectedOrgEven, actual[0]);
            var expectedRev = Enumerable.Range(l, u).Reverse().ToList(); ;
            Assert.AreEqual(expectedRevOdd, actual[1]);
        }
    }
}



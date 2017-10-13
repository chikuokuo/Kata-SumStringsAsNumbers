using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SumStringsAsNumbers
{
    [TestClass]
    public class SumStringsAsNumbersTest
    {
        [TestMethod]
        public void Input_Empty_Empty_ShouldReturn_Error()
        {
            SumValueShouldEqual("Error", string.Empty, string.Empty);
        }

        [TestMethod]
        public void Input_1_1_ShouldReturn_Error()
        {
            SumValueShouldEqual("2", "1", "1");
        }

        [TestMethod]
        public void Input_10_5_ShouldReturn_Error()
        {
            SumValueShouldEqual("15", "10", "5");
        }

        [TestMethod]
        public void Input_11_12_ShouldReturn_Error()
        {
            SumValueShouldEqual("23", "11", "12");
        }

        [TestMethod]
        public void Input_17_5_ShouldReturn_Error()
        {
            SumValueShouldEqual("22", "17", "5");
        }

        [TestMethod]
        public void Input_107_5_ShouldReturn_Error()
        {
            SumValueShouldEqual("112", "107", "5");
        }

        [TestMethod]
        public void Input_107_95_ShouldReturn_Error()
        {
            SumValueShouldEqual("202", "107", "95");
        }

        [TestMethod]
        public void Input_132457_987654321_ShouldReturn_Error()
        {
            SumValueShouldEqual("987786778", "132457", "987654321");
        }
        private static void SumValueShouldEqual(string expected, string input1, string input2)
        {
            var result = new StringsSumer().Sum(input1, input2);

            Assert.AreEqual(expected, result);
        }

        public class StringsSumer
        {
            private Stack<char> addendStack;

            private Stack<char> augendStack;

            public string Sum(string a, string b) 
            {
                if (string.IsNullOrEmpty(a) || string.IsNullOrEmpty(a))
                {
                    return "Error";
                }

                addendStack = new Stack<char>(a);

                augendStack = new Stack<char>(b);

                var result = new Stack<string>();

                var carry = 0;

                while (true)
                {
                    var addend = addendStack.Count == 0 ? 0 : (int)Char.GetNumericValue(addendStack.Pop());
                    var augend = augendStack.Count == 0 ? 0 : (int)Char.GetNumericValue(augendStack.Pop());
                    var sum = addend + augend + carry;

                    result.Push((sum % 10).ToString());
                    carry = sum / 10;

                    if (addendStack.Count == 0 && augendStack.Count == 0)
                    {
                        if (carry != 0)
                        {
                            result.Push(carry.ToString());
                        }
                        break;
                    }
                }
                return string.Join("", result.ToArray());
            }
        }
    }
}

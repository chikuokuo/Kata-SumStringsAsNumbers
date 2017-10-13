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

            private Stack<string> result = new Stack<string>();

            public string Sum(string a, string b) 
            {
                if (string.IsNullOrEmpty(a) || string.IsNullOrEmpty(a))
                {
                    return "Error";
                }

                addendStack = new Stack<char>(a);

                augendStack = new Stack<char>(b);

                var carry = 0;

                while (true)
                {
                    SumNumberAddToStack(ref carry);

                    if (!CalCulateFinish()) continue;

                    AddLastCarry(carry);

                    break;
                }
                var resultString = string.Join("", result.ToArray());
                result.Clear();
                return resultString;
            }

            private void SumNumberAddToStack(ref int carry)
            {
                var sum = GetSum(carry);
                result.Push(GetRemainder(sum));
                carry = sum / 10;
            }

            private int GetSum(int carry)
            {
                var addend = GetNumber(addendStack);
                var augend = GetNumber(augendStack);
                var sum = addend + augend + carry;
                return sum;
            }

            private bool CalCulateFinish()
            {
                return addendStack.Count != 0 || augendStack.Count != 0;
            }

            private static string GetRemainder(int sum)
            {
                return (sum % 10).ToString();
            }

            private int GetNumber(Stack<char> stack)
            {
                return stack.Count == 0 ? 0 : (int)char.GetNumericValue(stack.Pop());
            }

            private void AddLastCarry(int carry)
            {
                if (carry != 0)
                {
                    result.Push(carry.ToString());
                }
            }
        }
    }
}

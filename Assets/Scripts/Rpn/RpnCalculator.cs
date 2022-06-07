using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Rpn
{
    public class RpnCalculator
    {
        public static double Calculate(string expression)
        {
            var tokens = GetRpn(expression);
            Stack<object> stack = new Stack<object>();
            foreach (var token in tokens) {
                if (IsOperator(token)) {
                    var b = (double)stack.Pop();
                    var a = (double)stack.Pop();
                    var c = Operate(a, b, token);
                    stack.Push(c);
                } else {
                    stack.Push(double.Parse(token));
                }
            }
            return (double)stack.Pop();
        }

        private static double Operate(double a, double b, string o) {
            switch (o) {
                case "+":
                    return a + b;
                case "-":
                    return a - b;
                case "×":
                    return a * b;
                case "÷":
                    return a / b;
                default:
                    return 0;
            }
        }

        public static bool IsOperator(string s) {
            if (s.Length == 1) {
                if (s[0] == '+' ||
                    s[0] == '-' || 
                    s[0] == '×' || 
                    s[0] == '÷')
                    return true;
            }
            return false;
        }

        public static List<string> GetRpn(string expression)
        {
            char[] sequenceList  = expression.ToCharArray();
            StringBuilder resultBuilder = new StringBuilder(sequenceList.Length);
            Queue<char> stack = new Queue<char>();

            for (var i = 0; i < sequenceList.Length; i++)
            {
                var token = sequenceList[i];
                var nextToken = sequenceList[(i + 1) % sequenceList.Length];
                switch (token) {
                    case '-':
                        if (nextToken == ' ') stack.Enqueue(token);
                        else resultBuilder.Append(token);
                        break;
                    case '+':
                    case '×':
                    case '÷':
                        stack.Enqueue(token);
                        break;
                    default:
                        resultBuilder.Append(token);
                        break;
                }
            }

            while (stack.Count > 0) {
                resultBuilder.Append(' ');
                resultBuilder.Append(stack.Dequeue());
            }
            
            return resultBuilder
                .ToString()
                .Split(' ')
                .Where(s => s != "")
                .ToList();
        }
    }
}
    

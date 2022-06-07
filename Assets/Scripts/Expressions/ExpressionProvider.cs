using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UniRx;
using Operators;
using Operands;
using Rpn;
using Data;

namespace Expressions
{
    [RequireComponent(typeof(NumericProvider), typeof(SymbolProvider))]
    public class ExpressionProvider : MonoBehaviour
    {
        public readonly ReactiveProperty<string> Expression = new StringReactiveProperty("0");

        private string _constantCalculation = null;
        private readonly int _maxSymbol = 1;
        private readonly int _maxOperand = 3;

        private void Start()
        {
            var numericProvider = GetComponent<NumericProvider>();
            var symbolProvider = GetComponent<SymbolProvider>();
            var calculation = GetComponent<Calculation>();

            Expression
                .Select(x =>
                {
                    return x.ToString()
                        .Split(' ')
                        .Where(x => x != "")
                        .Where(x => IsNumeric(x))
                        .ToList();
                })
                .SelectMany(x => x)
                .Subscribe(x =>
                {
                    Debug.Log(x);
                    calculation.Display.Value = x;
                })
                .AddTo(this);
            
            numericProvider.Numeric
                .Skip(1)
                .Subscribe(x =>
                {
                    var lastSubstring = LastSubstring(Expression.Value);
                    if (!(IsNumeric(lastSubstring) || lastSubstring == "."))
                         Expression.Value += ' ';
                        
                    if (IsZeroString(Expression.Value) && x != ".")
                    {
                        Expression.Value = x;
                    }
                    else
                    {
                        Expression.Value += x;
                    }
                    Debug.Log(Expression.Value);
                    
                }).AddTo(this);
            
            symbolProvider.Symbol
                .Skip(1)
                .Subscribe(x =>
                {
                    if (x == "=")
                    {
                        if (_constantCalculation == null)
                        {
                            _constantCalculation = GetConstantCalculation(Expression.Value);
                        }
                        else
                        {
                            Expression.Value += " ";
                            Expression.Value += _constantCalculation;
                        }
                        
                        Expression.Value = RpnCalculator.Calculate(Expression.Value).ToString();
                        
                        Debug.Log(Expression.Value);
                        return;

                    }
                    else
                    {
                        _constantCalculation = null;
                    }
                    
                    if (IsMaxSymbol(Expression.Value) && OperandList().Count == _maxOperand)
                    {
                        Debug.Log(Expression.Value);
                        Expression.Value = RpnCalculator.Calculate(Expression.Value).ToString();
                    }
                    
                    Debug.Log(Expression.Value);
                    
                    var lastSubstring = LastSubstring(Expression.Value);
                    if (IsNumeric(lastSubstring))
                    {
                        Expression.Value += ' ';
                        Expression.Value += x;
                    }

                    Debug.Log(Expression.Value);
                }).AddTo(this);
        }

        public void Clear()
        {
            Expression.Value = "0";
        }

        public bool IsLastSymbol()
        {
            var s = LastSubstring(Expression.Value);
            return !IsNumeric(s);
        }
        
        public bool IsSingle()
        {
            return OperandList().Count == 1;
        }
        
        public List<string> OperandList()
        {
            return Expression.Value.ToString()
                .Split(' ')
                .Where(x => x != "")
                .ToList();
        }
        
        public string OperandString(List<string> l)
        {
            string result = "";
            l.ForEach(x =>
            {
                result += x + " ";
            });
            return result.Remove(result.Length - 1, 1);
        }

        private string GetConstantCalculation(string s)
        {
            var sequenceList = s.Split(' ')
                .Where(s => s != "")
                .ToList();
            
            sequenceList.RemoveAt(0);
            return sequenceList.Aggregate((x, y) => x + " " + y);
        }
        
        private string LastSubstring(string s) 
        {
            return s.Substring(s.Length - 1, 1);
        }
        
        private bool IsNumeric(string s) 
        {
            return int.TryParse(s, out _);
        }
        
        private bool IsZeroString(string s) 
        {
            return s.Length == 1 && s == "0";
        }

        private bool IsMaxSymbol(string s)
        {
            var count = 0;
            foreach (var c in s)
            {
                if (c == ' ') continue;
                if (!IsNumeric(c.ToString())) count++;
            }

            return count >= _maxSymbol;
        }
    }
}
    
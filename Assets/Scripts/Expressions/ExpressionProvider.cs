using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UniRx;
using Operators;
using Operands;
using Rpn;


namespace Expressions
{
    [RequireComponent(typeof(NumericProvider), typeof(SymbolProvider))]
    public class ExpressionProvider : MonoBehaviour
    {
        private readonly ReactiveProperty<string> _expression = new StringReactiveProperty("0");
        public IReadOnlyReactiveProperty<string> Expression => _expression;

        private string _constantCalculation = null;
        private readonly int _maxSymbol = 1;

        private void Start()
        {
            var numericProvider = GetComponent<NumericProvider>();
            var symbolProvider = GetComponent<SymbolProvider>();
            
            numericProvider.Numeric
                .Skip(1)
                .Subscribe(x =>
                {
                    var lastSubstring = LastSubstring(_expression.Value);
                    if (!IsNumeric(lastSubstring)) _expression.Value += ' ';
                        
                    if (IsZeroString(_expression.Value))
                    {
                        _expression.Value = x.ToString();
                    }
                    else
                    {
                        _expression.Value += x.ToString();
                    }
                    Debug.Log(_expression.Value);
                    
                }).AddTo(this);
            
            symbolProvider.Symbol
                .Skip(1)
                .Subscribe(x =>
                {
                    if (x == "=")
                    {
                        if (_constantCalculation == null)
                        {
                            _constantCalculation = GetConstantCalculation(_expression.Value);
                            _expression.Value = RpnCalculator.Calculate(_expression.Value).ToString();
                        }
                        else
                        {
                            _expression.Value += " ";
                            _expression.Value += _constantCalculation;
                            _expression.Value = RpnCalculator.Calculate(_expression.Value).ToString();
                        }
                        
                        Debug.Log(_expression.Value);
                        return;

                    }
                    else
                    {
                        _constantCalculation = null;
                    }
                    
                    if (IsMaxSymbol(_expression.Value))
                    {
                        _expression.Value = RpnCalculator.Calculate(_expression.Value).ToString();
                    }
                    
                    Debug.Log(_expression.Value);
                    
                    var lastSubstring = LastSubstring(_expression.Value);
                    if (IsNumeric(lastSubstring))
                    {
                        _expression.Value += ' ';
                        _expression.Value += x;
                    }

                    Debug.Log(_expression.Value);
                }).AddTo(this);
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
    
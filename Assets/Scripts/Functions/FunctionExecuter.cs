using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UniRx;
using Inputs;
using Inputs.InputImpls;
using Expressions;
using Data;

namespace Functions
{
    [RequireComponent(typeof(KeyInputEventProvider), typeof(ExpressionProvider))]
    public class FunctionExecuter : MonoBehaviour
    {
        private readonly ReactiveProperty<string> _function = new StringReactiveProperty(null);
        public IReadOnlyReactiveProperty<string> Function => _function;

        private void Start()
        {
            var input = GetComponent<IInputEventProvider>();
            var expressionProvider = GetComponent<ExpressionProvider>();
            var calculation = GetComponent<Calculation>();

            input.OnClearEntry
                .Where(x => x)
                .Subscribe(_ =>
                {
                    if (!expressionProvider.IsLastSymbol())
                    {
                        if (expressionProvider.IsSingle())
                        {
                            expressionProvider.Expression.Value = "0";
                        }
                        else
                        {
                            var l = expressionProvider.OperandList();
                            l.RemoveAt(l.Count - 1);
                            expressionProvider.Expression.Value = expressionProvider.OperandString(l);
                        }
                    }
                    else
                    {
                        expressionProvider.Clear();
                    }
                })
                .AddTo(this);
            
            input.OnDisable
                .Where(x => x)
                .Subscribe(_ =>
                {
                });
            
            input.OnMemoryRecall
                .Where(x => x)
                .Subscribe(_ =>
                {
                    if (expressionProvider.IsSingle())
                    {
                        expressionProvider.Expression.Value = calculation.Memory.Value;
                    }
                    else
                    {
                        if (expressionProvider.IsLastSymbol())
                        {
                            expressionProvider.Expression.Value += " ";
                            expressionProvider.Expression.Value += calculation.Memory.Value;
                        }
                        else
                        {
                            var l = expressionProvider.OperandList();
                            l[l.Count - 1] = calculation.Memory.Value;
                        }
                    }
                })
                .AddTo(this);
            
            input.OnMemoryPlus
                .Where(x => x)
                .Subscribe(_ =>
                {
                    if (expressionProvider.IsSingle())
                    {
                        calculation.Memory.Value = 
                            (double.Parse(calculation.Memory.Value) + double.Parse(expressionProvider.Expression.Value)).ToString();
                    }
                })
                .AddTo(this);
            
            input.OnMemoryMinus
                .Where(x => x)
                .Subscribe(_ =>
                {
                    if (expressionProvider.IsSingle())
                    {
                        calculation.Memory.Value = 
                            (double.Parse(calculation.Memory.Value) - double.Parse(expressionProvider.Expression.Value)).ToString();
                    }
                })
                .AddTo(this);
            
            input.OnSqrt
                .Where(x => x)
                .Subscribe(_ =>
                {
                    if (expressionProvider.IsSingle() && double.Parse(expressionProvider.Expression.Value) > 0)
                    {
                        expressionProvider.Expression.Value =
                            Math.Sqrt(double.Parse(expressionProvider.Expression.Value)).ToString();
                    }
                })
                .AddTo(this);
            
            input.OnPercentage
                .Where(x => x)
                .Subscribe(_ =>
                {
                    if (expressionProvider.IsSingle())
                    {
                        expressionProvider.Expression.Value = 
                            (double.Parse(expressionProvider.Expression.Value) / 100.0).ToString();
                    }
                })
                .AddTo(this);
        }
    }

}
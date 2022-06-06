using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Inputs;
using Inputs.InputImpls;
using Expressions;

namespace Functions
{
    [RequireComponent(typeof(KeyInputEventProvider), typeof(ExpressionProvider))]
    public class FunctionExecuter : MonoBehaviour
    {
        private void Start()
        {
            var input = GetComponent<IInputEventProvider>();
            var expressionProvider = GetComponent<ExpressionProvider>();

            input.OnClearEntry
                .Where(x => x)
                .Subscribe(_ =>
                {
                });
            
            input.OnDisable
                .Where(x => x)
                .Subscribe(_ =>
                {
                });
            
            input.OnMemoryRecall
                .Where(x => x)
                .Subscribe(_ =>
                {
                });
            
            input.OnMemoryPlus
                .Where(x => x)
                .Subscribe(_ =>
                {
                });
            
            input.OnMemoryMinus
                .Where(x => x)
                .Subscribe(_ =>
                {
                });
        }
        
    }

}
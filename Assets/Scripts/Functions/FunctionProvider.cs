using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Inputs;
using Inputs.InputImpls;

namespace Functions
{
    [RequireComponent(typeof(KeyInputEventProvider))]
    public class FunctionProvider : MonoBehaviour
    {
        private readonly ReactiveProperty<string> _function = new StringReactiveProperty(null);
        public IReadOnlyReactiveProperty<string> Function => _function;
        
        private void Start()
        {
            var input = GetComponent<IInputEventProvider>();

            input.OnClearEntry
                .Where(x => x)
                .Subscribe(_ =>
                {
                    _function.SetValueAndForceNotify("+");
                });
            
            input.OnDisable
                .Where(x => x)
                .Subscribe(_ =>
                {
                    _function.SetValueAndForceNotify("-");
                });
            
            input.OnMemoryRecall
                .Where(x => x)
                .Subscribe(_ =>
                {
                    _function.SetValueAndForceNotify("×");
                });
            
            input.OnMemoryPlus
                .Where(x => x)
                .Subscribe(_ =>
                {
                    _function.SetValueAndForceNotify("÷");
                });
            
            input.OnMemoryMinus
                .Where(x => x)
                .Subscribe(_ =>
                {
                    _function.SetValueAndForceNotify("=");
                });
        }
        
    }

}
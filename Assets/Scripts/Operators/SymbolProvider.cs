using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Inputs;
using Inputs.InputImpls;

namespace Operators
{
    [RequireComponent(typeof(KeyInputEventProvider))]
    public class SymbolProvider : MonoBehaviour
    {
        private readonly ReactiveProperty<string> _symbol = new StringReactiveProperty(null);
        public IReadOnlyReactiveProperty<string> Symbol => _symbol;
        
        private void Start()
        {
            var input = GetComponent<IInputEventProvider>();

            input.OnPlus
                .Where(x => x)
                .Subscribe(_ =>
                {
                    _symbol.SetValueAndForceNotify("+");
                });
            
            input.OnMinus
                .Where(x => x)
                .Subscribe(_ =>
                {
                    _symbol.SetValueAndForceNotify("-");
                });
            
            input.OnMultiplied
                .Where(x => x)
                .Subscribe(_ =>
                {
                    _symbol.SetValueAndForceNotify("×");
                });
            
            input.OnDivided
                .Where(x => x)
                .Subscribe(_ =>
                {
                    _symbol.SetValueAndForceNotify("÷");
                });
            
            input.OnEquals
                .Where(x => x)
                .Subscribe(_ =>
                {
                    _symbol.SetValueAndForceNotify("=");
                });
        }
        
    }

}
    
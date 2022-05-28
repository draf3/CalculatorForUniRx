using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Inputs;
using Operators;

public class OperatorProvider : MonoBehaviour
{
    private readonly ReactiveProperty<SymbolType> _symbol = new ReactiveProperty<SymbolType>(SymbolType.None);
    public IReadOnlyReactiveProperty<SymbolType> Symbol => _symbol;
    
    private void Start()
    {
        var input = GetComponent<IInputEventProvider>();

        input.OnPlus
            .Where(x => x)
            .Subscribe(_ =>
            {
                _symbol.Value = SymbolType.Plus;
            });
        
        input.OnMinus
            .Where(x => x)
            .Subscribe(_ =>
            {
                _symbol.Value = SymbolType.Minus;
            });
        
        input.OnMultiplied
            .Where(x => x)
            .Subscribe(_ =>
            {
                _symbol.Value = SymbolType.Multiplied;
            });
        
        input.OnDivided
            .Where(x => x)
            .Subscribe(_ =>
            {
                _symbol.Value = SymbolType.Divided;
            });
    }
    
}

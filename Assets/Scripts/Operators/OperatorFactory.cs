using System.Collections;
using System.Collections.Generic;
using Operators;
using UnityEngine;

public class OperatorFactory : MonoBehaviour
{
    public IOperator Create(SymbolType type)
    {
        switch (type)
        {
            case SymbolType.Plus:
                return new Plus();
            
            case SymbolType.Minus:
                return new Minus();
            
            case SymbolType.Multiplied:
                return new Multiplied();
            
            case SymbolType.Divided:
                return new Divided();
            
            default:
                return null;
        }
    }
}

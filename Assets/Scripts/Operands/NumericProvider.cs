using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Inputs;

namespace Operands
{
    public class NumericProvider : MonoBehaviour
    {
        private readonly ReactiveProperty<int> _numeric = new IntReactiveProperty(-1);
        public IReadOnlyReactiveProperty<int> Numeric => _numeric;
        
        private void Start()
        {
            var input = GetComponent<IInputEventProvider>();

            input.OnZero
                .Where(x => x)
                .Subscribe(_ =>
                {
                    _numeric.SetValueAndForceNotify((int)NumericType.Zero);
                }).AddTo(this);
            
            input.OnOne
                .Where(x => x)
                .Subscribe(_ =>
                {
                    _numeric.SetValueAndForceNotify((int)NumericType.One);
                }).AddTo(this);
            
            input.OnTwo
                .Where(x => x)
                .Subscribe(_ =>
                {
                    _numeric.SetValueAndForceNotify((int)NumericType.Two);
                }).AddTo(this);
            
            input.OnThree
                .Where(x => x)
                .Subscribe(_ =>
                {
                    _numeric.SetValueAndForceNotify((int)NumericType.Three);
                }).AddTo(this);
            
            input.OnFour
                .Where(x => x)
                .Subscribe(_ =>
                {
                    _numeric.SetValueAndForceNotify((int)NumericType.Four);
                }).AddTo(this);
            
            input.OnFive
                .Where(x => x)
                .Subscribe(_ =>
                {
                    _numeric.SetValueAndForceNotify((int)NumericType.Five);
                }).AddTo(this);
            
            input.OnSix
                .Where(x => x)
                .Subscribe(_ =>
                {
                    _numeric.SetValueAndForceNotify((int)NumericType.Six);
                }).AddTo(this);
            
            input.OnSeven
                .Where(x => x)
                .Subscribe(_ =>
                {
                    _numeric.SetValueAndForceNotify((int)NumericType.Seven);
                }).AddTo(this);
            
            input.OnEight
                .Where(x => x)
                .Subscribe(_ =>
                {
                    _numeric.SetValueAndForceNotify((int)NumericType.Eight);
                }).AddTo(this);
            
            input.OnNine
                .Where(x => x)
                .Subscribe(_ =>
                {
                    _numeric.SetValueAndForceNotify((int)NumericType.Nine);
                }).AddTo(this);
        }
        
    }

}
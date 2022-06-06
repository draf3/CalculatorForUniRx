using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Inputs;

namespace Operands
{
    public class NumericProvider : MonoBehaviour
    {
        private readonly ReactiveProperty<string> _numeric = new StringReactiveProperty(((int)NumericType.None).ToString());
        public IReadOnlyReactiveProperty<string> Numeric => _numeric;
        
        private void Start()
        {
            var input = GetComponent<IInputEventProvider>();

            input.OnZero
                .Where(x => x)
                .Subscribe(_ =>
                {
                    _numeric.SetValueAndForceNotify(((int)NumericType.Zero).ToString());
                }).AddTo(this);
            
            input.OnOne
                .Where(x => x)
                .Subscribe(_ =>
                {
                    _numeric.SetValueAndForceNotify(((int)NumericType.One).ToString());
                }).AddTo(this);
            
            input.OnTwo
                .Where(x => x)
                .Subscribe(_ =>
                {
                    _numeric.SetValueAndForceNotify(((int)NumericType.Two).ToString());
                }).AddTo(this);
            
            input.OnThree
                .Where(x => x)
                .Subscribe(_ =>
                {
                    _numeric.SetValueAndForceNotify(((int)NumericType.Three).ToString());
                }).AddTo(this);
            
            input.OnFour
                .Where(x => x)
                .Subscribe(_ =>
                {
                    _numeric.SetValueAndForceNotify(((int)NumericType.Four).ToString());
                }).AddTo(this);
            
            input.OnFive
                .Where(x => x)
                .Subscribe(_ =>
                {
                    _numeric.SetValueAndForceNotify(((int)NumericType.Five).ToString());
                }).AddTo(this);
            
            input.OnSix
                .Where(x => x)
                .Subscribe(_ =>
                {
                    _numeric.SetValueAndForceNotify(((int)NumericType.Six).ToString());
                }).AddTo(this);
            
            input.OnSeven
                .Where(x => x)
                .Subscribe(_ =>
                {
                    _numeric.SetValueAndForceNotify(((int)NumericType.Seven).ToString());
                }).AddTo(this);
            
            input.OnEight
                .Where(x => x)
                .Subscribe(_ =>
                {
                    _numeric.SetValueAndForceNotify(((int)NumericType.Eight).ToString());
                }).AddTo(this);
            
            input.OnNine
                .Where(x => x)
                .Subscribe(_ =>
                {
                    _numeric.SetValueAndForceNotify(((int)NumericType.Nine).ToString());
                }).AddTo(this);
            
            input.OnDecimal
                .Where(x => x)
                .Subscribe(_ =>
                {
                    _numeric.SetValueAndForceNotify(".");
                }).AddTo(this);
        }
        
    }

}
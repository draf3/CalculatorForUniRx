using System;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

namespace Inputs.InputImpls
{
    public class KeyInputEventProvider : MonoBehaviour, IInputEventProvider
    {
        private readonly ReactiveProperty<bool> _onPlus = new BoolReactiveProperty();
        private readonly ReactiveProperty<bool> _onMinus = new BoolReactiveProperty();
        private readonly ReactiveProperty<bool> _onMultiplied = new BoolReactiveProperty();
        private readonly ReactiveProperty<bool> _onDivided = new BoolReactiveProperty();
        private readonly ReactiveProperty<bool> _onEquals = new BoolReactiveProperty();
        
        private readonly ReactiveProperty<bool> _onClearEntry = new BoolReactiveProperty();
        private readonly ReactiveProperty<bool> _onDisable = new BoolReactiveProperty();
        private readonly ReactiveProperty<bool> _onMemoryRecall = new BoolReactiveProperty();
        private readonly ReactiveProperty<bool> _onMemoryPlus = new BoolReactiveProperty();
        private readonly ReactiveProperty<bool> _onMemoryMinus = new BoolReactiveProperty();
        private readonly ReactiveProperty<bool> _onSqrt = new BoolReactiveProperty();
        private readonly ReactiveProperty<bool> _onPercentage = new BoolReactiveProperty();
        
        private readonly ReactiveProperty<bool> _onZero = new BoolReactiveProperty();
        private readonly ReactiveProperty<bool> _onOne = new BoolReactiveProperty();
        private readonly ReactiveProperty<bool> _onTwo = new BoolReactiveProperty();
        private readonly ReactiveProperty<bool> _onThree = new BoolReactiveProperty();
        private readonly ReactiveProperty<bool> _onFour = new BoolReactiveProperty();
        private readonly ReactiveProperty<bool> _onFive = new BoolReactiveProperty();
        private readonly ReactiveProperty<bool> _onSix = new BoolReactiveProperty();
        private readonly ReactiveProperty<bool> _onSeven = new BoolReactiveProperty();
        private readonly ReactiveProperty<bool> _onEight = new BoolReactiveProperty();
        private readonly ReactiveProperty<bool> _onNine = new BoolReactiveProperty();
        private readonly ReactiveProperty<bool> _onDecimal = new BoolReactiveProperty();

        public IReadOnlyReactiveProperty<bool> OnPlus => _onPlus;
        public IReadOnlyReactiveProperty<bool> OnMinus => _onMinus;
        public IReadOnlyReactiveProperty<bool> OnMultiplied => _onMultiplied;
        public IReadOnlyReactiveProperty<bool> OnDivided => _onDivided;
        public IReadOnlyReactiveProperty<bool> OnEquals => _onEquals;
        
        public IReadOnlyReactiveProperty<bool> OnClearEntry => _onClearEntry;
        public IReadOnlyReactiveProperty<bool> OnDisable => _onDisable;
        public IReadOnlyReactiveProperty<bool> OnMemoryRecall => _onMemoryRecall;
        public IReadOnlyReactiveProperty<bool> OnMemoryPlus => _onMemoryPlus;
        public IReadOnlyReactiveProperty<bool> OnMemoryMinus => _onMemoryMinus;
        public IReadOnlyReactiveProperty<bool> OnSqrt => _onSqrt;
        public IReadOnlyReactiveProperty<bool> OnPercentage => _onPercentage;
        
        public IReadOnlyReactiveProperty<bool> OnZero => _onZero;
        public IReadOnlyReactiveProperty<bool> OnOne => _onOne;
        public IReadOnlyReactiveProperty<bool> OnTwo => _onTwo;
        public IReadOnlyReactiveProperty<bool> OnThree => _onThree;
        public IReadOnlyReactiveProperty<bool> OnFour => _onFour;
        public IReadOnlyReactiveProperty<bool> OnFive => _onFive;
        public IReadOnlyReactiveProperty<bool> OnSix => _onSix;
        public IReadOnlyReactiveProperty<bool> OnSeven => _onSeven;
        public IReadOnlyReactiveProperty<bool> OnEight => _onEight;
        public IReadOnlyReactiveProperty<bool> OnNine => _onNine;
        public IReadOnlyReactiveProperty<bool> OnDecimal => _onDecimal;

        private void Start()
        {
            this.UpdateAsObservable()
                .Select(_ => Input.GetKey(KeyCode.Semicolon))
                .DistinctUntilChanged()
                .Subscribe(x =>
                {
                    _onPlus.Value = x;
                }).AddTo(this);
            
            this.UpdateAsObservable()
                .Select(_ => Input.GetKey(KeyCode.Minus))
                .DistinctUntilChanged()
                .Subscribe(x =>
                {
                    _onMinus.Value = x;
                }).AddTo(this);
            
            this.UpdateAsObservable()
                .Select(_ => Input.GetKey(KeyCode.Colon))
                .DistinctUntilChanged()
                .Subscribe(x =>
                {
                    _onMultiplied.Value = x;
                }).AddTo(this);
            
            this.UpdateAsObservable()
                .Select(_ => Input.GetKey(KeyCode.Slash))
                .DistinctUntilChanged()
                .Subscribe(x =>
                {
                    _onDivided.Value = x;
                }).AddTo(this);
            
            this.UpdateAsObservable()
                .Select(_ => Input.GetKey(KeyCode.Return))
                .DistinctUntilChanged()
                .Subscribe(x =>
                {
                    _onEquals.Value = x;
                }).AddTo(this);
            
            this.UpdateAsObservable()
                .Select(_ => Input.GetKey(KeyCode.Alpha0))
                .DistinctUntilChanged()
                .Subscribe(x =>
                {
                    _onZero.Value = x;
                }).AddTo(this);
            
            this.UpdateAsObservable()
                .Select(_ => Input.GetKey(KeyCode.Alpha1))
                .DistinctUntilChanged()
                .Subscribe(x =>
                {
                    _onOne.Value = x;
                }).AddTo(this);
            
            this.UpdateAsObservable()
                .Select(_ => Input.GetKey(KeyCode.Alpha2))
                .DistinctUntilChanged()
                .Subscribe(x =>
                {
                    _onTwo.Value = x;
                }).AddTo(this);
            
            this.UpdateAsObservable()
                .Select(_ => Input.GetKey(KeyCode.Alpha3))
                .DistinctUntilChanged()
                .Subscribe(x =>
                {
                    _onThree.Value = x;
                }).AddTo(this);
            
            this.UpdateAsObservable()
                .Select(_ => Input.GetKey(KeyCode.Alpha4))
                .DistinctUntilChanged()
                .Subscribe(x =>
                {
                    _onFour.Value = x;
                }).AddTo(this);
            
            this.UpdateAsObservable()
                .Select(_ => Input.GetKey(KeyCode.Alpha5))
                .DistinctUntilChanged()
                .Subscribe(x =>
                {
                    _onFive.Value = x;
                }).AddTo(this);
            
            this.UpdateAsObservable()
                .Select(_ => Input.GetKey(KeyCode.Alpha6))
                .DistinctUntilChanged()
                .Subscribe(x =>
                {
                    _onSix.Value = x;
                }).AddTo(this);
            
            this.UpdateAsObservable()
                .Select(_ => Input.GetKey(KeyCode.Alpha7))
                .DistinctUntilChanged()
                .Subscribe(x =>
                {
                    _onSeven.Value = x;
                }).AddTo(this);
            
            this.UpdateAsObservable()
                .Select(_ => Input.GetKey(KeyCode.Alpha8))
                .DistinctUntilChanged()
                .Subscribe(x =>
                {
                    _onEight.Value = x;
                }).AddTo(this);
            
            this.UpdateAsObservable()
                .Select(_ => Input.GetKey(KeyCode.Alpha9))
                .DistinctUntilChanged()
                .Subscribe(x =>
                {
                    _onNine.Value = x;
                }).AddTo(this);
            
            this.UpdateAsObservable()
                .Select(_ => Input.GetKey(KeyCode.Period))
                .DistinctUntilChanged()
                .Subscribe(x =>
                {
                    _onDecimal.Value = x;
                }).AddTo(this);
            
            this.UpdateAsObservable()
                .Select(_ => Input.GetKey(KeyCode.C))
                .DistinctUntilChanged()
                .Subscribe(x =>
                {
                    _onClearEntry.Value = x;
                }).AddTo(this);
            
            this.UpdateAsObservable()
                .Select(_ => Input.GetKey(KeyCode.O))
                .DistinctUntilChanged()
                .Subscribe(x =>
                {
                    _onDisable.Value = x;
                }).AddTo(this);
            
            this.UpdateAsObservable()
                .Select(_ => Input.GetKey(KeyCode.R))
                .DistinctUntilChanged()
                .Subscribe(x =>
                {
                    _onMemoryRecall.Value = x;
                }).AddTo(this);
            
            this.UpdateAsObservable()
                .Select(_ => Input.GetKey(KeyCode.N))
                .DistinctUntilChanged()
                .Subscribe(x =>
                {
                    _onMemoryPlus.Value = x;
                }).AddTo(this);
            
            this.UpdateAsObservable()
                .Select(_ => Input.GetKey(KeyCode.M))
                .DistinctUntilChanged()
                .Subscribe(x =>
                {
                    _onMemoryMinus.Value = x;
                }).AddTo(this);
            
            this.UpdateAsObservable()
                .Select(_ => Input.GetKey(KeyCode.S))
                .DistinctUntilChanged()
                .Subscribe(x =>
                {
                    _onSqrt.Value = x;
                }).AddTo(this);
            
            this.UpdateAsObservable()
                .Select(_ => Input.GetKey(KeyCode.P))
                .DistinctUntilChanged()
                .Subscribe(x =>
                {
                    _onPercentage.Value = x;
                }).AddTo(this);

        }
        // private void Update () {
        //     if (Input.anyKeyDown) {
        //         foreach (KeyCode code in Enum.GetValues(typeof(KeyCode))) {
        //             if (Input.GetKeyDown (code)) {
        //                 Debug.Log(code);
        //                 break;
        //             }
        //         }
        //     }
        // }
    }
}
    

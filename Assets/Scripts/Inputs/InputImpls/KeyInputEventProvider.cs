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
        
        public IReadOnlyReactiveProperty<bool> OnPlus => _onPlus;
        public IReadOnlyReactiveProperty<bool> OnMinus => _onMinus;
        public IReadOnlyReactiveProperty<bool> OnMultiplied => _onMultiplied;
        public IReadOnlyReactiveProperty<bool> OnDivided => _onDivided;
        public IReadOnlyReactiveProperty<bool> OnEquals => _onEquals;
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

        private void Start()
        {
            this.UpdateAsObservable()
                .Select(_ => Input.GetKey(KeyCode.Plus))
                .DistinctUntilChanged()
                .Subscribe(x =>
                {
                    _onPlus.Value = x;
                });
            
            this.UpdateAsObservable()
                .Select(_ => Input.GetKey(KeyCode.Minus))
                .DistinctUntilChanged()
                .Subscribe(x =>
                {
                    _onMinus.Value = x;
                });
            
            this.UpdateAsObservable()
                .Select(_ => Input.GetKey(KeyCode.Asterisk))
                .DistinctUntilChanged()
                .Subscribe(x =>
                {
                    _onMultiplied.Value = x;
                });
            
            this.UpdateAsObservable()
                .Select(_ => Input.GetKey(KeyCode.Slash))
                .DistinctUntilChanged()
                .Subscribe(x =>
                {
                    _onDivided.Value = x;
                });
            
            this.UpdateAsObservable()
                .Select(_ => Input.GetKey(KeyCode.Equals))
                .DistinctUntilChanged()
                .Subscribe(x =>
                {
                    _onEquals.Value = x;
                });
            
            this.UpdateAsObservable()
                .Select(_ => Input.GetKey(KeyCode.Alpha0))
                .DistinctUntilChanged()
                .Subscribe(x =>
                {
                    _onZero.Value = x;
                });
            
            this.UpdateAsObservable()
                .Select(_ => Input.GetKey(KeyCode.Alpha1))
                .DistinctUntilChanged()
                .Subscribe(x =>
                {
                    _onOne.Value = x;
                });
            
            this.UpdateAsObservable()
                .Select(_ => Input.GetKey(KeyCode.Alpha2))
                .DistinctUntilChanged()
                .Subscribe(x =>
                {
                    _onTwo.Value = x;
                });
            
            this.UpdateAsObservable()
                .Select(_ => Input.GetKey(KeyCode.Alpha3))
                .DistinctUntilChanged()
                .Subscribe(x =>
                {
                    _onThree.Value = x;
                });
            
            this.UpdateAsObservable()
                .Select(_ => Input.GetKey(KeyCode.Alpha4))
                .DistinctUntilChanged()
                .Subscribe(x =>
                {
                    _onFour.Value = x;
                });
            
            this.UpdateAsObservable()
                .Select(_ => Input.GetKey(KeyCode.Alpha5))
                .DistinctUntilChanged()
                .Subscribe(x =>
                {
                    _onFive.Value = x;
                });
            
            this.UpdateAsObservable()
                .Select(_ => Input.GetKey(KeyCode.Alpha6))
                .DistinctUntilChanged()
                .Subscribe(x =>
                {
                    _onSix.Value = x;
                });
            
            this.UpdateAsObservable()
                .Select(_ => Input.GetKey(KeyCode.Alpha7))
                .DistinctUntilChanged()
                .Subscribe(x =>
                {
                    _onSeven.Value = x;
                });
            
            this.UpdateAsObservable()
                .Select(_ => Input.GetKey(KeyCode.Alpha8))
                .DistinctUntilChanged()
                .Subscribe(x =>
                {
                    _onEight.Value = x;
                });
            
            this.UpdateAsObservable()
                .Select(_ => Input.GetKey(KeyCode.Alpha9))
                .DistinctUntilChanged()
                .Subscribe(x =>
                {
                    _onNine.Value = x;
                });

        }
    }
}
    

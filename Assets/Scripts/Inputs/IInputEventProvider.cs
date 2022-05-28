using UniRx;

namespace Inputs
{
    public interface IInputEventProvider
    {
        IReadOnlyReactiveProperty<bool> OnPlus { get; }
        IReadOnlyReactiveProperty<bool> OnMinus { get; }
        IReadOnlyReactiveProperty<bool> OnMultiplied { get; }
        IReadOnlyReactiveProperty<bool> OnDivided { get; }
        IReadOnlyReactiveProperty<bool> OnEquals { get; }
        IReadOnlyReactiveProperty<bool> OnZero { get; }
        IReadOnlyReactiveProperty<bool> OnOne { get; }
        IReadOnlyReactiveProperty<bool> OnTwo { get; }
        IReadOnlyReactiveProperty<bool> OnThree { get; }
        IReadOnlyReactiveProperty<bool> OnFour { get; }
        IReadOnlyReactiveProperty<bool> OnFive { get; }
        IReadOnlyReactiveProperty<bool> OnSix { get; }
        IReadOnlyReactiveProperty<bool> OnSeven { get; }
        IReadOnlyReactiveProperty<bool> OnEight { get; }
        IReadOnlyReactiveProperty<bool> OnNine { get; }
    }
}
    

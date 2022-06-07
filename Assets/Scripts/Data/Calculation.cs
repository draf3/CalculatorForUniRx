using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace Data
{
    public class Calculation : MonoBehaviour
    {
        public readonly ReactiveProperty<string> Display = new StringReactiveProperty(null);
        public readonly ReactiveProperty<string> Memory = new StringReactiveProperty("0");
    }
}

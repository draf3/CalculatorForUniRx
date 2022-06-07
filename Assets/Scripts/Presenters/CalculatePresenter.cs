using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Expressions;
using Functions;
using Data;

namespace Presenters
{
    public class CalculatePresenter : MonoBehaviour
    {
        [SerializeField] private Text _screenText;
        [SerializeField] private Calculation _calculation;

        void Start()
        {
            _calculation.Display
                .Subscribe(x =>
                {
                    _screenText.text = x;
                });
        }
    }
}
    
    

using System;
using Laphed.MVP;
using TMPro;
using UnityEngine;

namespace Laphed.PinkBunny.UI
{
    public class BatteriesView: MonoBehaviour, IView<int>
    {
        [SerializeField] private TMP_Text counterText;
        
        public event Action OnDispose;
        
        public void UpdateView(int value)
        {
            counterText.text = value.ToString();
        }

        private void OnDestroy()
        {
            OnDispose?.Invoke();
        }
    }
}
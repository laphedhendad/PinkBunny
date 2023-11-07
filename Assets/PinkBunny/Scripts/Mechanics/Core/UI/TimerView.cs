using System;
using Laphed.MVP;
using TMPro;
using UnityEngine;

namespace Laphed.PinkBunny.UI
{
    public class TimerView: MonoBehaviour, IView<string>
    {
        [SerializeField] private TMP_Text timerText;
        public event Action OnDispose;

        public void UpdateView(string value)
        {
            timerText.text = value;
        }

        private void OnDestroy()
        {
            OnDispose?.Invoke();
        }
    }
}
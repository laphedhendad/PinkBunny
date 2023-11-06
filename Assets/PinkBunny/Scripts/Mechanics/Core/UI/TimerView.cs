using TMPro;
using UnityEngine;

namespace Laphed.PinkBunny.UI
{
    public class TimerView: MonoBehaviour, IView<string>
    {
        [SerializeField] private TMP_Text timerText;

        public void UpdateView(string value)
        {
            timerText.text = value;
        }
    }
}
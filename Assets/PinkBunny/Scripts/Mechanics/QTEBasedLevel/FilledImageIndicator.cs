using UnityEngine;
using UnityEngine.UI;

namespace Laphed.Mechanics.QTEBasedLevel
{
    public class FilledImageIndicator: MonoBehaviour, IQuickTimeEventIndicator
    {
        [SerializeField] private Image image;
        [SerializeField] private Color startColor;
        [SerializeField] private Color endColor;

        public void UpdateView(float normalizedTimerValue)
        {
            image.fillAmount = normalizedTimerValue;
            image.color = GetColorByTime(normalizedTimerValue);
        }

        private Color GetColorByTime(float timerValue)
        {
            return Color.Lerp(startColor, endColor, timerValue);
        }
    }
}
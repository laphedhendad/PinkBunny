using UnityEngine;
using UnityEngine.UI;

namespace Laphed.PinkBunny.UI
{
    public class FilledImageIndicator: MonoBehaviour, IView<float>
    {
        [SerializeField] private Image image;
        [SerializeField] private Color startColor;
        [SerializeField] private Color endColor;

        private Color GetColorByValue(float value)
        {
            return Color.Lerp(endColor, startColor, value);
        }

        public void UpdateView(float value)
        {
            image.fillAmount = value;
            image.color = GetColorByValue(value);
        }
    }
}
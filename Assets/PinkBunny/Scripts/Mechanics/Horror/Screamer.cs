using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Laphed.Horror
{
    public class Screamer: MonoBehaviour, IScreamer
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private AudioSource audioSource;
        
        public UniTask Show()
        {
            audioSource.Play();
            return transform.DOScale(1f, 0.5f).ToUniTask();
        }
    }
}
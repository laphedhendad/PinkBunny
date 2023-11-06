using Cysharp.Threading.Tasks;
using DG.Tweening;
using Laphed.DataStructures;
using UnityEngine;
using Zenject;

namespace Laphed.PinkBunny.UI
{
    public class UIModeSwitch: MonoBehaviour, IUIModeSwitch
    {
        [SerializeField] private Transform menuUiCameraPosition;
        [SerializeField] private Transform gameUiCameraPosition;
        [SerializeField] private float animationDuration;
        
        private Camera mainCamera;
        private readonly CircularList<Transform> modesCircularList = new();

        [Inject]
        private void Construct()
        {
            mainCamera = Camera.main;
            InitializeModesList();
        }

        public UniTask Switch()
        {
            Transform targetPosition = modesCircularList.Next();
            UniTask moveTask = mainCamera.transform.DOMove(targetPosition.position, animationDuration).ToUniTask();
            UniTask rotateTask = mainCamera.transform.DORotate(targetPosition.rotation.eulerAngles, animationDuration).ToUniTask();
            return UniTask.WhenAll(moveTask, rotateTask);
        }

        private void InitializeModesList()
        {
            modesCircularList.Add(menuUiCameraPosition);
            modesCircularList.Add(gameUiCameraPosition);
        }
    }
}
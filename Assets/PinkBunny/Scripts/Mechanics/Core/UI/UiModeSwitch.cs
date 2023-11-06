using Cysharp.Threading.Tasks;
using DG.Tweening;
using Laphed.DataStructures;
using UnityEngine;

namespace Laphed.PinkBunny.UI
{
    public class UiModeSwitch: MonoBehaviour, IUiModeSwitch
    {
        [SerializeField] private Transform menuUiCameraPosition;
        [SerializeField] private Transform gameUiCameraPosition;
        [SerializeField] private float animationDuration;
        [SerializeField] private Canvas menuCanvas;
        [SerializeField] private Canvas gameCanvas;
        
        private Camera mainCamera;
        private readonly CircularList<ModeData> modesCircularList = new();
        
        private void Awake()
        {
            mainCamera = Camera.main;
            InitializeModesList();
        }

        public async UniTask Switch()
        {
            modesCircularList.Current.DeactivateCanvas();
            Transform targetPosition = modesCircularList.Next().cameraPosition;
            UniTask moveTask = mainCamera.transform.DOMove(targetPosition.position, animationDuration).ToUniTask();
            UniTask rotateTask = mainCamera.transform.DORotate(targetPosition.rotation.eulerAngles, animationDuration).ToUniTask();
            await UniTask.WhenAll(moveTask, rotateTask);
            modesCircularList.Current.ActivateCanvas();
        }

        private void InitializeModesList()
        {
            modesCircularList.Add(new ModeData(menuUiCameraPosition, menuCanvas));
            modesCircularList.Add(new ModeData(gameUiCameraPosition, gameCanvas));
        }

        private record ModeData
        {
            public readonly Transform cameraPosition;
            private readonly Canvas activeCanvas;

            public ModeData(Transform cameraPosition, Canvas activeCanvas)
            {
                this.cameraPosition = cameraPosition;
                this.activeCanvas = activeCanvas;
            }

            public void ActivateCanvas()
            {
                activeCanvas.gameObject.SetActive(true);
            }
            
            public void DeactivateCanvas()
            {
                activeCanvas.gameObject.SetActive(false);
            }
        }
    }
}
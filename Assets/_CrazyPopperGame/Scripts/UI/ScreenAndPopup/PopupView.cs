using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
namespace CrazyPopper.UI
{
    public abstract class PopupView : BaseView
    {
        public override ViewType ViewType => ViewType.Popup;

        CanvasGroup canvasGroup;

        protected override void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        protected override void PlayEnterAnimation()
        {
            transform.localScale = Vector3.zero;
            canvasGroup.alpha = 0;

            transform.DOScale(Vector3.one, 0.25f).SetEase(Ease.OutBack);
            canvasGroup.DOFade(1, 0.25f).OnComplete(() => { });
        }

        protected override void PlayExitAnimation(System.Action onComplete)
        {
            transform.DOScale(Vector3.zero, 0.2f).SetEase(Ease.InBack)
                .OnComplete(() => onComplete?.Invoke());
            canvasGroup.DOFade(0, 0.2f).OnComplete(() => onComplete?.Invoke());
        }
    }
}

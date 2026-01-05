using UnityEngine;
using DG.Tweening;
namespace CrazyPopper.UI
{
    public abstract class ScreenView : BaseView
    {
        public override ViewType ViewType => ViewType.Screen;

        protected override void PlayEnterAnimation()
        {
            RectTransform rt = GetComponent<RectTransform>();
            rt.anchoredPosition = new Vector2(Screen.width, 0);

            rt.DOAnchorPos(Vector2.zero, 0.3f).SetEase(Ease.OutCubic);
        }

        protected override void PlayExitAnimation(System.Action onComplete)
        {
            RectTransform rt = GetComponent<RectTransform>();

            rt.DOAnchorPos(new Vector2(-Screen.width, 0), 0.25f)
                .OnComplete(() => onComplete?.Invoke());
        }
    }
}

using UnityEngine;

namespace CrazyPopper.UI
{
    public abstract class BaseView : MonoBehaviour
    {
        public abstract ViewType ViewType { get; }

        public virtual bool CanHandleBack =>
            this is IBackKeyHandler;

        protected virtual void Awake()
        {
            //gameObject.SetActive(false);
        }

        public void Show()
        {
            Debug.Log($"Showing {this.GetType().Name}");
            gameObject.SetActive(true);
            OnShow();
            PlayEnterAnimation();
        }

        public void Hide()
        {
            PlayExitAnimation(() =>
            {
                OnHide();
                gameObject.SetActive(false);
            });
        }

        protected abstract void OnShow();
        protected abstract void OnHide();

        protected abstract void PlayEnterAnimation();
        protected abstract void PlayExitAnimation(System.Action onComplete);
    }

    public enum ViewType
    {
        Screen,
        Popup
    }
}

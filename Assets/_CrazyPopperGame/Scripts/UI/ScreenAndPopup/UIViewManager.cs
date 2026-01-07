using UnityEngine;
using System;
using System.Collections.Generic;
namespace CrazyPopper.UI
{
    using UnityEngine;
    using System.Collections.Generic;

    public class UIViewManager : MonoBehaviour
    {
        public static UIViewManager Instance;
        [SerializeField] private List<BaseView> allViews;
        private Dictionary<Type, BaseView> viewMap = new();
        private Stack<ScreenView> screenStack = new();
        private Stack<PopupView> popupStack = new();

        void Awake()
        {
            Instance = this;

            foreach (var view in allViews)
            {
                viewMap[view.GetType()] = view;
            }

            this.Show<ScreenMainMenu>();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                HandleBack();
        }

        // public void Show(BaseView view)
        // {
        //     if (view.ViewType == ViewType.Popup)
        //     {
        //         ShowPopup((PopupView)view);
        //         return;
        //     }

        //     ShowScreen((ScreenView)view);
        // }


        public void Show<T>() where T : BaseView
        {
            if (!viewMap.TryGetValue(typeof(T), out BaseView view))
            {
                Debug.LogError($"View not registered: {typeof(T)}");
                return;
            }

            Show(view);
        }

        public void Hide<T>() where T : BaseView
        {
            if (!viewMap.TryGetValue(typeof(T), out BaseView view))
            {
                Debug.LogError($"View not registered: {typeof(T)}");
                return;
            }

            Hide(view);
        }

        private void Hide(BaseView view)
        {
            if (view.ViewType == ViewType.Popup)
            {
                HidePopup((PopupView)view);
            }
            else
            {
                HideScreen((ScreenView)view);
            }
        }

        private void HidePopup(PopupView popup)
        {
            // Only top popup can be hidden
            if (popupStack.Count == 0 || popupStack.Peek() != popup)
            {
                Debug.LogWarning("Trying to hide a popup that is not on top of stack");
                return;
            }

            popupStack.Pop();
            popup.Hide();
        }

        private void HideScreen(ScreenView screen)
        {
            // Only top screen can be hidden
            if (screenStack.Count == 0 || screenStack.Peek() != screen)
            {
                Debug.LogWarning("Trying to hide a screen that is not active");
                return;
            }

            screenStack.Pop();
            screen.Hide();

            if (screenStack.Count > 0)
                screenStack.Peek().Show();
        }

        private void Show(BaseView view)
        {
            if (view.ViewType == ViewType.Popup)
            {
                ShowPopup((PopupView)view);
            }
            else
            {
                ShowScreen((ScreenView)view);
            }
        }

        private void ShowScreen(ScreenView screen)
        {
            if (screenStack.Count > 0)
                screenStack.Peek().Hide();

            screenStack.Push(screen);
            screen.Show();
        }

        private void ShowPopup(PopupView popup, bool hideCurrent = true)
        {
            //hide current popup if any
            if (popupStack.Count > 0 && hideCurrent)
            {
                PopupView topPopup = popupStack.Peek();
                topPopup.Hide();
            }
            popupStack.Push(popup);
            popup.Show();
        }

        public void HandleBack()
        {
            // 1 Topmost popup handles back
            if (popupStack.Count > 0)
            {
                PopupView topPopup = popupStack.Peek();

                if (topPopup is IBackKeyHandler handler &&
                    handler.OnBackPressed())
                    return;

                popupStack.Pop();
                topPopup.Hide();
                return;
            }

            // 2 Current screen handles back
            ScreenView current = screenStack.Peek();
            if (current is IBackKeyHandler screenHandler &&
                screenHandler.OnBackPressed())
                return;

            // 3 Screen stack pop
            if (screenStack.Count > 1)
            {
                ScreenView top = screenStack.Pop();
                top.Hide();
                screenStack.Peek().Show();
            }
            else
            {
                Application.Quit();
            }
        }
    }

}

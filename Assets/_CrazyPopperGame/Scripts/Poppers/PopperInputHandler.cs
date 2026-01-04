using CrazyPopper.Events;
using UnityEngine;

namespace CrazyPopper.Poppers
{
    public class PopperInputHandler : MonoBehaviour
    {
        private PopperEntity entity;

        private void Awake()
        {
            entity = GetComponent<PopperEntity>();
        }

        private void OnMouseDown()
        {
            // if (TurnManager.Instance.UseTap())
            entity.ReactToInput();
            EventBus.RaiseTapPopper();
        }
    }
}

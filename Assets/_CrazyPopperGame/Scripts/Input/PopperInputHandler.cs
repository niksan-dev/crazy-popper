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
            if (ReactionTracker.Instance.activeReactions > 0)
                return;
            entity.ReactToInput();
            TurnManager.Instance.ConsumeMove();
        }
    }
}

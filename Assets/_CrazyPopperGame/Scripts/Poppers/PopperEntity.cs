
using CrazyPopper.Events;
using UnityEngine;

namespace CrazyPopper.Poppers
{
    public class PopperEntity : MonoBehaviour
    {
        public PopperState State => state;

        private PopperState state;

        public void Init(PopperState start)
        {
            state = start;

            EventBus.RegisterPopper();
        }

        public void React()
        {

        }

        private void OnDestroy()
        {

        }
    }
}

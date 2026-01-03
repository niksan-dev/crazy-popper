using CrazyPopper.Events;
using UnityEngine;

namespace CrazyPopper.Poppers
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class PopperView : MonoBehaviour
    {
        [SerializeField] private PopperConfig config;

        private SpriteRenderer sr;

        private void Awake()
        {
            sr = GetComponent<SpriteRenderer>();
            AttachEyes();
        }

        void OnEnable()
        {
            EventBus.OnPopperStateChanged += OnStateChanged;
        }

        void OnDisable()
        {
            EventBus.OnPopperStateChanged -= OnStateChanged;
        }

        private void OnStateChanged(PopperState state)
        {
            sr.sprite = config.GetSprite(state);
        }

        private void AttachEyes()
        {
            Instantiate(config.leftEyePrefab, transform);
            Instantiate(config.rightEyePrefab, transform);
        }
    }
}

using CrazyPopper.Events;
using UnityEngine;

namespace CrazyPopper.Poppers
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class PopperView : MonoBehaviour
    {
        [SerializeField] private PopperConfig config;

        private SpriteRenderer sr;
        private PopperEntity _entity;
        private void Awake()
        {
            sr = GetComponent<SpriteRenderer>();
            _entity = GetComponent<PopperEntity>();
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

        private void OnStateChanged(PopperState state, PopperEntity entity)
        {
            if (entity != _entity) return;
            Sprite spr = config.GetSprite(state);
            // Debug.Log($"Sprite Name : {spr.name}");
            sr.sprite = spr;
            if (_entity.transform.childCount > 0)
            {
                EyeFactory.DetachEyes(_entity.transform);
            }
            EyeFactory.AttachEyes(_entity.transform, state);
        }

        private void AttachEyes()
        {
            // Instantiate(config.leftEyePrefab, transform);
            // Instantiate(config.rightEyePrefab, transform);
        }
    }
}

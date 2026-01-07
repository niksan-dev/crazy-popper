using System.Collections;
using System.Collections.Generic;
using CrazyPopper.Poppers;
using UnityEngine;
using CrazyPopper.Events;
using CrazyPopper.Projectiles;
namespace CrazyPopper.Core
{
    public class GridSpawner : MonoBehaviour
    {

        public static GridSpawner Instance { get; private set; }

        [SerializeField] private LevelConfig levelConfig;
        [SerializeField] private Transform objectPoolParent;
        float popperXSize = 2f;
        float popperYSize = 1.5f;

        float paddingY = 1.0f;

        [SerializeField] private List<PopperEntity> poppers = new List<PopperEntity>();

        void Awake()
        {
            Instance = this;
        }
        public void Spawn(LevelConfig level)
        {
            this.gameObject.SetActive(true);
            int i = 0;
            float offsetX = -(level.size.x * popperXSize / 2.0f) + (popperXSize / 2.0f);
            float offsetY = -(level.size.y * popperYSize / 2.0f) + (popperYSize / 2.0f) - paddingY;

            Debug.Log("offsetX : " + offsetX + " offsetY : " + offsetY);
            for (int y = 0; y < level.size.y; y++)
            {
                for (int x = 0; x < level.size.x; x++, i++)
                {
                    if (level.popperLayout[i] == PopperState.None) continue;
                    Vector3 position = new Vector3(offsetX + x * popperXSize, offsetY + y * popperYSize, 0);
                    PopperFactory.Spawn(
                           position,
                           level.popperLayout[i]
                       );
                }
            }
        }

        private void OnEnable()
        {
            EventBus.OnLevelRetry += OnLevelRetry;
            EventBus.OnLevelExit += OnLevelExit;
        }

        void OnLevelExit()
        {
            this.gameObject.SetActive(false);
            ClearGrid();
        }

        void OnLevelRetry()
        {
            this.gameObject.SetActive(false);
            ClearGrid();
            GameManager.Instance.InitializeGame();
        }

        public void ClearGrid()
        {

            for (int i = transform.childCount - 1; i >= 0; i--)
            {
                if (transform.GetChild(i).TryGetComponent<IDeSpawnable>(out var poolable))
                {
                    poolable.Despawn();
                }
            }
        }

        private void OnDisable()
        {

            EventBus.OnLevelRetry -= OnLevelRetry;
            EventBus.OnLevelExit -= OnLevelExit;
        }
    }
}

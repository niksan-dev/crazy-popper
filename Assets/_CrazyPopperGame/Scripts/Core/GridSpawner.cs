using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
namespace CrazyPopper.Core
{
    public class GridSpawner : MonoBehaviour
    {

        [SerializeField] private LevelConfig levelConfig;

        float popperXSize = 2f;
        float popperYSize = 1.5f;

        void Start()
        {
            // Spawn(levelConfig);
        }
        public void Spawn(LevelConfig level)
        {
            this.gameObject.SetActive(true);
            int i = 0;
            float offsetX = -(level.size.x / 2.0f) - (level.size.x % 2 == 0 ? popperXSize / 2.0f : 0);
            float offsetY = -(level.size.y / 2.0f) - (level.size.y % 2 == 0 ? popperYSize / 2.0f : 0);
            for (int y = 0; y < level.size.y; y++)
            {
                for (int x = 0; x < level.size.x; x++, i++)
                {
                    if (level.layout[i] == Poppers.PopperState.None) continue;

                    PopperFactory.Create(
                        new Vector3(offsetX + x * popperXSize, offsetY + y * popperYSize, 0),
                        level.layout[i]
                    );
                }
            }
        }

        public void ClearGrid()
        {
            foreach (Transform child in transform)
            {
                PopperFactory.Destroy(child.transform.GetComponent<Poppers.PopperEntity>());
            }
        }

        void OnDisable()
        {
            ClearGrid();
        }
    }
}

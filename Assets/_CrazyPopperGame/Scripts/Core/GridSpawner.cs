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
            Spawn(levelConfig);
        }
        public void Spawn(LevelConfig level)
        {
            int i = 0;
            float offsetX = -(level.size.x / 2.0f) - popperXSize / 2.0f;
            float offsetY = -(level.size.y / 2.0f) - popperYSize / 2.0f;

            Debug.Log($"offsetX : {offsetX}   offsetY : {offsetY}");
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
    }
}

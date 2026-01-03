using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CrazyPopper.Core
{
    public class GridSpawner : MonoBehaviour
    {

        [SerializeField] private LevelConfig levelConfig;

        void Start()
        {
            Spawn(levelConfig);
        }
        public static void Spawn(LevelConfig level)
        {
            int i = 0;
            for (int y = 0; y < level.size.y; y++)
            {
                for (int x = 0; x < level.size.x; x++, i++)
                {
                    if (level.layout[i] == Poppers.PopperState.None) continue;
                    PopperFactory.Create(
                        new Vector3(x * 1.5f, y * 1.25f, 0),
                        level.layout[i]
                    );
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] GameObject blackCubePrefab;
    [SerializeField] GameObject whiteCubePrefab;

    [SerializeField] GameObject blackEmpty;
    [SerializeField] GameObject whiteEmpty;

    [SerializeField] Transform spawnArea1;
    [SerializeField] Transform spawnArea2;
    [SerializeField] Transform spawnArea3;

    private List<GameObject> firstZoneCubes = new List<GameObject>();

    void Start()
    {
        SpawnRandomCubes();
        SpawnZone_1_2();

    }

    void SpawnZone_1_2()
    {
        Vector3 startPosition_1 = spawnArea1.position - new Vector3(1.5f, 0f, 1.5f);
        Vector3 startPosition_2 = spawnArea2.position - new Vector3(1.5f, 0f, 1.5f);
        Vector3 startPosition_3 = spawnArea3.position - new Vector3(0.2f, 0f, 0.2f);
        int index = 0;

        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                GameObject cube = firstZoneCubes[index];
                Vector3 spawnPosition_1 = startPosition_1 + new Vector3(col * 1.5f, 0.5f, row * 1.5f);                
                Instantiate(cube, spawnPosition_1, Quaternion.identity);

                if (firstZoneCubes[index].gameObject.name == "Cube_Black")
                {
                    Vector3 spawnPosition_2 = startPosition_2 + new Vector3(col * 1.5f, 0.1f, row * 1.5f);
                    Instantiate(blackEmpty, spawnPosition_2, Quaternion.identity);
                }
                if (firstZoneCubes[index].gameObject.name == "Cube_White")
                {
                    Vector3 spawnPosition_2 = startPosition_2 + new Vector3(col * 1.5f, 0.1f, row * 1.5f);
                    Instantiate(whiteEmpty, spawnPosition_2, Quaternion.identity);
                }

                Vector3 spawnPosition_3 = startPosition_3 + new Vector3(col * 0f, 0f, row * 0f);
                Instantiate(cube, spawnPosition_3, Quaternion.identity);
                index++;
            }
        }
    }

    void SpawnRandomCubes()
    {
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                GameObject cubePrefab = Random.Range(0, 2) == 0 ? blackCubePrefab : whiteCubePrefab;
                firstZoneCubes.Add(cubePrefab);
            }
        }
    }
}

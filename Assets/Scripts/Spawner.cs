using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Spawner : MonoBehaviour
{
    
    public GameObject[] commonEnemies;
    public GameObject[] uncommonEnemies;
    public GameObject[] rareEnemies;

    public Transform spawnPoint;
    public float spawnDelay = 1f;
    public float stopDistance = 5f;

    private List<GameObject> currentEnemies = new List<GameObject>();

    private enum PatternType { Line, VShape, Circle, Wave, RandomCluster, Box }

    void Start()
    {
        StartCoroutine(SpawnPatternLoop());
    }

    IEnumerator SpawnPatternLoop()
    {
        while (true)
        {
            if (currentEnemies.Count == 0)
            {
                yield return SpawnPattern((PatternType)Random.Range(0, 6));
                yield return new WaitForSeconds(spawnDelay);
            }
            yield return null;
        }
    }

    IEnumerator SpawnPattern(PatternType pattern)
    {
        currentEnemies.Clear();

        Vector3 basePos = spawnPoint.position;
        List<Vector3> offsets = new List<Vector3>();

        switch (pattern)
        {
            case PatternType.Line:
                for (int i = -3; i <= 3; i++)
                    offsets.Add(new Vector3(i * 1.5f, 0, 0));
                break;

            case PatternType.VShape:
                for (int i = -3; i <= 3; i++)
                    offsets.Add(new Vector3(i * 1.2f, Mathf.Abs(i) * 0.8f, 0));
                break;

            case PatternType.Circle:
                int count = 10;
                float radius = 3f;
                for (int i = 0; i < count; i++)
                {
                    float angle = i * Mathf.PI * 2f / count;
                    offsets.Add(new Vector3(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius, 0));
                }
                break;

            case PatternType.Wave:
                for (int i = 0; i < 7; i++)
                    offsets.Add(new Vector3(i * 1.5f - 4.5f, Mathf.Sin(i * 1f) * 1.5f, 0));
                break;

            case PatternType.RandomCluster:
                for (int i = 0; i < 8; i++)
                    offsets.Add(new Vector3(Random.Range(-4f, 4f), Random.Range(-2f, 2f), 0));
                break;

            case PatternType.Box:
                int rows = 3;
                int cols = 5;
                float spacing = 1.5f;
                stopDistance = 4;

                for (int y = 0; y < rows; y++)
                {
                    for (int x = 0; x < cols; x++)
                    {
                        float offsetX = (x - (cols - 1) / 2f) * spacing;
                        float offsetY = -y * spacing;
                        offsets.Add(new Vector3(offsetX, offsetY, 0));
                    }
                }
                break;
        }

        foreach (Vector3 offset in offsets)
        {
            GameObject prefab = GetRandomEnemyByRarity();
            GameObject enemy = Instantiate(prefab, basePos + offset, Quaternion.identity);
            currentEnemies.Add(enemy);

            // Attach distance control
            var movement = enemy.GetComponent<enemyMovement>();
            if (movement != null)
                movement.SetStopDistance(stopDistance);
        }

        // Wait for all enemies to be destroyed
        while (currentEnemies.Count > 0)
        {
            currentEnemies.RemoveAll(e => e == null);
            yield return null;
        }
    }

    GameObject GetRandomEnemyByRarity()
    {
        float roll = Random.value;
        if (roll < 0.6f) return commonEnemies[Random.Range(0, commonEnemies.Length)];
        else if (roll < 0.9f) return uncommonEnemies[Random.Range(0, uncommonEnemies.Length)];
        else return rareEnemies[Random.Range(0, rareEnemies.Length)];
    }
}//class
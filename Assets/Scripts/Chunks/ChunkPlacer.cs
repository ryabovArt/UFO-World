using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkPlacer : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Chunk[] chunkPrefabs;
    [SerializeField] private Chunk firstChunk;

    private List<Chunk> spawnedChunks = new List<Chunk>(); // список чанков

    void Start()
    {
        spawnedChunks.Add(firstChunk);
        StartCoroutine(AddNewChunk());
    }

    /// <summary>
    /// Сравниваем позицию игрока и конеу чанка
    /// </summary>
    /// <returns></returns>
    IEnumerator AddNewChunk()
    {
        yield return new WaitForSeconds(2f);
        if (player != null)
        {
            if (player.position.x > spawnedChunks[spawnedChunks.Count - 1].EndPoint.position.x - 80f)
            {
                SpawnChunk();
            }
        }
        StartCoroutine(AddNewChunk());
    }

    /// <summary>
    /// Спавним чанки
    /// </summary>
    private void SpawnChunk()
    {
        Chunk newChunk = Instantiate(chunkPrefabs[Random.Range(0, chunkPrefabs.Length)]);
        newChunk.transform.position = spawnedChunks[spawnedChunks.Count - 1].EndPoint.position - newChunk.StartPoint.localPosition;
        spawnedChunks.Add(newChunk);

        if(spawnedChunks.Count >= 3)
        {
            Destroy(spawnedChunks[0].gameObject);
            spawnedChunks.RemoveAt(0);
        }
    }
}

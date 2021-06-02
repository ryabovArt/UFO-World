using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkPlacer : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Chunk[] chunkPrefabs;
    public Chunk firstChunk;
    [SerializeField] private GameObject leftBound; // левая граница

    [SerializeField] private GameObject checkDestroy;

    private int chunkIndex;
    public int ChunkIndex { get { return chunkIndex; } }

    private List<Chunk> spawnedChunks = new List<Chunk>(); // список чанков
    public List<Chunk> SpawnedChunks { get { return spawnedChunks; } }

    private GameObject mainCam;
    private CameraMovement cam;
    private float coef; // половина длины чанка

    void Start()
    {
        coef = firstChunk.EndPoint.transform.position.x / 2f;
        mainCam = GameObject.FindGameObjectWithTag("MainCamera");
        if (mainCam.TryGetComponent(out CameraMovement cameraMovement))
        {
            cam = cameraMovement.GetComponent<CameraMovement>();
        }

        spawnedChunks.Add(firstChunk);

        StartCoroutine(AddNewChunk());
    }
    
    /// <summary>
    /// Сравниваем позицию игрока и конец чанка
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
        //int index = Random.Range(0, chunkPrefabs.Length);

        //if(index == lastChunkIndex) index = Random.Range(0, chunkPrefabs.Length);

        //if (index != lastChunkIndex)
        //{
        //    lastChunkIndex = index;
        //    Chunk newChunk = Instantiate(chunkPrefabs[index]);
        //    newChunk.transform.position = spawnedChunks[spawnedChunks.Count - 1].EndPoint.position - newChunk.StartPoint.localPosition;
        //    spawnedChunks.Add(newChunk);
        //}     
        
        if (chunkIndex < chunkPrefabs.Length)
        {
            Chunk newChunk = Instantiate(chunkPrefabs[chunkIndex]);
            newChunk.transform.position = spawnedChunks[spawnedChunks.Count - 1].EndPoint.position - newChunk.StartPoint.localPosition;
            spawnedChunks.Add(newChunk);
            chunkIndex++;
            print("chunkIndex " + chunkIndex);
        }

        if (spawnedChunks.Count >= 3)
        {
            Destroy(spawnedChunks[0].gameObject);
            spawnedChunks.RemoveAt(0);
            if (checkDestroy.GetComponent<UFOCheckTrigger>().checkPoints.Count > 0 && checkDestroy.GetComponent<UFOCheckTrigger>().checkPoints != null) 
                checkDestroy.GetComponent<UFOCheckTrigger>().checkPoints.RemoveAt(0);
            SetLeftBorder();
        }
    }

    /// <summary>
    /// Устанавливаем левую границу для камеры и для игрока
    /// </summary>
    private void SetLeftBorder()
    {
        cam.leftBorder = spawnedChunks[spawnedChunks.Count - 2].StartPoint.position.x + coef;
        leftBound.transform.position = new Vector3(spawnedChunks[spawnedChunks.Count - 2].StartPoint.position.x, 10f, 12f);
    }
}

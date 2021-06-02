using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOCheckTrigger : MonoBehaviour
{
    public static Transform particleGO;
    public static Transform particleGO_2;
    public static Transform renderer;
    private int checkPointCount;
    private GameObject forDestroy;

    public List<Transform> checkPoints = new List<Transform>();

    [SerializeField] private GameObject checkDestroy;

    private GameObject chunkPlacer;

    private void Start()
    {
        chunkPlacer = GameObject.FindGameObjectWithTag("ChunkPlacer");
        StartCoroutine(DifferenceBetweenChunksAndCheckpoints());
    }

    IEnumerator DifferenceBetweenChunksAndCheckpoints()
    {
        
        while (true)
        {
            yield return new WaitForSeconds(5f);
            if (chunkPlacer.GetComponent<ChunkPlacer>().SpawnedChunks[0].EndPoint.transform.position.x < transform.position.x
                && (chunkPlacer.GetComponent<ChunkPlacer>().ChunkIndex - checkPointCount) > 1)
            {
                print("вы пролетели чекпоинт");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BlackHole"))
        {
            Effects.instance.DestroyBlackHole();
        }
        if (other.CompareTag("CheckPoint"))
        {
            checkPoints.Add(other.GetComponent<Transform>().parent);
            print("add " + checkPoints.Count);
            other.GetComponentInChildren<MeshRenderer>().enabled = false;
            other.GetComponentInChildren<BoxCollider>().enabled = false;
            checkPointCount++;
        }
    }
    
    IEnumerator EnableMesh()
    {
        yield return new WaitForSeconds(1f);
        Destroy(forDestroy);
        forDestroy = null;
    }
}

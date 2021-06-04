using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UFOCheckTrigger : MonoBehaviour
{
    public static Transform particleGO;
    public static Transform particleGO_2;
    public static Transform renderer;
    private int checkPointCount;

    public List<Transform> checkPoints = new List<Transform>();

    [SerializeField] private GameObject checkDestroy;
    [SerializeField] private GameObject rightBorder;

    private GameObject chunkPlacer;

    [SerializeField] private GameObject mainCam;
    private CameraMovement camMovement;

    //
    public Text warning;

    private void Start()
    {
        chunkPlacer = GameObject.FindGameObjectWithTag("ChunkPlacer");
        if (mainCam.TryGetComponent(out CameraMovement cameraMovement))
        {
            camMovement = cameraMovement.GetComponent<CameraMovement>();
        }
        StartCoroutine(DifferenceBetweenChunksAndCheckpoints());
    }

    /// <summary>
    /// Действия, когда игрок не собрал чекпоинт на текущем чанке
    /// </summary>
    /// <returns></returns>
    IEnumerator DifferenceBetweenChunksAndCheckpoints()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            if (chunkPlacer.GetComponent<ChunkPlacer>().SpawnedChunks[0].EndPoint.transform.position.x - (ChunkPlacer.chunkHulf * 2) < transform.position.x)
            {
                if ((chunkPlacer.GetComponent<ChunkPlacer>().ChunkIndex - checkPointCount) == 0)
                {
                    rightBorder.transform.position = new Vector3(chunkPlacer.GetComponent<ChunkPlacer>().SpawnedChunks[2].EndPoint.transform.position.x, 10f, 12f);
                }
                if ((chunkPlacer.GetComponent<ChunkPlacer>().ChunkIndex - checkPointCount) == 1)
                {
                    rightBorder.transform.position = new Vector3(chunkPlacer.GetComponent<ChunkPlacer>().SpawnedChunks[1].EndPoint.transform.position.x, 10f, 12f);

                    camMovement.rightBorder = rightBorder.transform.position.x - ChunkPlacer.chunkHulf;
                }
            }
        }
    }

    /// <summary>
    /// Устанавливаем правую границу для камеры и для игрока
    /// </summary>
    private void SetRightBorder()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CheckPoint"))
        {
            checkPoints.Add(other.GetComponent<Transform>().parent);
            print("add " + checkPoints.Count);
            other.GetComponentInChildren<MeshRenderer>().enabled = false;
            other.GetComponentInChildren<BoxCollider>().enabled = false;
            checkPointCount++;
        }
        if (other.CompareTag("RightBorder"))
        {
            warning.text = "вы пролетели чекпоинт";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("RightBorder"))
        {
            warning.text = string.Empty;
        }
    }
}

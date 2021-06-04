using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UFOCondition : MonoBehaviour
{
    [SerializeField] private GameObject ufo;
    [SerializeField] private Rigidbody rbUFO;

    [SerializeField] private GameObject checkDestroy;
    [SerializeField] private GameObject chunkPlacer;

    void Start()
    {
        UFOCrush.current.OnCrush += OnPlayerCrush;
    }

    public void OnPlayerCrush()
    {
        StartCoroutine(PlayerCrush());
    }

    /// <summary>
    /// Действия после смерти игрока
    /// </summary>
    /// <returns></returns>
    IEnumerator PlayerCrush()
    {
        int childCount = ufo.transform.childCount;

        for (int i = 0; i < childCount - 1; i++)
        {
            ufo.transform.GetChild(i).gameObject.SetActive(false);
        }
        
        yield return new WaitForSeconds(1f);

        for (int i = 0; i < childCount - 1; i++)
        {
            ufo.transform.GetChild(i).gameObject.SetActive(true);
        }

        var vel = rbUFO.velocity;
        vel.x = 0;
        vel.y = 0;

        SpawnAfterDeath();

        rbUFO.transform.rotation = Quaternion.identity;
    }

    /// <summary>
    /// Спавн игрока после смерти
    /// </summary>
    private void SpawnAfterDeath()
    {
        if (chunkPlacer.GetComponent<ChunkPlacer>().firstChunk != null)
        {
            rbUFO.transform.position = new Vector3(-50.7f, 36.5f, 12.15f);
        }
        else
        {
            if (checkDestroy.GetComponent<UFOCheckTrigger>().checkPoints.Count > 0)
            {
                rbUFO.transform.position = new Vector3
                (
                checkDestroy.GetComponent<UFOCheckTrigger>().checkPoints[checkDestroy.GetComponent<UFOCheckTrigger>().checkPoints.Count - 1].GetComponentInParent<Transform>().position.x,
                checkDestroy.GetComponent<UFOCheckTrigger>().checkPoints[checkDestroy.GetComponent<UFOCheckTrigger>().checkPoints.Count - 1].GetComponentInParent<Transform>().position.y + 15f,
                checkDestroy.GetComponent<UFOCheckTrigger>().checkPoints[checkDestroy.GetComponent<UFOCheckTrigger>().checkPoints.Count - 1].GetComponentInParent<Transform>().position.z
                );
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}

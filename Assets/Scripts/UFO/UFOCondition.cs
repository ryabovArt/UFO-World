using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOCondition : MonoBehaviour
{
    [SerializeField] private GameObject ufo;
    [SerializeField] private Rigidbody rbUFO;

    void Start()
    {
        UFOCrush.current.OnCrush += OnPlayerCrush;
    }

    private void OnPlayerCrush()
    {
        StartCoroutine(PlayerCrush());
    }

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
        Debug.Log(childCount);
        var vel = rbUFO.velocity;
        vel.x = 0;
        vel.y = 0;
        rbUFO.transform.position = new Vector3(-50.7f, 36.5f, 12.15f);
        rbUFO.transform.rotation = Quaternion.identity;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePatrol : MonoBehaviour
{
    [SerializeField] private Transform[] patrolPoint; // конечные точки патрулирования
    [SerializeField] private Transform playerTransform;

    [SerializeField] private float speed;
    private float startSpeed;
    [SerializeField] private float pursuitSpeed;
    [SerializeField] private float stopDistance;

    private int randomPiont;

    [SerializeField] private float startWaitTime;
    private float waitTime;

    private bool relax = false;
    private bool pursuit = false;
    private bool goBack = false;


    void Start()
    {
        waitTime = startWaitTime;
        startSpeed = speed;
        randomPiont = Random.Range(0, patrolPoint.Length);
        if (playerTransform == null) playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        ChangeState();
    }

    /// <summary>
    /// Смена состояний
    /// </summary>
    private void ChangeState()
    {
        if (pursuit == false && Vector3.Distance(transform.position, playerTransform.position) > patrolPoint[randomPiont].position.x ||
            Vector3.Distance(transform.position, playerTransform.position) > patrolPoint[randomPiont].position.y)
        {
            relax = true;
        }

        if (Vector3.Distance(transform.position, playerTransform.position) < stopDistance)
        {
            pursuit = true;
            relax = false;
            goBack = false;
        }

        if (Vector3.Distance(transform.position, playerTransform.position) > stopDistance)
        {
            goBack = true;
            pursuit = false;
        }

        if (relax)
        {
            Relax();
        }
        else if (pursuit)
        {
            Pursuit();
        }
        else if (goBack)
        {
            GoBack();
        }
    }

    /// <summary>
    /// Патрулирование территории
    /// </summary>
    private void Relax()
    {
        transform.position = Vector3.MoveTowards(transform.position, patrolPoint[randomPiont].position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, patrolPoint[randomPiont].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomPiont = Random.Range(0, patrolPoint.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
            
        }
    }

    /// <summary>
    /// Преследование игрока
    /// </summary>
    private void Pursuit()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
        speed = pursuitSpeed;
    }

    /// <summary>
    /// Возврат на патрулируемую территорию
    /// </summary>
    private void GoBack()
    {
        transform.position = Vector3.MoveTowards(transform.position, patrolPoint[randomPiont].position, speed * Time.deltaTime);
        speed = startSpeed;
    }
}

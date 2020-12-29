using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class antiruido : MonoBehaviour
{
    Vector3 startPosition;
    Vector3 target;
    float timeToReachTarget = 0.5f;
    float t;

    void Start()
    {
        startPosition =  transform.position;
    }
    void Update()
    {
        t += Time.deltaTime / timeToReachTarget;
        transform.position += Vector3.Lerp(startPosition, target, t);
    }
    public void SetDestination(Vector3 destination, float time)
    {
        t = 0;
        startPosition = transform.position;
        timeToReachTarget = time;
        target = destination;
    }
}

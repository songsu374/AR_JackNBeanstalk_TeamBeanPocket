using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climbing : MonoBehaviour
{
    public Transform desPos;
    public Transform startPos;
    public Transform endPos;
    public float speed;

    public float delay = 3.0f;
    private float currentDelay = 0.0f;

    private void Start()
    {
        transform.position = startPos.position;
        desPos = endPos;
    }

    private void FixedUpdate()
    {
        currentDelay -= Time.deltaTime;
        if (currentDelay < 0)
        {
            currentDelay = 0;
        }

        transform.position = Vector3.MoveTowards(transform.position, desPos.position, Time.deltaTime * speed);
        if (currentDelay > 0)
        {
            return;
        }
        if (Vector2.Distance(transform.position, desPos.position) <= 0.005f)
        {
            if (desPos == endPos)
            {
                desPos = startPos;
            }
            else desPos = endPos;
        }
 
        currentDelay = delay;
    }
}

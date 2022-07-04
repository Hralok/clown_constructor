using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeObj : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] public double minYPosition;
    private bool goingDown;

    void Start()
    {
        goingDown = true;
    }


    void Update()
    {
        if (goingDown)
        {
            if (transform.position.y > minYPosition)
            {
                transform.Translate(new Vector3(0, - speed * Time.deltaTime));
            }
            else
            {
                goingDown=false;
            }
        }
        else
        {
            if (transform.position.y < 0)
            {
                transform.Translate(new Vector3(0, speed * Time.deltaTime));
            }
            else
            {
                goingDown = true;
            }
        }
    }
}

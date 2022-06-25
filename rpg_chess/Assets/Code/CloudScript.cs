using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScript : MonoBehaviour
{
    public float speed;
    private double outCoord;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localPosition.x < outCoord)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.Translate(new Vector2(-speed * Time.deltaTime, 0));
        }
    }

    public void ChangeParameters(double outCoords, float speed)
    {
        this.outCoord = outCoords - GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        this.speed = speed;
    }
}

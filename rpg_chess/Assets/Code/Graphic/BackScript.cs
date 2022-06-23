using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackScript : MonoBehaviour
{
    public GameObject camera;

    public float Parallax;
    float startPosX;
    float startPosY;
    // Start is called before the first frame update
    void Start()
    {
        startPosX = transform.position.x;
        startPosY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        float distX = (camera.transform.position.x * (1 - Parallax));
        float distY = (camera.transform.position.y * (1 - Parallax));
        transform.position = new Vector3(startPosX + distX, startPosY + distY, transform.position.z);
    }
}

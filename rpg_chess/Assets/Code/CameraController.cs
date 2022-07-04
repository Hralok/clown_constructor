using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private Camera mainCamera;

    [SerializeField]
    private float scrollScale;

    [SerializeField]
    private float minimalSize;

    [SerializeField]
    public float maximalSize;

    [SerializeField]
    private float movingSpeed;

    [SerializeField]
    private int pixelsFromBoarder;

    [SerializeField]
    public float baseCameraSize;

    private void Start()
    {
        mainCamera = Camera.main;
        mainCamera.orthographicSize = baseCameraSize;
    }

    void Update()
    {

        if (Input.mousePosition[0] >= 0 && Input.mousePosition[0] <= Screen.width)
        {
            if (Input.mousePosition[0] < pixelsFromBoarder)
            {
                mainCamera.transform.position += new Vector3(-(pixelsFromBoarder - Input.mousePosition[0]) / pixelsFromBoarder, 0, 0) * Time.deltaTime * movingSpeed * mainCamera.orthographicSize / baseCameraSize;
            }
            else if (Input.mousePosition[0] > Screen.width - pixelsFromBoarder)
            {
                mainCamera.transform.position += new Vector3((Input.mousePosition[0] - (Screen.width - pixelsFromBoarder)) / pixelsFromBoarder, 0, 0) * Time.deltaTime * movingSpeed * mainCamera.orthographicSize / baseCameraSize;
            }
        }
        else if (Input.mousePosition[0] < 0)
        {
            mainCamera.transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * movingSpeed * mainCamera.orthographicSize / baseCameraSize;
        }
        else if (Input.mousePosition[0] > Screen.width)
        {
            mainCamera.transform.position += new Vector3(1, 0, 0) * Time.deltaTime * movingSpeed * mainCamera.orthographicSize / baseCameraSize;
        }




        if (Input.mousePosition[1] >= 0 && Input.mousePosition[1] <= Screen.height)
        {
            if (Input.mousePosition[1] < pixelsFromBoarder)
            {
                mainCamera.transform.position += new Vector3(0, -(pixelsFromBoarder - Input.mousePosition[1]) / pixelsFromBoarder, 0) * Time.deltaTime * movingSpeed * mainCamera.orthographicSize / baseCameraSize;
            }
            else if (Input.mousePosition[1] > Screen.height - pixelsFromBoarder)
            {
                mainCamera.transform.position += new Vector3(0, (Input.mousePosition[1] - (Screen.height - pixelsFromBoarder)) / pixelsFromBoarder, 0) * Time.deltaTime * movingSpeed * mainCamera.orthographicSize / baseCameraSize;
            }
        }
        else if (Input.mousePosition[1] < 0)
        {
            mainCamera.transform.position += new Vector3(0, -1, 0) * Time.deltaTime * movingSpeed * mainCamera.orthographicSize / baseCameraSize;
        }
        else if (Input.mousePosition[1] > Screen.height)
        {
            mainCamera.transform.position += new Vector3(0, 1, 0) * Time.deltaTime * movingSpeed * mainCamera.orthographicSize / baseCameraSize;
        }




        if (Input.mouseScrollDelta[1] != 0)
        {
            if (mainCamera.orthographicSize + Input.mouseScrollDelta[1] * scrollScale < minimalSize)
            {
                mainCamera.orthographicSize = minimalSize;
            }
            else if (mainCamera.orthographicSize + Input.mouseScrollDelta[1] * scrollScale > maximalSize)
            {
                mainCamera.orthographicSize = maximalSize;
            }
            else
            {
                mainCamera.orthographicSize += Input.mouseScrollDelta[1] * scrollScale;
            }
        }



    }
}

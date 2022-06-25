using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundControl : MonoBehaviour
{
    [SerializeField] public GameObject[] bigClouds;
    [SerializeField] public GameObject[] mediumClouds;
    [SerializeField] public GameObject[] smallClouds;

    private float height;
    private double leftBoarder;
    private double rightBoarder;

    [SerializeField] public double currentTimeBC;
    [SerializeField] public float minTimeToNextBC;
    [SerializeField] public float maxTimeToNextBC;
    [SerializeField] public float minSpeedBC;
    [SerializeField] public float maxSpeedBC;
    [SerializeField] public float speedScaleBC;
    [SerializeField] public int minCountBC;
    [SerializeField] public int maxCountBC;

    [SerializeField] public double currentTimeMC;
    [SerializeField] public float minTimeToNextMC;
    [SerializeField] public float maxTimeToNextMC;
    [SerializeField] public float minSpeedMC;
    [SerializeField] public float maxSpeedMC;
    [SerializeField] public float speedScaleMC;
    [SerializeField] public int minCountMC;
    [SerializeField] public int maxCountMC;

    [SerializeField] public double currentTimeSC;
    [SerializeField] public float minTimeToNextSC;
    [SerializeField] public float maxTimeToNextSC;
    [SerializeField] public float minSpeedSC;
    [SerializeField] public float maxSpeedSC;
    [SerializeField] public float speedScaleSC;
    [SerializeField] public int minCountSC;
    [SerializeField] public int maxCountSC;

    public void Start()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); // bottom-left corner
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));






        height = max.y * transform.GetComponent<CameraController>().maximalSize / transform.GetComponent<CameraController>().baseCameraSize;

        leftBoarder = min.x * transform.GetComponent<CameraController>().maximalSize / transform.GetComponent<CameraController>().baseCameraSize;


        double maxWeidth = 0;

        foreach (var cloud in bigClouds)
        {
            if (cloud.GetComponent<SpriteRenderer>().sprite.bounds.size.x > maxWeidth)
            {
                maxWeidth = cloud.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
            }
        }

        rightBoarder = max.x * transform.GetComponent<CameraController>().maximalSize / transform.GetComponent<CameraController>().baseCameraSize + maxWeidth / 2;
    }

    private void Update()
    {
        if (currentTimeBC > 0)
        {
            currentTimeBC -= Time.deltaTime;
        }
        else
        {
            for (int i = 0; i < Random.Range(minCountBC, maxCountBC); i++)
            {
                GenerateCloud(bigClouds, Random.Range(minSpeedBC * speedScaleBC, maxSpeedBC * speedScaleBC));
            }

            currentTimeBC = Random.Range(minTimeToNextBC, maxTimeToNextBC);
        }

        if (currentTimeMC > 0)
        {
            currentTimeMC -= Time.deltaTime;
        }
        else
        {
            for (int i = 0; i < Random.Range(minCountMC, maxCountMC); i++)
            {
                GenerateCloud(mediumClouds, Random.Range(minSpeedMC * speedScaleMC, maxSpeedMC * speedScaleMC));
            }
            currentTimeMC = Random.Range(minTimeToNextMC, maxTimeToNextMC);
        }

        if (currentTimeSC > 0)
        {
            currentTimeSC -= Time.deltaTime;
        }
        else
        {
            for (int i = 0; i < Random.Range(minCountSC, maxCountSC); i++)
            {
                GenerateCloud(smallClouds, Random.Range(minSpeedSC * speedScaleSC, maxSpeedSC * speedScaleSC));
            }
            currentTimeSC = Random.Range(minTimeToNextSC, maxTimeToNextSC);
        }
    }

    private void GenerateCloud(GameObject[] clouds, float speed)
    {
        int i = Random.Range(0, clouds.Length);
        var cloud = Instantiate(clouds[i], Vector3.zero, Quaternion.identity, transform);
        cloud.transform.localPosition = new Vector3((float)rightBoarder, Random.Range(-height, height), 0);
        cloud.GetComponent<CloudScript>().ChangeParameters(leftBoarder, speed);
    }
}

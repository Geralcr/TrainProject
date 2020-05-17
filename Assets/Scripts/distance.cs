using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class distance : MonoBehaviour
{
    public GameObject firstObject;
    public GameObject secondObject;

    public Transform transformFirstObject;
    public Transform transformSecondtObject;

    private Vector3 positionFirstObject;
    private Vector3 positionSecondObject;
    private float distanceObjs;

    public float distanceX = 5;
    public float distanceZ = 10;

    private float timeX = 0;
    private float timeZ = 0;

    //Chancha hace matriz,PERO RAPIDO


    void Start()
    {
        firstObject = GameObject.FindWithTag("Router");
        secondObject = GameObject.FindWithTag("Floor");
        transformFirstObject = firstObject.GetComponent<Transform>();
        transformSecondtObject = secondObject.GetComponent<Transform>();

        // for (int i = 0; i < distanceZ; i++)
        // {
        //     for (int j = 0; j < distanceX; j++)
        //     {
        //         Debug.Log(i + "," + j);
        //         transformSecondtObject.position = new Vector3(j, 0, -i);
        //     }
        // }

    }

    void Update()
    {
        timeX += Time.deltaTime;
        //timeZ += Time.deltaTime;
        //transformSecondtObject.position = new Vector3(timeX, 0, -timeZ);

        if (timeX < distanceX)
        {
            int aux = Convert.ToInt32(timeX);
            transformSecondtObject.position = new Vector3( aux, 0.5f , -timeZ);

        }else
        {
            timeZ++;
            timeX = 0;
        } 

        positionFirstObject = transformFirstObject.position;
        positionSecondObject = transformSecondtObject.position;
        distanceObjs = Vector3.Distance(positionFirstObject, positionSecondObject);
        Debug.Log(distanceObjs);

    }
}

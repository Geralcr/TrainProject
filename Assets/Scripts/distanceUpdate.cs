using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class distanceUpdate : MonoBehaviour
{
    public GameObject firstObject;
    public GameObject secondObject;

    Transform transformFirstObject;
    Transform transformSecondtObject;

    private Vector3 positionFirstObjectRouter;
    private Vector3 positionSecondObject;
    private double distanceObjs;

    public int row = 200;
    public int column = 8;

    public float trainWidth = 3.4f;
    public float trainLength = 87.2f;

    private string[,] dataMatrix;

    string path;

    private float cellWidth;
    private float cellLength;

    private float timeX;
    private int posZ;
    private int posX;

    public float offSetX = 0f;
    public float offSetZ = 0f;

    void Start()
    {
        cellLength = trainLength / row;
        cellWidth = trainWidth / column;
    

        dataMatrix = new string[row + 1, column + 1];

        firstObject = GameObject.FindWithTag("Router");
        secondObject = GameObject.FindWithTag("Floor");

        transformFirstObject = firstObject.GetComponent<Transform>();
        transformSecondtObject = secondObject.GetComponent<Transform>();
        positionFirstObjectRouter = transformFirstObject.position;

        path = Application.dataPath + "/Data.txt";
        File.WriteAllText(path, "Datos matrices");
        File.AppendAllText(path, "\n Posicion | Estado | Distancia\n");
    }
    void Update()
    {
        timeX += Time.deltaTime;
        if (timeX >= 1)
        {
            posX++;
            timeX = 0;

        }

        if (posX < column)
        {
            if (posZ < row)
            {
                transformSecondtObject.position = new Vector3(posX * cellWidth + offSetX, 0.5f, -posZ * cellLength - offSetZ);
                positionSecondObject = transformSecondtObject.position;
                distanceObjs = Vector3.Distance(positionFirstObjectRouter, positionSecondObject);

                dataMatrix[posZ, posX] = distanceObjs.ToString();
                Debug.Log($"{posZ},{posX} = {dataMatrix[posZ, posX]}");
                File.AppendAllText(path, $"\n  0       {posZ},{posX}       {dataMatrix[posZ, posX]}\n");

            }
        }
        else
        {
            posZ++;
            posX = 0;
        }
    }
}


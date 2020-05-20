using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class distance : MonoBehaviour
{
    public string fileName;
    private GameObject firstObjectRouter;
    private GameObject secondObject;

    private Transform transformFirstObjectRouter;
    private Transform transformSecondtObject;

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

    private float offSetX = 0f;
    private float offSetZ = 0f;


    void Start()
    {

        dataMatrix = new string[row + 1, column + 1];

        firstObjectRouter = GameObject.FindWithTag("Router");
        secondObject = GameObject.FindWithTag("Floor");

        transformFirstObjectRouter = firstObjectRouter.GetComponent<Transform>();
        transformSecondtObject = secondObject.GetComponent<Transform>();

        positionFirstObjectRouter = transformFirstObjectRouter.position;

        path = Application.dataPath + "/"+fileName+".txt";
        File.WriteAllText(path, "Datos matrices");
        File.AppendAllText(path, "\n Posicion | Estado | Distancia\n");

        cellLength = trainLength / row;
        cellWidth = trainWidth / column;
        
        offSetZ = cellLength / 2;
        offSetX = cellWidth / 2;

        //Debug.Log($"{cellLength}{cellWidth}");

        for (int i = 0; i < row; i++)
        {
            File.AppendAllText(path, $"\n");

            for (int j = 0; j < column; j++)
            {
                transformSecondtObject.position = new Vector3(j * cellWidth + offSetX, 0.5f, -i * cellLength - offSetZ);
                positionSecondObject = transformSecondtObject.position;
                distanceObjs = Vector3.Distance(positionFirstObjectRouter, positionSecondObject);
                dataMatrix[i, j] = distanceObjs.ToString("N2");
                //Debug.Log($"{i},{j} = {dataMatrix[i, j]}");
                File.AppendAllText(path, $"  [ {i},{j} | {0} | {dataMatrix[i, j]}]  ");
            }
        }

    }

    void Update()
    {

    }
}

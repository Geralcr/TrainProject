using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class distance : MonoBehaviour
{
    public GameObject firstObject;
    public GameObject secondObject;

    Transform transformFirstObject;
    Transform transformSecondtObject;

    private Vector3 positionFirstObjectRouter;
    private Vector3 positionSecondObject;
    private float distanceObjs;

    public int distanceX = 5;
    public int distanceZ = 10;

    private float timeX = 0;
    private int posZ = 0;

    public string[,] dataMatrix;

    string path;

    //Chancha hace matriz,PERO RAPIDO


    void Start()
    {
        dataMatrix = new string[distanceZ + 1, distanceX + 1];
        firstObject = GameObject.FindWithTag("Router");
        secondObject = GameObject.FindWithTag("Floor");
        transformFirstObject = firstObject.GetComponent<Transform>();
        transformSecondtObject = secondObject.GetComponent<Transform>();
        positionFirstObjectRouter = transformFirstObject.position;

        // for (int i = 0; i < distanceZ; i++)
        // {
        //     for (int j = 0; j < distanceX; j++)
        //     {
        //         Debug.Log(i + "," + j);
        //         transformSecondtObject.position = new Vector3(j, 0, -i);
        //     }
        // }

          //Get the path of the Game data folder
        path = Application.dataPath + "/Data.txt";
        File.WriteAllText(path,"Datos matrices");
        File.AppendAllText(path,"\nEstado   Posicion  Distancia");

    }

    void Update()
    {
        timeX += Time.deltaTime;
        //timeZ += Time.deltaTime;
        //transformSecondtObject.position = new Vector3(timeX, 0, -timeZ);


        if (timeX < distanceX)
        {
            if (posZ < distanceZ)
            {

                int posX = Convert.ToInt32(timeX);

                transformSecondtObject.position = new Vector3(posX, 0.5f, -posZ);
                positionSecondObject = transformSecondtObject.position;
                distanceObjs = Vector3.Distance(positionFirstObjectRouter, positionSecondObject);

                dataMatrix[posZ, posX] = distanceObjs.ToString();
                //Debug.Log($"fila = {timeX} se pasa a {posX}");
                //Debug.Log($"columna = {posZ}");
                Debug.Log($"{posZ},{posX} = {dataMatrix[posZ, posX]}");
                File.AppendAllText(path,$"\n  0       {posZ},{posX}       {dataMatrix[posZ, posX]}\n");
            }

        }
        else
        {
            posZ++;
            timeX = 0;
        }

    }
}

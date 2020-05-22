using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class distance : MonoBehaviour
{

    public Text finish;


    public GameObject Router1;
    public GameObject Router2;
    public GameObject Router3;
    public GameObject targetPoint;

    private Transform transformRouter1;
    private Transform transformRouter2;
    private Transform transformRouter3;
    private Transform transformTragetPoint;

    private double distanceRouter1;
    private double distanceRouter2;
    private double distanceRouter3;

    public int row = 200;
    public int column = 8;

    public float trainWidth = 3.4f;
    public float trainLength = 87.2f;

    private string[,] dataMatrixRouter1;
    private string[,] dataMatrixRouter2;
    private string[,] dataMatrixRouter3;

    string pathRouter1;
    string pathRouter2;
    string pathRouter3;

    private float offSetX = 0f;
    private float offSetZ = 0f;

    public string fileName;

    private float cellWidth;
    private float cellLength;

    public float height;


    private string text1 = String.Empty;
    private string text2 = String.Empty;
    private string text3 = String.Empty;

    void Start()
    {

    }

    public void  EjecutarCalculos()
    {
        Debug.Log("Inició");

        HandleInitial();

        cellLength = CalcularTamCelda(trainWidth, trainLength).Length;
        cellWidth = CalcularTamCelda(trainWidth, trainLength).Width;

        offSetZ = cellLength / 2;
        offSetX = cellWidth / 2;

        RecorrerMatriz();

        WriteAllText();

        finish.text = "Finalizó, Revise los archivos con los datos";
        Debug.Log("Terminó");
    }

    Cell CalcularTamCelda(float width, float length)
    {
        Cell CellSize = new Cell();
        CellSize.Width = width / column;
        CellSize.Length = length / row;
        return CellSize;
    }

    void RecorrerMatriz()
    {
        for (int i = 0; i < row; i++)
        {

            text1 += $"\n";
            text2 += $"\n";
            text3 += $"\n";

            for (int j = 0; j < column; j++)
            {
                transformTragetPoint.position = new Vector3(j * cellWidth + offSetX, height, -i * cellLength - offSetZ);

                distanceRouter1 = Vector3.Distance(transformRouter1.position, transformTragetPoint.position);
                dataMatrixRouter1[i, j] = distanceRouter1.ToString("N2");
                text1 += CreateString(i.ToString(), j.ToString(), dataMatrixRouter1[i, j]);

                distanceRouter2 = Vector3.Distance(transformRouter2.position, transformTragetPoint.position);
                dataMatrixRouter2[i, j] = distanceRouter2.ToString("N2");
                text2 += CreateString(i.ToString(), j.ToString(), dataMatrixRouter2[i, j]);
                

                distanceRouter3 = Vector3.Distance(transformRouter3.position, transformTragetPoint.position);
                dataMatrixRouter3[i, j] = distanceRouter3.ToString("N2");
                text3 += CreateString(i.ToString(), j.ToString(), dataMatrixRouter3[i, j]);

            }
        }

    }

    void WriteAllText() {
        File.AppendAllText(pathRouter1, text1);
        File.AppendAllText(pathRouter2, text2);
        File.AppendAllText(pathRouter3, text3);

    }

    string CreateString(string i, string j, string distance)
    {
        int size1 = 3 - i.Length;
        int size2 = 5 - distance.Length;
        return $"  [ {i},{j}{ GetSpaces(size1)} | {0} | {distance}{GetSpaces(size2) }]  ";
    }

    private string GetSpaces(int totalLength)
    {
        return new String((char)32, totalLength);
    }

    void HandleInitial()
    {
        dataMatrixRouter1 = new string[row + 1, column + 1];
        dataMatrixRouter2 = new string[row + 1, column + 1];
        dataMatrixRouter3 = new string[row + 1, column + 1];

        transformRouter1 = Router1.GetComponent<Transform>();
        transformRouter2 = Router2.GetComponent<Transform>();
        transformRouter3 = Router3.GetComponent<Transform>();

        transformTragetPoint = targetPoint.GetComponent<Transform>();

        pathRouter1 = Application.dataPath + $"/{fileName}Router1.txt";
        File.WriteAllText(pathRouter1, "Datos matrices Router #1 ");

        pathRouter2 = Application.dataPath + $"/{fileName}Router2.txt";
        File.WriteAllText(pathRouter2, "Datos matrices Router #2 ");

        pathRouter3 = Application.dataPath + $"/{fileName}Router3.txt";
        File.WriteAllText(pathRouter3, "Datos matrices Router #3 ");
    }
}

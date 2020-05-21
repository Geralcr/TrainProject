using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class distance : MonoBehaviour
{
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

    void Start()
    {
        HandleInitial();

        cellLength = CalcularTamCelda(trainWidth, trainLength).Length;
        cellWidth = CalcularTamCelda(trainWidth, trainLength).Width;

        offSetZ = cellLength / 2;
        offSetX = cellWidth / 2;

        RecorrerMatriz();
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
            File.AppendAllText(pathRouter1, $"\n");
            File.AppendAllText(pathRouter2, $"\n");
            File.AppendAllText(pathRouter3, $"\n");

            for (int j = 0; j < column; j++)
            {
                transformTragetPoint.position = new Vector3(j * cellWidth + offSetX, 0.5f + height, -i * cellLength - offSetZ);

                distanceRouter1 = Vector3.Distance(transformRouter1.position, transformTragetPoint.position);
                dataMatrixRouter1[i, j] = distanceRouter1.ToString("N2");
                File.AppendAllText(pathRouter1, $"  [ {i},{j} | {0} | {dataMatrixRouter1[i, j]}]  ");

                distanceRouter2 = Vector3.Distance(transformRouter2.position, transformTragetPoint.position);
                dataMatrixRouter2[i, j] = distanceRouter2.ToString("N2");
                File.AppendAllText(pathRouter2, $"  [ {i},{j} | {0} | {dataMatrixRouter2[i, j]}]  ");

                distanceRouter3 = Vector3.Distance(transformRouter3.position, transformTragetPoint.position);
                dataMatrixRouter3[i, j] = distanceRouter3.ToString("N2");
                File.AppendAllText(pathRouter3, $"  [ {i},{j} | {0} | {dataMatrixRouter3[i, j]}]  ");
            }
        }

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

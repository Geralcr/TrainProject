using System.Globalization;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testRayCast : MonoBehaviour
{
    public GameObject obstaculo;
    private Transform transformobstaculo;

    public Vector3 direccion;
    void Start()
    {
        transformobstaculo = obstaculo.GetComponent<Transform>();

        

            for (int j = 0; j < 7; j++)
            {
                transformobstaculo.position = new Vector3(j,1,0);
               Instantiate(obstaculo, transformobstaculo.position,Quaternion.identity);

                Vector3 direccionRayCastRouter1 = transformobstaculo.position - gameObject.transform.position;
                RaycastHit hit;
                if (Physics.Raycast(gameObject.transform.position, direccionRayCastRouter1, out hit))
                {
                    Debug.Log(hit.transform.tag);
                    if (hit.transform.tag == "Target")
                    {
                        //EstadoLineaVista = 1;
                    }
                    else
                    {
                        //EstadoLineaVista = 0;
                    }
                }

            }
    }

    void Update()
    {


    }
}

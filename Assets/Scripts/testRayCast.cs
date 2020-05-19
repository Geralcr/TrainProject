using System.Globalization;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testRayCast : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
        RaycastHit hit;
        Debug.DrawRay(gameObject.transform.position, gameObject.transform.forward * 10, Color.green);

        if (Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out hit))
        {
            if(hit.transform.tag == "Obstacle") {

                Debug.Log("No hay linea de vista");
            }else {
                Debug.Log("Hay linea de vista");

            }
        }


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectaColisionPinza : MonoBehaviour
{
    public GameObject otro = null;


    void Awake()
    {
       // otro = GameObject.Find("coli");

    }



    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(otro.transform.position, transform.position) < 0.09f)
        {
            //Debug.Log("colisiona");

            GameObject aa = GameObject.Find("Brazo02PinzaRov01");
            Quaternion newRotation = Quaternion.LookRotation(aa.transform.position + new Vector3(0f,2f,0f), Vector3.left * .5f);
            newRotation.x = 0.0f;
            newRotation.z = 0.0f;
            aa.transform.localRotation = newRotation;
        }




    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hector : MonoBehaviour
{

    public GameObject panel;
    private int par=0;


    void Awake()
    {
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (par % 2 == 0)
            {
                panel.SetActive(true);
            }
            else
            {
                panel.SetActive(false);
            }

            par=par+1;
        }
        
    }
}

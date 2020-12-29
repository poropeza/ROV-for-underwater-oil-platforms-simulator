using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;
using System.IO;

public class pruebaxj : MonoBehaviour
{
    public Transform pulgar;
    public Transform indice;
    public Transform pinzaDerecha;
    public RigidHand mm;
    public GameObject muneca;

    private int activo_muneca_derecha = 0;
    private int activo_muneza_izquierda = 0;

    string strr1 = "";




    // Start is called before the first frame update
    void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {
        /*RigidFinger ff = pulgar.gameObject.GetComponentInParent<RigidFinger>();

        // transform.rotation = Quaternion.LookRotation(ff.GetBoneDirection(2)*-1f);//version previa
        
        Quaternion newRotation = Quaternion.LookRotation(transform.position - ff.GetBoneDirection(2), Vector3.up * .5f);
        newRotation.x = 0.0f;
        newRotation.z = 0.0f;
        transform.localRotation = newRotation;
        */


        //Se realiza el tracking del dedo índice y se coloca en 0 la rotación de dos ejes para que no exista ruido en el movimiento
        RigidFinger ff1 = indice.gameObject.GetComponentInParent<RigidFinger>();
        Quaternion newRotation1 = Quaternion.LookRotation(pinzaDerecha.position - ff1.GetBoneDirection(2) + new Vector3(0f, 100f, 0f), Vector3.down);
        newRotation1.x = 0.0f;
        newRotation1.z = 0.0f;

        //Movimiento de la pinza derecha con respecto al movimiento del dedo índice
        pinzaDerecha.localRotation = newRotation1;

        //Se realiza el movimiento espejo en pinza izquierda con respecto a la pinza derecha
        Quaternion rot180degrees = Quaternion.Euler(-newRotation1.eulerAngles);
        transform.localRotation = rot180degrees;



        //la muñeca rota a la derecha
        if (activo_muneca_derecha == 1)
        {
            //Debug.Log("rota a la derecha");
            muneca.transform.Rotate(Vector3.forward, 25f * Time.deltaTime);
        }

        //la muñeca rota a la izquierda
        if (activo_muneza_izquierda == 1)
        {
            //Debug.Log("se detiene rotar a la derecha");
            muneca.transform.Rotate(Vector3.back, 25f * Time.deltaTime);
        }




        /*
        //Escribe patrón de sentido de la mano para encontrar cuáles coordenadas corresponden a determinado sentido en un archivo
         if (lista_vistos.IndexOf(mm.GetPalmRotation().ToString()) == -1)
         {
             lista_vistos.Add(mm.GetPalmRotation().ToString());


             strr1 = strr1 + "" + mm.GetPalmRotation().ToString() + "\n";


             System.IO.File.AppendAllText("izquierda.txt", strr1);
         }  
         */


    }


    //función que recibe un quaternion como string y lo devuelve como quaternion
    public static Quaternion StringToQuaternion(string sQuaternion)
    {
        // Remueve los paréntesis
        if (sQuaternion.StartsWith("(") && sQuaternion.EndsWith(")"))
        {
            sQuaternion = sQuaternion.Substring(1, sQuaternion.Length - 2);
        }

        // split the items
        string[] sArray = sQuaternion.Split(',');

        // Lo guarda como un Vector3
        Quaternion result = new Quaternion(
            float.Parse(sArray[0]),
            float.Parse(sArray[1]),
            float.Parse(sArray[2]),
            float.Parse(sArray[3]));

        return result;
    }

    //función que activa el rotamiento de la pinza hacia la derecha
    public void DerechaPalma()
    {
        activo_muneca_derecha = 1;
    }

    //función que desactiva el rotamiento de la pinza hacia la derecha
    public void DesactivoDerechaPalma()
    {
        activo_muneca_derecha = 0;
    }

    //función que activa el rotamiento de la pinza hacia la izquierda
    public void IzquierdaPalma()
    {
        activo_muneza_izquierda = 1;
    }

    //función que desactiva el rotamiento de la pinza hacia la izquierda
    public void DesactivIzquierdaPalma()
    {
        activo_muneza_izquierda = 0;
    }



}

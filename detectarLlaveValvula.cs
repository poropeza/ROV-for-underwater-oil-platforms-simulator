using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class detectarLlaveValvula : MonoBehaviour {

	GameObject aux;

	//[ClientRpc]
	void OnTriggerEnter(Collider col) 
	{
		if( col.gameObject.name =="Tubo1")
		{
			aux= GameObject.Find("Fuga1");
			DestroyImmediate(aux,true);
		}
		else if( col.gameObject.name =="Tubo2")
		{
			aux= GameObject.Find("Fuga2");
			DestroyImmediate(aux,true);
		}
		else if( col.gameObject.name =="Tubo5")
		{
			aux= GameObject.Find("Fuga5");
			DestroyImmediate(aux,true);
		}
		else if( col.gameObject.name =="Tubo4")
		{
			aux= GameObject.Find("Fuga4");
			DestroyImmediate(aux,true);
		}


	}

}

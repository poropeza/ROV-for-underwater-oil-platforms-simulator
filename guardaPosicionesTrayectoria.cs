using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guardaPosicionesTrayectoria : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		StartCoroutine (guardarPosiciones (20, this.gameObject));
		
	}


	IEnumerator guardarPosiciones(int seg,GameObject obj)
	{


		// Vector3 startPosicion = new Vector3(0, 5, 25);
		Vector3 startPosicion = obj.transform.position;

		//NetworkServer.Destroy()

		DBConnect conec = new DBConnect ();
		conec.InsertRecordTrayectyoria(0,startPosicion.x, startPosicion.y, startPosicion.z); // sustituir 0 por el id correspondiente de cada usuario


		yield return new WaitForSecondsRealtime (seg);



	}




}

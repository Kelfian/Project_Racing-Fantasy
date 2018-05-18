using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAI00Desert : MonoBehaviour {

	public GameObject gotoHere;
	public GameObject pos1;
	public GameObject pos2;
	public GameObject pos3;
	public GameObject pos4;
	public GameObject pos5;
	public GameObject pos6;
	public GameObject pos7;
	public GameObject pos8;
	public GameObject pos9;
	public GameObject pos10;
	public GameObject pos11;
	public GameObject pos12;
	public GameObject pos13;
	public GameObject pos14;
	public GameObject pos15;
	public GameObject pos16;
	public GameObject pos17;
	public GameObject pos18;
	public GameObject pos19;
	public GameObject pos20;
	public GameObject pos21;
	public GameObject pos22;
	public GameObject pos23;
	public GameObject pos24;
	public GameObject pos25;
	public int tracker;
	

	void Update () {
		if(tracker == 0){
			gotoHere.transform.position = pos1.transform.position;
		}
		if(tracker == 1){
			gotoHere.transform.position = pos2.transform.position;
		}
		if(tracker == 2){
			gotoHere.transform.position = pos3.transform.position;
		}
		if(tracker == 3){
			gotoHere.transform.position = pos4.transform.position;
		}
		if(tracker == 4){
			gotoHere.transform.position = pos5.transform.position;
		}
		if(tracker == 5){
			gotoHere.transform.position = pos6.transform.position;
		}
		if(tracker == 6){
			gotoHere.transform.position = pos7.transform.position;
		}
		if(tracker == 7){
			gotoHere.transform.position = pos8.transform.position;
		}
		if(tracker == 8){
			gotoHere.transform.position = pos9.transform.position;
		}
		if(tracker == 9){
			gotoHere.transform.position = pos10.transform.position;
		}
		if(tracker == 10){
			gotoHere.transform.position = pos11.transform.position;
		}
		if(tracker == 11){
			gotoHere.transform.position = pos12.transform.position;
		}
		if(tracker == 12){
			gotoHere.transform.position = pos13.transform.position;
		}
		if(tracker == 13){
			gotoHere.transform.position = pos14.transform.position;
		}
		if(tracker == 14){
			gotoHere.transform.position = pos15.transform.position;
		}
		if(tracker == 15){
			gotoHere.transform.position = pos16.transform.position;
		}
		if(tracker == 16){
			gotoHere.transform.position = pos17.transform.position;
		}
		if(tracker == 17){
			gotoHere.transform.position = pos18.transform.position;
		}
		if(tracker == 18){
			gotoHere.transform.position = pos19.transform.position;
		}
		if(tracker == 19){
			gotoHere.transform.position = pos20.transform.position;
		}
		if(tracker == 20){
			gotoHere.transform.position = pos21.transform.position;
		}
		if(tracker == 21){
			gotoHere.transform.position = pos22.transform.position;
		}
		if(tracker == 22){
			gotoHere.transform.position = pos23.transform.position;
		}
		if(tracker == 23){
			gotoHere.transform.position = pos24.transform.position;
		}
		if(tracker == 24){
			gotoHere.transform.position = pos25.transform.position;
		}

	}

	IEnumerator OnTriggerEnter (Collider collision){
		if (collision.gameObject.tag == "CarAI00Desert") {
			this.GetComponent<BoxCollider> ().enabled = false;
			tracker += 1;
			if (tracker == 25) {
				tracker = 0;
			}
			yield return new WaitForSeconds (1);
			this.GetComponent<BoxCollider> ().enabled = true;
		
		}
	}
}

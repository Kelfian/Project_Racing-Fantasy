using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarChoice : MonoBehaviour {
	
	public GameObject c1Body;
	public GameObject c2Body;
	public GameObject c3Body;
	public GameObject c4Body;
	public int carImport;

	// Use this for initialization
	void Start () {
		carImport = CarSelector.carType;
		if(carImport == 1){
			c1Body.SetActive(true);
		}
		if(carImport == 2){
			c2Body.SetActive(true);
		}
		if(carImport == 3){
			c3Body.SetActive(true);
		}
		if(carImport == 4){
			c4Body.SetActive(true);
		}
	}

}

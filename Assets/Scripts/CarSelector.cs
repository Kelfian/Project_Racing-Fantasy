using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSelector : MonoBehaviour {

	public GameObject c1;
	public GameObject c2;
	public GameObject c3;
	public GameObject c4g;

	public int carSelected;

	// Use this for initialization
	void Start () {
		
	}
	
	public void loadC1(){
		c1.SetActive (true);
		c2.SetActive (false);
		c3.SetActive (false);
		c4g.SetActive (false);

		carSelected = 1;
	}

	public void loadC2(){
		c1.SetActive (false);
		c2.SetActive (true);
		c3.SetActive (false);
		c4g.SetActive (false);

		carSelected = 2;
	}

	public void loadC3(){
		c1.SetActive (false);
		c2.SetActive (false);
		c3.SetActive (true);
		c4g.SetActive (false);

		carSelected = 3;
	}

	public void loadC4g(){
		c1.SetActive (false);
		c2.SetActive (false);
		c3.SetActive (false);
		c4g.SetActive (true);

		carSelected = 4;
	}
}

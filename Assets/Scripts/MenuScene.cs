using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScene : MonoBehaviour {

	//public RectTransform menuContainer;
	public static int carType; //1 = oren 2 = yellow 3 = red 4 = GHAY
	//private Vector3 desiredMenuPosition;

	private void Update(){
	
		//menuContainer.anchoredPosition = Vector3.Lerp (menuContainer.anchoredPosition, desiredMenuPosition, 0.1f);
	}

	/*private void NavigateTo(int menuIndex){
		switch (menuIndex) {
		default:
		case 0:
			desiredMenuPosition = Vector3.zero;
			break;

		case 1:
			desiredMenuPosition = Vector3.left * 2100;
			break;

		//case 2:
		//	desiredMenuPosition = Vector3.right * 461;
		//	break;

		//case 3:
		//	desiredMenuPosition = Vector3.down * 266;
		//	break;
		}
	}*/

	public void orenCar(){
		carType = 1;
	}

	public void yellowCar(){
		carType = 2;
	}

	public void redCar(){
		carType = 3;
	}	

	public void gayCar(){
		carType = 4;
	}

	public void OnNextClick(){
	//	NavigateTo (1);
	}

	public void OnBackClick(){
	//	NavigateTo (0);
	}

	public void Back2MenuClick(){
		SceneManager.LoadScene ("MainMenu");
	}

	public void Back2MenuCarSel(){
		SceneManager.LoadScene ("carSelect");
	}

	public void Next2TrackSel(){
		SceneManager.LoadScene ("trackSelect");
	}

	public void desertClick(){
		SceneManager.LoadScene ("StageGurun");
	}

	public void snowClick(){
		SceneManager.LoadScene ("StageSalju");
	}

	public void volcanoClick(){
		SceneManager.LoadScene ("StageVolcano");
	}
		
}

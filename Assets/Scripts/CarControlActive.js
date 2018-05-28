var CarControl : GameObject;
var CarControlAI : GameObject;

function Start () {
	CarControl.GetComponent("CarUserControl").enabled = true;
	CarControlAI.GetComponent("CarAIControl").enabled = true;

}

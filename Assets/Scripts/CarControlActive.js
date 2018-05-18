var CarControl : GameObject;
var CarControlAI : GameObject;

function Start () {
	CarControl.GetComponent("CarController").enabled = true;
	CarControlAI.GetComponent("CarAIControl").enabled = true;

}

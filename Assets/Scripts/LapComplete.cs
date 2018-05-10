using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LapComplete : MonoBehaviour {

	public GameObject lapCompleteTrig;
	public GameObject halfLapTrig;

	public TextMeshProUGUI lapCounter;
    public TextMeshProUGUI bestTimeBox;

    [HideInInspector]
    public float bestRawTime;
    public static int LapsDone;

	private void OnTriggerEnter()
    {
		LapsDone += 1;
		bestRawTime = PlayerPrefs.GetFloat ("RawTime");
		if (TimeManager.rawTime <= bestRawTime)
        {
            bestTimeBox.text = string.Format("{0:00}:", TimeManager.minuteCount) + string.Format("{0:00}.", TimeManager.secondCount) + TimeManager.miliDisplay;
        }

		PlayerPrefs.SetInt ("MinSave", TimeManager.minuteCount);
		PlayerPrefs.SetInt ("SecSave", TimeManager.secondCount);
		PlayerPrefs.SetFloat ("MiliSave", TimeManager.miliCount);
		PlayerPrefs.SetFloat ("RawTime", TimeManager.rawTime);

		TimeManager.minuteCount = 0;
		TimeManager.secondCount = 0;
		TimeManager.miliCount = 0;
		TimeManager.rawTime = 0;
        
        lapCounter.text = "" + LapsDone;

		halfLapTrig.SetActive (true);
		lapCompleteTrig.SetActive (false);
	}

}

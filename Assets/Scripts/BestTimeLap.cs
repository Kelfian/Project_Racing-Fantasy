using UnityEngine;
using TMPro;

public class BestTimeLap : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI lapCounter;
    [SerializeField] private TextMeshProUGUI bestTimeBox;

    private static float bestRawTime;
    private static int lapsDone;

    //private static Vector3 halfLap;
    //private static Vector3 halfLapRotation;
    //private static Vector3 finishLap;
    //private static Vector3 finishLapRotation;

    //public static int LapsDone { get { return lapsDone; } set { lapsDone = value; } }
    //public float BestRawTime { get { return bestRawTime; } set { bestRawTime = value; } }

    private void Start()
    {
        //Load best lap time from PlayerPrefs.
        bestRawTime = PlayerPrefs.GetFloat ("RawTime");
        bestTimeBox.text = string.Format("{0:00}:", PlayerPrefs.GetInt("MinSave", 0)) +
            string.Format("{0:00}.", PlayerPrefs.GetInt("SecSave", 0))
            + PlayerPrefs.GetFloat("MiliSave", 0);

    }
    private void OnTriggerEnter()
    {
        //If new lap time is better than before.
		if (TimeManager.rawTime <= bestRawTime)
        {
            //Get the new raw time.
            bestRawTime = TimeManager.rawTime;
            //Set the best time box with the new one.
            bestTimeBox.text = string.Format("{0:00}:", TimeManager.minuteCount) +
                string.Format("{0:00}.", TimeManager.secondCount)
                + TimeManager.miliDisplay;
            //Save the new best lap time
            PlayerPrefs.SetInt ("MinSave", TimeManager.minuteCount);
            PlayerPrefs.SetInt ("SecSave", TimeManager.secondCount);
            PlayerPrefs.SetFloat ("MiliSave", TimeManager.miliCount);
            PlayerPrefs.SetFloat ("RawTime", TimeManager.rawTime);
        }

        //Reset lap time count
        TimeManager.minuteCount = 0;
        TimeManager.secondCount = 0;
        TimeManager.miliCount = 0;
        TimeManager.rawTime = 0;
        
        //Increment lap count then publish it.
        lapsDone += 1;
        lapCounter.text = lapsDone.ToString();

        //Deactivate this collider then enable other gameobject.
        GetComponent<BoxCollider>().enabled = false;
        transform.parent.GetChild(1).gameObject.SetActive(true);
    }
}

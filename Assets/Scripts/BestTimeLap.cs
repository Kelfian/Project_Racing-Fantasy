    using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BestTimeLap : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI lapCounter;
    [SerializeField] private TextMeshProUGUI bestTimeBox;

    private static float bestRawTime;
    private static int lapsDone = 0;

    //private static Vector3 halfLap;
    //private static Vector3 halfLapRotation;
    //private static Vector3 finishLap;
    //private static Vector3 finishLapRotation;

    //public static int LapsDone { get { return lapsDone; } set { lapsDone = value; } }
    //public float BestRawTime { get { return bestRawTime; } set { bestRawTime = value; } }

    private void Start()
    {
        //Load best lap time from PlayerPrefs.
        string rawTime = SceneManager.GetActiveScene().buildIndex.ToString();
        bestRawTime = PlayerPrefs.GetFloat (SceneManager.GetActiveScene().buildIndex.ToString() + " RawTime", 6000);
        bestTimeBox.text = string.Format("{0:00}:",
            PlayerPrefs.GetInt(SceneManager.GetActiveScene().buildIndex.ToString() + " MinSave", 5)) + string.Format("{0:00}.",
            PlayerPrefs.GetInt(SceneManager.GetActiveScene().buildIndex.ToString() + " SecSave", 0)) + string.Format("{0:0}",
            PlayerPrefs.GetFloat(SceneManager.GetActiveScene().buildIndex.ToString() + " MiliSave", 0));
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
            PlayerPrefs.SetInt (SceneManager.GetActiveScene().buildIndex.ToString() + " MinSave", TimeManager.minuteCount);
            PlayerPrefs.SetInt (SceneManager.GetActiveScene().buildIndex.ToString() + " SecSave", TimeManager.secondCount);
            PlayerPrefs.SetFloat (SceneManager.GetActiveScene().buildIndex.ToString() + " MiliSave", TimeManager.miliCount);
            PlayerPrefs.SetFloat (SceneManager.GetActiveScene().buildIndex.ToString() + " RawTime", TimeManager.rawTime);
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

        //If lap count = 2, then the game finished.
        if(lapsDone == 1)
        {
            transform.GetComponent<RaceFinish>().RaceFinished();
        }
    }
}

using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
    public static int minuteCount;
    public static int secondCount;
    public static float miliCount;
    public static float rawTime;
    public static string miliDisplay;
    private TextMeshProUGUI timeBox;

    private void Start()
    {
        timeBox = transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        miliCount += Time.deltaTime * 10;
        rawTime += Time.deltaTime;

        //Convert to Second after Milicount reach 10.
        if (miliCount >= 10)
        {
            miliCount = 0;
            secondCount += 1;
        }
        //Convert to Minute after Second reach 60.
        if (secondCount >= 60)
        {
            secondCount = 0;
            minuteCount += 1;
        }
    }
    private void LateUpdate()
    {
        miliDisplay = miliCount.ToString("F0");
        //Display the time count
        timeBox.text = string.Format("{0:00}:", minuteCount) + string.Format("{0:00}.", secondCount) + miliDisplay;
    }
}

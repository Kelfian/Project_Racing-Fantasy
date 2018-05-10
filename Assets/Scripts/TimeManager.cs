using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
    public TextMeshProUGUI timeBox;

	public static int minuteCount;
	public static int secondCount;
	public static float miliCount;
    public static float rawTime;
    public static string miliDisplay;
	
	void Update ()
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

        //Display the time count
        miliDisplay = miliCount.ToString("F0");
        timeBox.text = string.Format("{0:00}:", minuteCount) + string.Format("{0:00}.", secondCount) + miliDisplay;

        //Display the Second count.
        /*
		if (secondCount <= 9)
        {
			secondBox.text = "0" + secondCount + ".";
		}
        else
        {
			secondBox.text = "" + secondCount + ".";
		}
        
        //Display the Minute count.
		if (minuteCount <= 9)
        {
			minuteBox.text = "0" + minuteCount + ":";
		}
        else
        {
			minuteBox.text = "" + minuteCount + ":";
		}
        */

    }
}

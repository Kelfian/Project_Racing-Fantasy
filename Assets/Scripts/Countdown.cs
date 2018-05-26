using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;
using TMPro;

public class Countdown : MonoBehaviour {

	public AudioSource getReady;
	public AudioSource goAudio;
	public AudioSource levelMusic;
    [SerializeField] private CarUserControl playerCarControl;
    [SerializeField] private CarAIControl[] aiCarControl;
    private GameObject countDown;
	private TextMeshProUGUI countDownText;
	private TimeManager lapTimer;

	// Use this for initialization
	private void Start ()
    {
        lapTimer = transform.parent.GetChild(0).GetComponent<TimeManager>();
		StartCoroutine(CountStart());
        countDown = transform.GetChild(0).gameObject;
        countDownText = countDown.GetComponent<TextMeshProUGUI>();
	}

	IEnumerator CountStart(){
		//countdown
		yield return new WaitForSeconds (0.5f);
        countDownText.text = "3";
        countDown.SetActive(true);
		getReady.Play();
		yield return new WaitForSeconds (1);
        countDown.SetActive(false);
        countDownText.text = "2";
        countDown.SetActive(true);
        getReady.Play();
		yield return new WaitForSeconds (1);
        countDown.SetActive(false);
        countDownText.text = "1";
		getReady.Play();
        countDown.SetActive(true);
        yield return new WaitForSeconds (1);
        countDown.SetActive(false);
        goAudio.Play();
		yield return new WaitForSeconds (0.5f);
		levelMusic.Play();
		//StartLap.SetActive blabla dst

		//end of time freeze
		lapTimer.enabled = true;
        playerCarControl.enabled = true;
        for (int i = 0; i < aiCarControl.Length; i++)
        {
            aiCarControl[i].enabled = true;
        }
    }
}

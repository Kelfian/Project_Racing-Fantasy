using System.Collections;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;
using TMPro;

public class TextMessage : MonoBehaviour
{
    //Countdown purpose.
    private enum TextAnimation { Flip, FadeOut };
    [SerializeField] private CarUserControl playerCarControl;
    [SerializeField] private CarAIControl[] aiCarControl;
    [SerializeField] private AudioSource getReady;
    [SerializeField] private AudioSource goAudio;
    [SerializeField] private AudioSource levelMusic;
    [SerializeField] private TextAnimation textAnimation;
    private TimeManager lapTimer;

    //Core function references.
    private GameObject textObject;
    private Animator textAnimator;
    private TextMeshProUGUI messageText;
    private WaitForSeconds wait1s;

    private void Start ()
    {
        //Initialize core function references.
        textObject = transform.GetChild(0).gameObject;
        textAnimator = textObject.GetComponent<Animator>();
        messageText = textObject.GetComponent<TextMeshProUGUI>();

        //Countdown purpose
        lapTimer = transform.parent.GetChild(0).GetComponent<TimeManager>();
        wait1s = new WaitForSeconds(0.95f);

        textObject.SetActive(true);
        if (textAnimation == TextAnimation.FadeOut)
        {
            textAnimator.SetTrigger("FadeOut");
        }
        StartCoroutine(Countdown());
	}

	private IEnumerator Countdown(){
        for (int i = 3; i > 0; i--)
        {
		    getReady.Play();
            messageText.text = i.ToString();
            yield return wait1s;
        }
        messageText.text = "GO!";
        goAudio.Play();
        yield return new WaitForSeconds (0.5f);
        levelMusic.Play();
        textObject.SetActive(false);
        //Enable time lap and player & AI control.
		lapTimer.enabled = true;
        playerCarControl.enabled = true;
        for (int i = 0; i < aiCarControl.Length; i++)
        {
            aiCarControl[i].enabled = true;
        }
    }
}

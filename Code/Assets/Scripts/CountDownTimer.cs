using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    public float currentTime = 0;
    public float startTime = 10;
    [SerializeField] private Text countdownText;

    void Start()
    {
        // do this to reverse from countUp to countDown
        currentTime = startTime;
    }

    void Update()
    {
        // setting up 321 countdown
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;
            countdownText.gameObject.SetActive(false);
        }
    }
}

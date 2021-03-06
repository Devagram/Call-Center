using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClockScript : MonoBehaviour
{
    GameObject clockText;
    public bool winning = false;
    public float clockTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        winning = false;
        clockText = GameObject.Find("ClockText");
        clockText.GetComponent<UnityEngine.UI.Text>().text = "4:55PM";
    }

    // Update is called once per frame
    void Update()
    {
        clockTime += 1f * Time.deltaTime;


        if(clockTime >= 0 && clockTime <= 60)
        {
            Debug.Log("4:55");
            clockText.GetComponent<UnityEngine.UI.Text>().text = "4:55PM";
        }
        if (clockTime >= 60 && clockTime <= 120)
        {
            Debug.Log("4:56");
            clockText.GetComponent<UnityEngine.UI.Text>().text = "4:56PM";
        }
        if (clockTime >= 120 && clockTime <= 180)
        {
            Debug.Log("4:57");
            clockText.GetComponent<UnityEngine.UI.Text>().text = "4:57PM";
        }
        if (clockTime >= 180 && clockTime <= 240)
        {
            Debug.Log("4:58");
            clockText.GetComponent<UnityEngine.UI.Text>().text = "4:58PM";
        }
        if (clockTime >= 240 && clockTime <= 300)
        {
            Debug.Log("4:59");
            clockText.GetComponent<UnityEngine.UI.Text>().text = "4:59PM";
        }
        if (clockTime >= 300)
        {
            Debug.Log("5:00");
            clockText.GetComponent<UnityEngine.UI.Text>().text = "5:00PM";
            TimeIsUp(winning);
        }
    }

    private void TimeIsUp(bool win)
    {
        if(win == true)
        {
            Debug.Log("You Win");
            //Insert Scene Win
        }
        else
        {
            Debug.Log("You Lose");
            //Insert Scene TimeOut Loss
        }
    }
}

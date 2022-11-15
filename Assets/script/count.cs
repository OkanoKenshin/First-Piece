using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class count : MonoBehaviour
{
    public Text timeTexts;
    public Text CountText;
    float totalTime = 3;
    int retime;
    float countdown = 4f;
    int Count;

    //Start is called before the first frame update
    void Start()
    {

    }
    //Update is called once per frame
    void Update()
    {
        if (countdown >= 0)
            {
                countdown -= Time.deltaTime;
                Count = (int)countdown;
                CountText.text = Count.ToString();
            }
            if (countdown <= 0)
            {
                CountText.text = "";
                totalTime -= Time.deltaTime;
                retime = (int)totalTime;
                if (retime == 0)
                {
                    SceneManager.LoadScene("cover");
                }
            }
    }
}


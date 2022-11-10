using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class go : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //エスケープキーを入力したらtrue
        if (Input.GetKey(KeyCode.Return))
        {
            //押されたら画面譲渡
            SceneManager.LoadScene("SampleScene");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class transfer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //�G�X�P�[�v�L�[����͂�����true
        if (Input.GetKey(KeyCode.Escape))
        {
            //�����ꂽ���ʏ��n
            SceneManager.LoadScene("Menu");
        }
    }
}

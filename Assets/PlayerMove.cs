using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public float speed = 10.0f;
    private Rigidbody rb;
    private int count;
    public float time;
    public Text TimeText;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        time = 0.0f;
    }

    void Update()
    {
        var moveX = Input.GetAxis("Horizontal") * speed;
        var moveZ = Input.GetAxis("Vertical") * speed;
        rb.AddForce(moveX, 0.5f, moveZ);

        //3個のアイテムを取れていない間は実行
        if (count < 1)
        {
            time += Time.deltaTime;
            TimeText.text = time.ToString("F2");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            other.gameObject.SetActive(false);
            count++;
        }
    }
}
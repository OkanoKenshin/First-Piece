using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpPoint2 : MonoBehaviour
{
    public Vector3 pos;

    // ★ポイント
    private GameObject target;

    private void OnTriggerEnter(Collider other)
    {
        // ★ポイント
        // キャラクターコントローラをいったんオフにする。
        target = other.gameObject;
        target.GetComponent<CharacterController>().enabled = false;

        // ワープ発動
        other.gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z);

        // ★ポイント
        // 0.5秒後にキャラクターコントローラをオンにする。
        Invoke("ResetC", 0.5f);

    }

    // ★ポイント
    void ResetC()
    {
        target.GetComponent<CharacterController>().enabled = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpPoint2 : MonoBehaviour
{
    public Vector3 pos;

    // ���|�C���g
    private GameObject target;

    private void OnTriggerEnter(Collider other)
    {
        // ���|�C���g
        // �L�����N�^�[�R���g���[������������I�t�ɂ���B
        target = other.gameObject;
        target.GetComponent<CharacterController>().enabled = false;

        // ���[�v����
        other.gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z);

        // ���|�C���g
        // 0.5�b��ɃL�����N�^�[�R���g���[�����I���ɂ���B
        Invoke("ResetC", 0.5f);

    }

    // ���|�C���g
    void ResetC()
    {
        target.GetComponent<CharacterController>().enabled = true;
    }
}

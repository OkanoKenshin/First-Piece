using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform viewPoint;//�J�����̈ʒu�I�u�W�F�N�g
    public float mouseSensitivity = 3f;//���_�ړ��̑��x
    private Vector2 mouseInput;//���[�U�[�̃}�E�X���͂��i�[
    private float verticalMouseInput;//y���̉�]���i�[�@��]�𐧌�����������
    private Camera cam;//�J����


    private void Start()
    {
        //�ϐ��Ƀ��C���J�������i�[
        cam = Camera.main;
    }

    private void Update()
    {
        //��]�֐�
        PlayerRotate();
    }

    public void PlayerRotate()
    {
        //�ϐ��Ƀ��[�U�[�̃}�E�X�̓������i�[
        mouseInput = new Vector2(Input.GetAxisRaw("Mouse X") * mouseSensitivity,
            Input.GetAxisRaw("Mouse Y") * mouseSensitivity);

        //����]�𔽉f(transform.eulerAngles�̓I�C���[�p�Ƃ��Ă̊p�x���Ԃ����)
        transform.rotation = Quaternion.Euler
            (transform.eulerAngles.x,
            transform.eulerAngles.y + mouseInput.x, //�}�E�X��x���̓��͂𑫂�
            transform.eulerAngles.z);



        //�ϐ���y���̃}�E�X���͕��̐��l�𑫂�
        verticalMouseInput += mouseInput.y;

        //�ϐ��̐��l���ۂ߂�i�㉺�̎��_����j
        verticalMouseInput = Mathf.Clamp(verticalMouseInput, -60f, 60f);

        //�c�̎��_��]�𔽉f(-��t���Ȃ��Ə㉺���]���Ă��܂�)
        viewPoint.rotation = Quaternion.Euler
            (-verticalMouseInput,
            viewPoint.transform.rotation.eulerAngles.y,
            viewPoint.transform.rotation.eulerAngles.z);
    }

    //Update�֐����Ă΂ꂽ��Ɏ��s�����
    private void LateUpdate()
    {
        //�J�������v���C���[�̎q�ɂ���̂ł͂Ȃ��A�X�N���v�g�ňʒu�����킹��
        cam.transform.position = viewPoint.position;
        cam.transform.rotation = viewPoint.rotation;
    }
}
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform viewPoint;//カメラの位置オブジェクト
    public float mouseSensitivity = 3f;//視点移動の速度
    private Vector2 mouseInput;//ユーザーのマウス入力を格納
    private float verticalMouseInput;//y軸の回転を格納　回転を制限したいから
    private Camera cam;//カメラ


    private void Start()
    {
        //変数にメインカメラを格納
        cam = Camera.main;
    }

    private void Update()
    {
        //回転関数
        PlayerRotate();
    }

    public void PlayerRotate()
    {
        //変数にユーザーのマウスの動きを格納
        mouseInput = new Vector2(Input.GetAxisRaw("Mouse X") * mouseSensitivity,
            Input.GetAxisRaw("Mouse Y") * mouseSensitivity);

        //横回転を反映(transform.eulerAnglesはオイラー角としての角度が返される)
        transform.rotation = Quaternion.Euler
            (transform.eulerAngles.x,
            transform.eulerAngles.y + mouseInput.x, //マウスのx軸の入力を足す
            transform.eulerAngles.z);



        //変数にy軸のマウス入力分の数値を足す
        verticalMouseInput += mouseInput.y;

        //変数の数値を丸める（上下の視点制御）
        verticalMouseInput = Mathf.Clamp(verticalMouseInput, -60f, 60f);

        //縦の視点回転を反映(-を付けないと上下反転してしまう)
        viewPoint.rotation = Quaternion.Euler
            (-verticalMouseInput,
            viewPoint.transform.rotation.eulerAngles.y,
            viewPoint.transform.rotation.eulerAngles.z);
    }

    //Update関数が呼ばれた後に実行される
    private void LateUpdate()
    {
        //カメラをプレイヤーの子にするのではなく、スクリプトで位置を合わせる
        cam.transform.position = viewPoint.position;
        cam.transform.rotation = viewPoint.rotation;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Goscript : MonoBehaviour
{
//bool型の変数flyClickedを宣言する
    private bool flyClicked;
    void Start()
    {
//Start関数内では、flyClicked変数をfalseで初期化しておく
        flyClicked = false;
    }
    void Update()
    {
//Update関数内では、変数flyClickedがtrueであれば、「transform.Translate」を使って、ロケットを空に向けて飛ばす
        if (flyClicked == true)
        {
            transform.Translate((Vector3.left * Time.deltaTime * (transform.localScale.x * 2.0f)));
        }
    }
//Fly関数内ではClicked変数をtrueで初期化しておく
    public void Fly()
    {
        flyClicked = true;
    }
}



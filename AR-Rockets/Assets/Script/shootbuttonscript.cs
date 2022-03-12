using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootbuttonscript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Rocket;
    float force = 1000f;

    [SerializeField]
    [Tooltip("生成する範囲A")]
    private Transform rangeA;
    [SerializeField]
    [Tooltip("生成する範囲B")]
    private Transform rangeB;


    public void lauchButton() //Shootボタンが押されたら
    {
        // rangeAとrangeBのx座標の範囲内でランダムな数値を作成
        float x = Random.Range(rangeA.localPosition.x, rangeB.localPosition.x);
        // rangeAとrangeBのy座標の範囲内でランダムな数値を作成
        float y = Random.Range(rangeA.localPosition.y, rangeB.localPosition.y);
        // rangeAとrangeBのz座標の範囲内でランダムな数値を作成
        float z = 0;

        GameObject GoRocket = Instantiate(Rocket, new Vector3(x, y, z), Quaternion.Euler(x,y,z)) as GameObject;
        GoRocket.GetComponent<shootscript>().Shoot(Camera.main.transform.forward * force);
    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootbuttonscript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Rocket;
    float force = 1600f;

    [SerializeField]
    [Tooltip("生成する範囲A")]
    private Transform rangeA;
    [SerializeField]
    [Tooltip("生成する範囲B")]
    private Transform rangeB;

    [SerializeField]
    [Tooltip("生成する範囲C")]
    private Transform rangeC;
    [SerializeField]
    [Tooltip("生成する範囲D")]
    private Transform rangeD;


    public void lauchButton() //Shootボタンが押されたら
    {
        // rangeAとrangeBのx座標の範囲内でランダムな数値を作成
        float x = Random.Range(rangeA.localPosition.x, rangeB.localPosition.x);
        // rangeAとrangeBのy座標の範囲内でランダムな数値を作成
        float y = Random.Range(rangeA.localPosition.y, rangeB.localPosition.y);
        // rangeAとrangeBのz座標の範囲内でランダムな数値を作成
        float z = 0;//Random.Range(rangeC.localPosition.z, rangeD.localPosition.z);

        float rx = 0;
        float ry = 0;

        GameObject GoRocket = Instantiate(Rocket, new Vector3(x, y, z), Quaternion.Euler(Camera.main.transform.localEulerAngles.x,Camera.main.transform.localEulerAngles.y,z)) as GameObject;
        GoRocket.GetComponent<shootscript>().Shoot(Camera.main.transform.forward * force);
    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootbuttonclickscript : MonoBehaviour
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
        float x = Random.Range(rangeA.position.x, rangeB.position.x);
        // rangeAとrangeBのy座標の範囲内でランダムな数値を作成
        float y = Random.Range(rangeA.position.y, rangeB.position.y);
        // rangeAとrangeBのz座標の範囲内でランダムな数値を作成
        float z = 0;

        if (Input.GetMouseButtonDown(0))
        {
            GameObject GoRocket = Instantiate(Rocket, new Vector3(x, y, z), Quaternion.Euler(0, 0, 0)) as GameObject;
            //GoRocket.GetComponent<shootscript>().Shoot(GoRocket.transform.forward * force);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 worldDir = ray.direction;
            GoRocket.GetComponent<shootscript>().Shoot(
                worldDir.normalized * 3000);
        }
    }
}
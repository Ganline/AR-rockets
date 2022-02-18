using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraitRocketButton : MonoBehaviour
{
    public GameObject Rocket;


    public void lauchButton() //Shootボタンが押されたら
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject GoRocket = Instantiate(Rocket, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            //GoRocket.GetComponent<shootscript>().Shoot(GoRocket.transform.forward * force);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 worldDir = ray.direction;
            GoRocket.GetComponent<shootscript>().Shoot(
                worldDir.normalized * 3000);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootscript : MonoBehaviour
{

    public GameObject Rocket;
    float force = 100f;

    public void lauchButton() //Shootボタンが押されたら
    {
        GameObject GoRocket = Instantiate(Rocket, transform.position, transform.rotation) as GameObject;
        GoRocket.GetComponent<shootscript>().Shoot(GoRocket.transform.forward * force);

    }
    public void Shoot(Vector3 dir) //Ball飛ばす
    {
        GetComponent<Rigidbody>().AddForce(dir);
        Destroy(gameObject, 3);
    }

}

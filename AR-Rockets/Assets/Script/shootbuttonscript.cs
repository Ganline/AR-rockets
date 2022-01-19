using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootbuttonscript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Rocket;
    float force = 1000f;

    public void lauchButton() //Shootボタンが押されたら
    {
        GameObject GoRocket = Instantiate(Rocket, transform.position, Quaternion.Euler(0,0,0)) as GameObject;
        GoRocket.GetComponent<shootscript>().Shoot(GoRocket.transform.forward * force);
    
    }
}



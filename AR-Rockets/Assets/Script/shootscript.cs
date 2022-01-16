using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootscript : MonoBehaviour
{

    public void Shoot(Vector3 dir) //Ball飛ばす
    {
        GetComponent<Rigidbody>().AddForce(dir);
        Destroy(gameObject, 3);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootscript : MonoBehaviour
{

    public GameObject Explosion;

    public void Shoot(Vector3 dir) //Ball飛ばす
    {

        GetComponent<Rigidbody>().AddForce(dir);
        Destroy(gameObject, 2);
    }

    public void OnDestroy()
    {
        Debug.Log("OnDestroy");
        Vector3 set = this.gameObject.transform.position;
        Instantiate(Explosion, set, Quaternion.identity);
    }

}

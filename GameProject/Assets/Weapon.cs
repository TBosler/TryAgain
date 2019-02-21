using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int damage = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("collision");
        //Debug.Log(other.gameObject.name + " GOT HIT BY " + gameObject.name);
        //if(other.gameObject.)

    }
}

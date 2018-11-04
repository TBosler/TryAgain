using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Camera : MonoBehaviour {

    public GameObject player;

	// Use this for initialization

	// Update is called once per frame
	void LateUpdate () {

        transform.position = new Vector3(player.transform.position.x, 0, 0);
        Debug.Log(transform.position);
    }
}

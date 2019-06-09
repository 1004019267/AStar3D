using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    int speed = 2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.z<=-1||transform.position.z>=4)
        {
            speed = -speed;
        }
      
        transform.Translate(Vector3.forward*speed*Time.deltaTime);
	}
}

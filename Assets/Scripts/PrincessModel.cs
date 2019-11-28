using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrincessModel : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        //GetComponent<SpriteRenderer>().enabled = false;
	}
	
	// Update is called once per frame
    public void SpawnPrincess(Vector3 _position)
    {
        transform.position = _position;
       // GetComponent<SpriteRenderer>().enabled = true;
    }

    public void MovePrincess(Vector3 _position)
    {
        transform.position = _position;
    }

}

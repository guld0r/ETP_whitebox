using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouventCharacter : MonoBehaviour {

    private bool grounded;

	// Update is called once per frame
	void Update () {
        if (((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetKeyDown("space")) && grounded)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 450));
            grounded = false;

        }
    }


    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "plat")
        {
            grounded = true;
        }

    }
}

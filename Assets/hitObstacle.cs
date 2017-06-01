using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hitObstacle : MonoBehaviour {

    public Canvas deadCan;
    public Canvas uiCan;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "character")
        {
            Time.timeScale = 0.0f;
            uiCan.enabled = false;
            deadCan.enabled = true;
        }

    }
}

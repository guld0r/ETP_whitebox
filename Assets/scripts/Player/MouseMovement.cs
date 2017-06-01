using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour {

    public Vector3 target = new Vector3();
    public Vector3 direction = new Vector3();
    public Vector3 position = new Vector3();
    public float speed = 2.0f;
    bool paused = false;
    string home="house";
    string jeu = "leJeu";
    string miniJeu = "scene1";

    void Start()
    {
        
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "wall")
            speed = 3.0f;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "wall")
            speed = 2.0f;
        if (coll.gameObject.tag == "objet")
            Application.LoadLevel(miniJeu);
        if (coll.gameObject.tag == "door"&&Application.loadedLevelName=="leJeu")
            Application.LoadLevel(home);
        if (coll.gameObject.tag == "door" && Application.loadedLevelName == "house")
            Application.LoadLevel(jeu);
    }

    void Update()
    {
        if (paused == false)
        {
            position = gameObject.transform.position;
            if (Input.GetMouseButtonDown(0))
            {
                target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                target.z = 0;
            }
            if (target != Vector3.zero && (target - position).magnitude >= .06)
            {
                direction = (target - position).normalized;
                gameObject.transform.position += direction * speed * Time.deltaTime;
            }
            else
            {
                direction = Vector3.zero;
            }
        }
    }
}

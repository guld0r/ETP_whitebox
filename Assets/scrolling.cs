using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Parallax scrolling script that should be assigned to a layer
/// </summary>
public class scrolling : MonoBehaviour
{
    /// <summary>
    /// Scrolling speed
    /// </summary>
    public Vector2 speed = new Vector2(2, 2);

    /// <summary>
    /// Moving direction
    /// </summary>
    public Vector2 direction = new Vector2(-1, 0);

    public SpriteRenderer[] background;

    public Camera mainCam;

    public GameObject[] obstacles;

    public GameObject SpawZone;

    public float timeLeft = 30.0f;
    public float spawnOffsetTime;
    private bool spawn;

    void Update()
    {
        // Movement
        Vector3 movement = new Vector3(
          speed.x * direction.x,
          speed.y * direction.y,
          0);
        
        movement *= Time.deltaTime;
        transform.Translate(movement);

        mainCam.transform.position = new Vector3(transform.position.x+8.5f,0,-10);

        //Spawn script
        timeLeft -= Time.deltaTime;
        spawnOffsetTime += 1 * Time.deltaTime; ;

        if ((Mathf.FloorToInt(timeLeft) % 2 == 0 && spawn == false) && spawnOffsetTime >= 2)
        {
            spawn = true;
            spawnObstacle();
            spawnOffsetTime = 0;
        }
        
        
        if (background[0].IsVisibleFrom(Camera.main) == false)
        {
            SpriteRenderer swap;
            swap = background[0];

            background[0].transform.position = new Vector3(background[1].transform.position.x + background[1].bounds.size.x-0.5f, -4, 4);

            
            background[0] = background[1];
            background[1] = swap;
        }






    }

    public void spawnObstacle()
    {
        Instantiate(obstacles[Random.Range(0, obstacles.Length)], SpawZone.transform.position, Quaternion.identity);
        new WaitForSeconds(1);
        spawn = false;
    }

    
}
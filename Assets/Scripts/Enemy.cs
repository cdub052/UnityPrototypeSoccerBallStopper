using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3.0f;
    private Rigidbody enemyRb;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        //get reference of enemy rigid body
        enemyRb = GetComponent<Rigidbody>();
        //get reference of player
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //create variable for calculating enemy to follow player
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        //get enemy to follow player by subtracting player from enemy position
        enemyRb.AddForce( lookDirection * speed);

        //if statement to destroy enemies if they fall off the map
        if(transform.position.y < -10)
        {
            //destroy enemy
            Destroy(gameObject);
        }
    }
}

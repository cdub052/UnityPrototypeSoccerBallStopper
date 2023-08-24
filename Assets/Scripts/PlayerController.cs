using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // rigid body reference
    private Rigidbody playerRb;
    private GameObject focalPoint;
    public bool hasPowerup = false;
    private float powerUpKnockBack = 15.0f;
    public GameObject powerUpIndicator;
    public float speed = 5f;
   private Vector3 indicatorOffset = new Vector3(0, .5f, 0);

    // Start is called before the first frame update
    void Start()
    {
        //get rigidbody reference from components
        playerRb = GetComponent<Rigidbody>();
        //get reference to focal point object
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        // get player movement for up an down arrow keys
        float verticalInput = Input.GetAxis("Vertical");
        //allow player to move 
        playerRb.AddForce(focalPoint.transform.forward * speed * verticalInput);
        
    //make power up indicator follow player
    powerUpIndicator.transform.position = transform.position - indicatorOffset;
    }
    //on trigger enter method to check collitions
    private void OnTriggerEnter(Collider other)
    {

        // destroy powerup game object
        if (other.CompareTag("PowerUp"))
        {
            //set has power up to true after collision
            hasPowerup = true;
            Destroy(other.gameObject);
            //use coroutine for timer
            StartCoroutine(PowerUpCountDownRoutine());
            //set power up indicator to true
            powerUpIndicator.SetActive(true);
        }
    }

    //coroutine to have timer for power up
    IEnumerator PowerUpCountDownRoutine()
    {
        //set 7 second timer 
        yield return new WaitForSeconds(7);
        //after timer set power up to false
        hasPowerup = false;
        //set power up indicator to false
        powerUpIndicator.SetActive(false);
    }

    //on collision enter method to see if player collided with enemy after power up was equipted
    private void OnCollisionEnter(Collision collision)
    {
        //if statement to check if player collided with enemy after power up was equipted
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            //get rigidbody of enemy to apply knock back
           Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            //get position of knock back
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            //add force to knock back
            enemyRb.AddForce(awayFromPlayer * powerUpKnockBack, ForceMode.Impulse );

            //return a text in console
            Debug.Log("Collision with: " + collision.gameObject + " with gameObject set to " + hasPowerup);
        }
    }

}

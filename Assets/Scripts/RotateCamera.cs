using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    //create rotate variable
    public float rotateCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //get horizontal input from player
        float horizontalInput = Input.GetAxis("Horizontal");
        
        //get horizontal movement
        transform.Rotate(Vector3.up * rotateCamera * horizontalInput * Time.deltaTime);
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;

}
public class PlayerController : MonoBehaviour {
    public Rigidbody rb;
    public float speed;
    public float tilt;
    public Boundary boundary;

    public GameObject shot;
    public Transform shotSpawn;
    public AudioSource audioSource;
    public float fireRate;
    private float nextFire;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

    }
    private void Update()
    {
        if (Input.GetKeyDown("space") && Time.time > nextFire)
        {
           
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            audioSource.Play();
        }
    }
        private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.velocity = movement * speed;

        rb.position = new Vector3(Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            0.0f, 
            Mathf.Clamp(rb.position.z,boundary.zMin,boundary.zMax)
            );
        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }
}

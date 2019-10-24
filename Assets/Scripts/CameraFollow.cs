﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector2 currentVelocity;
    [SerializeField]
    private GameObject player;
    [Range(0,2)]
    public float smoothTimeY;
    [Range(0,2)]
    public float smoothTimeX;
    public bool boundaries;
    public Vector3 minCamPos;
    public Vector3 maxCamPos;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float posX =  Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref currentVelocity.x, smoothTimeX);
        float posY =  Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref currentVelocity.y, smoothTimeY);

        transform.position = new Vector3(posX, posY, transform.position.z);
        
        if (boundaries) {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCamPos.x, maxCamPos.x), 
            Mathf.Clamp(transform.position.y, minCamPos.y, maxCamPos.y),
            Mathf.Clamp(transform.position.z, minCamPos.z, maxCamPos.z));
        }
    }
}

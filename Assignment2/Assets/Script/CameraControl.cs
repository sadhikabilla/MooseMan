﻿using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

    public GameObject player;
    private Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.rotation = player.transform.rotation;
        transform.position = player.transform.position + offset;

	}
}

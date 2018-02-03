using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
    private Vector3 offset;

	// Use this for initialization
	void Start () {

        offset = transform.position - player.transform.position;
	}
	
	// Guranteed to run after all items have been processed. (We know absolutely that the player has already moved this frame.)
	void LateUpdate () {

        transform.position = player.transform.position + offset;
	}
}

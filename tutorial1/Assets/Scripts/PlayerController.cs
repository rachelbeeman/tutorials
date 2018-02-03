using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text CountText;
    public Text WinText;

    private Rigidbody rb;
    private int count;


    void Start() {

        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        WinText.text = "";
    }

    // Update is called once per frame (before rendering the frame)
    void Update () {
		
	}

    // FixedUpdate is called before performing any physics calculations
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        rb.AddForce(movement * speed);
        
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            count++;
            if (count>=12)
            {
                WinText.text = "You win!";
            }

            SetCountText();
            other.gameObject.SetActive(false);
        }
    }

    void SetCountText()
    {
        CountText.text = "Count: " + count.ToString();
    }
}

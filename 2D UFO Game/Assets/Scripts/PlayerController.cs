using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float Speed;
    public Text CountText;
    public Text WinText;

    private Rigidbody2D rb2d;
    private int count;

    // Use this for initialization
	void Start () {

        rb2d = GetComponent<Rigidbody2D>();
        Speed = 10;
        count = 0;
        SetCountText();
        WinText.text = "";
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rb2d.AddForce(movement * Speed);

    }

   void OnTriggerEnter2D(Collider2D other)
   {
        if (other.gameObject.CompareTag ("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
            if (count >= 12)
            {
                WinText.text = "You Win!";
            }
        }
   }

   void SetCountText()
    {
        CountText.text = "Count: " + count.ToString();
    }
}

using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObj;
    
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObj.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.SetText("Count: "+count.ToString());
        if (count == 12)
            winTextObj.SetActive(true);
    }

    private void FixedUpdate()
    {
        rb.AddForce(new Vector3(movementX, 0.0f, movementY) * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GameObject().CompareTag("PickUp"))
        {
            other.GameObject().SetActive(false);
            count++;
            SetCountText();
        }
    }
}

using UnityEngine;
using UnityEngine.InputSystem;

public class FlyingScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float strength = 5f;
    public LogicScript logic;
    public bool birdIsAlive = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame == true && birdIsAlive == true) // to == true tam nemusi byt dal som to tam pre prehladnost
        {
            myRigidbody.linearVelocity = Vector2.up * strength;
        }
        if (Mathf.Abs(transform.position.y) >= 15)
        {
            logic.gameOver();
            birdIsAlive = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }
}

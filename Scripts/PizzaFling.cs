using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaFling : MonoBehaviour
{
    Rigidbody2D rb;

    public float flingSpeed = 2.5f;
    public float rotationSpeed = 2.0f;
    public Sprite pizzaBox;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2 (flingSpeed, 0);
        gameObject.transform.Rotate(0, 0, rotationSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerInteract pizzaCheck = collision.GetComponent<PlayerInteract>();
        if (collision)
        {
            if (collision.CompareTag("Player") && pizzaCheck.heldPizza[4] == null)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.GetComponent<CircleCollider2D>().enabled = false;
                pizzaCheck.heldPizza[4] = gameObject;
                collision.GetComponent<PlayerMovement>().moveSpeed -= 0.5f;
                rotationSpeed = 0f;
                flingSpeed = 0f;

                FindObjectOfType<AudioManager>().Play("PizzaPickup");
            }
            else if (collision.CompareTag("Player") && pizzaCheck.heldPizza[3] == null && pizzaCheck.heldPizza[4] != null)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.GetComponent<CircleCollider2D>().enabled = false;
                pizzaCheck.heldPizza[3] = gameObject;
                collision.GetComponent<PlayerMovement>().moveSpeed -= 0.5f;
                rotationSpeed = 0f;
                flingSpeed = 0f;

                FindObjectOfType<AudioManager>().Play("PizzaPickup");
            }
            else if (collision.CompareTag("Player") && pizzaCheck.heldPizza[2] == null && pizzaCheck.heldPizza[3] != null)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.GetComponent<CircleCollider2D>().enabled = false;
                pizzaCheck.heldPizza[2] = gameObject;
                collision.GetComponent<PlayerMovement>().moveSpeed -= 0.5f;
                rotationSpeed = 0f;
                flingSpeed = 0f;

                FindObjectOfType<AudioManager>().Play("PizzaPickup");
            }
            else if (collision.CompareTag("Player") && pizzaCheck.heldPizza[1] == null && pizzaCheck.heldPizza[2] != null)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.GetComponent<CircleCollider2D>().enabled = false;
                pizzaCheck.heldPizza[1] = gameObject;
                collision.GetComponent<PlayerMovement>().moveSpeed -= 0.5f;
                rotationSpeed = 0f;
                flingSpeed = 0f;

                FindObjectOfType<AudioManager>().Play("PizzaPickup");
            }
            else if (collision.CompareTag("Player") && pizzaCheck.heldPizza[0] == null && pizzaCheck.heldPizza[1] != null)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.GetComponent<CircleCollider2D>().enabled = false;
                pizzaCheck.heldPizza[0] = gameObject;
                collision.GetComponent<PlayerMovement>().moveSpeed -= 0.5f;
                rotationSpeed = 0f;
                flingSpeed = 0f;

                FindObjectOfType<AudioManager>().Play("PizzaPickup");
            }
            if (collision.CompareTag("Trash"))
            {
                Destroy(gameObject);
            }

            if (pizzaCheck.heldPizza == null && collision)
            {
                CircleCollider2D collider = gameObject.GetComponent<CircleCollider2D>();
                collider.enabled = false;
            }
        }
    }
}

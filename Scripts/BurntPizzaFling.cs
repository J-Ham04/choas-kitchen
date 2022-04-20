using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurntPizzaFling : MonoBehaviour
{
    Rigidbody2D rb;

    public float flingSpeed = 2.5f;
    public float rotationSpeed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(flingSpeed, 0);
        gameObject.transform.Rotate(0, 0, rotationSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerInteract pizzaCheck = collision.GetComponent<PlayerInteract>();
        if (collision)
        {
            if (collision.CompareTag("Player") && pizzaCheck.heldPizza[0] == null)
            {
                pizzaCheck.gameManager.score -= 1;
                pizzaCheck.gameManager.gameTimer -= 2;
                Destroy(gameObject);
            }

            if (collision.CompareTag("Trash"))
            {
                Destroy(gameObject);
            }
        }
    }
}

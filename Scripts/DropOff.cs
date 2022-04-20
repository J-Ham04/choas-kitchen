using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOff : MonoBehaviour
{
    public GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerInteract playerInteract = collision.GetComponent<PlayerInteract>();
            if(playerInteract.heldPizza[4] != null)
            {
                gameManager.score += 1;
                gameManager.gameTimer += 1;
                collision.GetComponent<PlayerMovement>().moveSpeed = 5;
                FindObjectOfType<AudioManager>().Play("PizzaDropOff");
            }
            if (playerInteract.heldPizza[3] != null)
            {
                gameManager.score += 1;
                gameManager.gameTimer += 1;
                collision.GetComponent<PlayerMovement>().moveSpeed = 5;
            }
            if (playerInteract.heldPizza[2] != null)
            {
                gameManager.score += 1;
                gameManager.gameTimer += 1;
                collision.GetComponent<PlayerMovement>().moveSpeed = 5;
            }
            if (playerInteract.heldPizza[1] != null)
            {
                gameManager.score += 1;
                gameManager.gameTimer += 1;
                collision.GetComponent<PlayerMovement>().moveSpeed = 5;
            }
            if (playerInteract.heldPizza[0] != null)
            {
                gameManager.score += 3;
                gameManager.gameTimer += 1;
                collision.GetComponent<PlayerMovement>().moveSpeed = 5;
            }

            Destroy(playerInteract.heldPizza[0]);
            Destroy(playerInteract.heldPizza[1]);
            Destroy(playerInteract.heldPizza[2]);
            Destroy(playerInteract.heldPizza[3]);
            Destroy(playerInteract.heldPizza[4]);

        }
    }
}

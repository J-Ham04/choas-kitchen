using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public Transform firePoint;
    public GameManager gameManager;
    public GameObject[] heldPizza;

    // Update is called once per frame
    void Update()
    {
        if (heldPizza[4] != null)
        {
            heldPizza[4].transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0);
            gameManager.pizzaUI[0].sprite = gameManager.pizza;
        }
        else gameManager.pizzaUI[0].sprite = gameManager.noPizza;
        if (heldPizza[3] != null)
        {
            heldPizza[3].transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0);
            gameManager.pizzaUI[1].sprite = gameManager.pizza;
        }
        else gameManager.pizzaUI[1].sprite = gameManager.noPizza;
        if (heldPizza[2] != null)
        {
            heldPizza[2].transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0);
            gameManager.pizzaUI[2].sprite = gameManager.pizza;
        }
        else gameManager.pizzaUI[2].sprite = gameManager.noPizza;
        if (heldPizza[1] != null)
        {
            heldPizza[1].transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0);
            gameManager.pizzaUI[3].sprite = gameManager.pizza;
        }
        else gameManager.pizzaUI[3].sprite = gameManager.noPizza;
        if (heldPizza[0] != null)
        {
            heldPizza[0].transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0);
            gameManager.pizzaUI[4].sprite = gameManager.pizza;
        }
        else gameManager.pizzaUI[4].sprite = gameManager.noPizza;
    }
}

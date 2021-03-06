﻿/*  The standard script for collecting an item
 *  Depending on what type of collectible it is, it will do various things for the player
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Determines what kind of function this collectible does
public enum CollectibleType
{
    HEALTH,
    LIVES
}

public class Collectible : MonoBehaviour {

	[Header("General Variables")]
    public CollectibleType typeOfCollectible;

    [Range(1f,100f)]
    public float amount;

    // Makes sure the amount is a resonable amount depending on the Collectible Type
	private void OnValidate()
	{
        if(typeOfCollectible == CollectibleType.LIVES)
        {
            // If the type if lives, we will ALWAYS make sure the value of this will be 1
            amount = 1;
        }
	}

	// When the player runs into this, they will collect this
	private void OnTriggerEnter2D(Collider2D collision)
	{
        if(collision.gameObject.tag == "Player")
        {
            PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();
            CollectCollectible(player);
        }
	}

    // Collect the collectible and deactivate it
    public void CollectCollectible(PlayerHealth player)
    {
        if(gameObject.activeInHierarchy == true)
        {
            // Dependin on the collectible's function, we do various things
            switch(typeOfCollectible)
            {
                case CollectibleType.HEALTH:
                    player.RestoreHealth(amount);
                    break;
                case CollectibleType.LIVES:
                    player.numbOfLives += (int)amount;
                    break;
            }
            gameObject.SetActive(false);
        }
    }
}

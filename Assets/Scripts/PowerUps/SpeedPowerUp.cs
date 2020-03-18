using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    public float duration = 10f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Destroy the game object
            Destroy(gameObject);

            // If it's the player, double their speed
            TankMovement tankMovement = other.GetComponent<TankMovement>();
            if (tankMovement != null)
            {
                tankMovement.doubleSpeedTimer = duration;
            }
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
    
    }
}

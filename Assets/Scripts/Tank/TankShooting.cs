using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankShooting : MonoBehaviour
{
    // Prefab of a shell
    public Rigidbody m_Shell;
    // A child of the tank where the shells are spawned
    public Transform m_FireTransform;
    // The force given to the shell when firing
    public float m_LaunchForce = 30f;

    public int numShells;
    public int maxShells = 6;
    public float reloadTime = 2;
    public float reloadTimer;

    public Text shellCounter;
    public Image reloadClock;

    private void Start()
    {
        numShells = 6;
    }

    // Update is called once per frame
    private void Update()
    {
        // TO DO!!  Later on, we will check with the 'Game Manager' to
        // make sure the game isn't over

        if (Input.GetButtonUp("Fire1"))
        {
            Fire();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            // Start a countdown for the next reload
            reloadTimer = reloadTime;
        }

        if (reloadTimer > 0)
        {
            // Count down
            reloadTimer -= Time.deltaTime;
            // When we hit zero, reload
            if (reloadTimer <= 0)
            {
                numShells = maxShells;
            }
        }

        if (shellCounter)
        {
            shellCounter.text = numShells.ToString() + "/" + maxShells.ToString();
        }

        if (reloadClock)
        {
            reloadClock.fillAmount = reloadTimer / reloadTime;
        }
    }

    private void Fire()
    {
        // If we don't have any shells left, don't fire!

        if (numShells <= 0)
            return;

        // Use up a shell
        numShells--;

        // Create an instance of the shell and store a reference to its Rigidbody
        Rigidbody shellInstance = Instantiate(m_Shell,
                                   m_FireTransform.position,
                                   m_FireTransform.rotation) as Rigidbody;

        // Set the shell's velocity to the launch force in the fire
        // position's forward position
        shellInstance.velocity = m_LaunchForce * m_FireTransform.forward;
    }
}

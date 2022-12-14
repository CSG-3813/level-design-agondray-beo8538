using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        UnlockMouse();

        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //When Player gets damage from Enemies
        if (Input.GetKeyDown(KeyCode.T)){
            TakeDamage(20);
        }
    }

    void UnlockMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    void Healing(int health)
    {
        currentHealth += health;
        healthBar.SetHealth(currentHealth);
    }
}

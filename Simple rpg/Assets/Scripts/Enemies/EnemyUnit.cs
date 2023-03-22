using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class for the enemies. 
/// Contains common values such as HP, armour, experience. 
/// Contains common functions such as receiving damage. 
/// </summary>
public abstract class EnemyUnit : MonoBehaviour
{
    // Common enemy stats. 
    [Header("Stats")]

    [SerializeField] private int maxHealth;     // Health value. 
    private int currentHealth;                  // Current health value. If below or equal to 0, you are dead.

    [SerializeField] private int armourRate;    // Reduces incoming damage.
    
    [SerializeField] private int expPoints;     // How much exp player gains.

    // Enemy initialization logic.
    protected virtual void Init()
    {
        currentHealth = maxHealth;
    }

    // Enemy death logic.
    private void Die()
    {
        Debug.Log("Enemy has died and yielded " + expPoints + " exp points.");

        Destroy(this.gameObject);
    }

    // How enemy receives damage.
    public void ReceiveDamage(int incomingDamage)
    {
        // Reduce damage.
        int finalDamage = incomingDamage - armourRate;

        if (finalDamage < 0)
        {
            finalDamage = 0;
        }

        if (finalDamage <= 0)
        {
            // Damage was absorbed so we dont need to recalculate hp.
            Debug.Log("Damage was absorbed!");
            return;
        }
        else
        {
            // Recalculate health.
            currentHealth -= finalDamage;

            // Enemy has died.
            if( currentHealth <= 0)
            {
                Die();
                return;
            }

            Debug.Log("Health left: " + currentHealth);
        }
    }
}

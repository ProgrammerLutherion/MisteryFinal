using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Enemy : MonoBehaviour
{
    [SerializeField] 
    protected int Health, AttackDamage, Armor;

    public int getHealth()
    {
        return Health;
    }
    public int getAttackDamage()
    {
        return AttackDamage;
    }
    public int getArmor()
    {
        return Armor;
    }

    public void takeDamage(int damage) {
        if (Health - damage <= 0)
        {
            Health = 0;
            FindObjectOfType<AudioManager>().Play("Hit");
            Destroy(gameObject);
        }
        else
        {
            Health -= damage;
            FindObjectOfType<AudioManager>().Play("Hit");
        }
            
    }
}



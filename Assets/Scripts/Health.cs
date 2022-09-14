using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [Header("Health Settings")]
    [SerializeField] int _maxHealth = 3;
    [SerializeField] int _startingHealth = 3;
    [SerializeField] int _currentHealth;

    [Header("Health References")]
    [SerializeField] ParticleSystem _deathVFX = null;
    [SerializeField] AudioClip _deathSFX = null;

    private void Awake()
    {
        _currentHealth = _startingHealth;
    }

    public void TakeDamage(int amount)
    {
        DecreaseHealth(amount);
    }

    #region Modify Current Health
    public void IncreaseHealth(int healAmount)
    {
        _currentHealth += healAmount;

        if (_currentHealth >= _maxHealth)
        {
            _currentHealth = _maxHealth;
        }

        Debug.Log("Healed " + this.gameObject.name + " for " + healAmount + ". Current health: " + _currentHealth);
    }

    public void DecreaseHealth(int damageAmount)
    {
        _currentHealth -= damageAmount;
        Debug.Log("Hurt " + this.gameObject.name + " for " + damageAmount + ". Current health: " + _currentHealth);

        if (_currentHealth <= 0)
        {
            Kill();
        }
    }
    #endregion

    public void Kill()
    {
        Debug.Log(this.gameObject.name + " has died...");

        if (_deathVFX != null)
        {
            Instantiate(_deathVFX, transform.position, Quaternion.identity);
        }

        if (_deathSFX != null)
        {
            AudioHelper.PlayClip2D(_deathSFX, 1f);
        }

        Destroy(this.gameObject);
    }
}

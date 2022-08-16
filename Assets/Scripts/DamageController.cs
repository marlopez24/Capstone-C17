using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamageController : MonoBehaviour
{
    [SerializeField]
    private int monsterDamage;

    [SerializeField]
    private HealthController _healthController;


    private void Awake()
    {
        _healthController = FindObjectOfType<HealthController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            FindObjectOfType<AudioManager>().Play("PlayerDeath");

            Damage();
        }
    }

    void Damage()
    {
        _healthController.playerHealth = _healthController.playerHealth - monsterDamage;
        _healthController.UpdateHealth();

        if(_healthController.playerHealth <= 0)
        {
            gameObject.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
        }

    }
}

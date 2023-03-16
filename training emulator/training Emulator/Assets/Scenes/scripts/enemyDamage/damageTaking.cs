using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageTaking : MonoBehaviour
{
    public int enemyHealth;
    public static damageTaking instance;
    // Start is called before the first frame update
    void Awake()
    {
        enemyHealth = 100;
    }
    private void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        print(enemyHealth);
        if (enemyHealth <= 0)
            print("dead");
    }
    void TakeDamage(int damage)
    {

    }
}

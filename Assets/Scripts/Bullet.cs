using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public float moveSpeed;
    public float lifetime; // in seconds

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }
    private void Update()
    {
        transform.position += transform.forward * Time.deltaTime * moveSpeed;
    }

    private void OnTriggerEnter(Collider collider) 
    {
        if (collider.gameObject.CompareTag("Enemy"))
        {
            // enemy take damage
            collider.GetComponent<EnemyController>().TakeDamage(damage);
            
            Destroy(gameObject);
        }
    }
}

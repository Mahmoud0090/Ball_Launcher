using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] ParticleSystem enemyDeathParticle;
    [SerializeField] private float enemyDeathDelay;

    private void Start()
    {
        //enemyDeathParticle.transform.position = gameObject.transform.position;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Ball")
        {
            enemyDeathParticle.Play();
            StartCoroutine(EnemyDeath());
        }
    }

    IEnumerator EnemyDeath()
    {
        yield return new WaitForSeconds(enemyDeathDelay);
        Destroy(gameObject);
    }
}

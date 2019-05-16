using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deadFx;
    [SerializeField] Transform save;
    [SerializeField] int socreNumber;
    [SerializeField] int health = 3;
    ScoreBoard scoreBoard;

    void Start()
    {
        AddBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void AddBoxCollider()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnParticleCollision(GameObject other)
    {
        scoreBoard.ScoreHit(socreNumber);
        health = health - 1;
        if (health <= 0)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        GameObject fx = Instantiate(deadFx, transform.position, Quaternion.identity);
        fx.transform.parent = save;
        Destroy(gameObject);
    }
}

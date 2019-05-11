using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deadFx;
    [SerializeField] Transform save;
    void Start()
    {
        Collider boxCollider = gameObject.AddComponent<BoxCollider>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnParticleCollision(GameObject other)
    {
        GameObject fx = Instantiate(deadFx, transform.position, Quaternion.identity);
        fx.transform.parent = save;
        Destroy(gameObject);
    }
}

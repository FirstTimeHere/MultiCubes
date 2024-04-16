using System.Collections.Generic;
using UnityEngine;

public class Exlplosion : MonoBehaviour
{
    [SerializeField] private float _explosionForce;
    [SerializeField] private ParticleSystem _effect;
    [SerializeField] private ClickHandler _clickObject;

    private void OnEnable()
    {
        _clickObject.Clicked += OnExplode;
    }

    private void OnDisable()
    {
        _clickObject.Clicked -= OnExplode;
    }

    private void OnExplode()
    {
        Explode();
        Instantiate(_effect, transform.position, transform.rotation);
    }

    private void Explode()
    {
        foreach (Rigidbody explodableObject in GetExplodableObjects())
        {
            explodableObject.AddExplosionForce(_explosionForce, transform.position, transform.localScale.x);
        }
    }

    private List<Rigidbody> GetExplodableObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, transform.localScale.x);

        List<Rigidbody> explosionObjects = new();

        foreach (Collider hit in hits)
        {
            if (hit.attachedRigidbody != null)
            {
                explosionObjects.Add(hit.attachedRigidbody);
            }
        }

        return explosionObjects;
    }
}

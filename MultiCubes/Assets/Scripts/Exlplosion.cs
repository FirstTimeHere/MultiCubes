using System.Collections.Generic;
using UnityEngine;

public class Exlplosion : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    [SerializeField] private ParticleSystem _effect;
    [SerializeField] private InteractionWithObject _clickObject;

    private void OnEnable()
    {
        _clickObject.ClickedObject += ExplodeWithEvent;
    }

    private void OnDisable()
    {
        _clickObject.ClickedObject -= ExplodeWithEvent;
    }

    private void ExplodeWithEvent()
    {
        Explode();
        Instantiate(_effect,transform.position, transform.rotation);
    }

    private void Explode()
    {
        foreach (Rigidbody explodableObject in GetExplodableObject())
        {
            explodableObject.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }
    }

    private List<Rigidbody> GetExplodableObject()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

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

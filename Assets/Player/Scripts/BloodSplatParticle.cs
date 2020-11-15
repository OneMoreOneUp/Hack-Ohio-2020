using System.Collections.Generic;
using UnityEngine;

public class BloodSplatParticle : MonoBehaviour
{
    public ParticleSystem m_particleSystem;
    public GameObject bloodSplatPrefab;
    public Transform bloodParent;
    private List<ParticleCollisionEvent> collisionEvents = new List<ParticleCollisionEvent>();

    private void OnParticleCollision(GameObject other)
    {
        ParticlePhysicsExtensions.GetCollisionEvents(m_particleSystem, other, collisionEvents);

        foreach (ParticleCollisionEvent collisionEvent in collisionEvents)
        {
            GameObject bloodSplat = Instantiate(bloodSplatPrefab, collisionEvent.intersection, Quaternion.identity) as GameObject;
            bloodSplat.transform.SetParent(bloodParent, true);
            BloodSplat bloodSplatScript = bloodSplat.GetComponent<BloodSplat>();
            bloodSplatScript.Initialize();
        }
    }
}

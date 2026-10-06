using UnityEngine;

public class WallhitEffect : MonoBehaviour
{
    public ParticleSystem effect;

    private void OnCollisionEnter(Collision collision)
    {
        if (effect == null) return;

        ContactPoint contact = collision.contacts[0];

        effect.transform.position = contact.point;
        effect.transform.rotation = Quaternion.LookRotation(contact.normal);

        effect.Play();
    }
}

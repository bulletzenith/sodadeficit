using UnityEngine;

public class Entities : MonoBehaviour
{
    public float Health = 50f;

    public void TakeDamage(float amount)
    {
        Health -= amount;
        Debug.Log("Health of " + gameObject.name + ":" + Health);
        if (Health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        // TODO: particle animation of blood splatter
        Destroy(gameObject);
    }
}

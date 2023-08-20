using UnityEngine;

public class Gun : MonoBehaviour
{
    public float Damage = 10f;
    public float Range = 100f;
    public float FireRate = 10f;

    public int Ammo = 30;
    public int Clip = 90;
    public int MaxAmmo = 30;

    public Camera cam;
    public ParticleSystem particles;
    public AudioSource noammo;
    public AudioSource gunshot;
    public AudioClip shot;

    private float nextTimetoFire = 0f;
    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time >= nextTimetoFire)
        {
            nextTimetoFire = Time.time + 1f / FireRate;
            Shoot();
        }
        if(Input.GetButtonDown("Reload"))
        {
            if (Clip > 0)
            {
                //TODO: reload animation
                Clip -= MaxAmmo - Ammo;
                Ammo = MaxAmmo;
            } 
            else
            {
                noammo.Play();
            }
        }
    }

    void Shoot()
    {   
        if (Ammo > 0)
        {
            //TODO: shooting animation
            particles.Play();
            gunshot.PlayOneShot(shot);
            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, Range))
            {
                Entities entity = hit.transform.GetComponent<Entities>();
                if (entity != null)
                {
                    entity.TakeDamage(Damage);
                }
            }
            Ammo -= 1;
        } else
        {
            //TODO: play no ammo sound
            noammo.Play();
        }
    }   
}

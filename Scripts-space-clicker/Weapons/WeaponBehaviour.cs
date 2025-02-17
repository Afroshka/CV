using UnityEngine;

public class WeaponBehaviour : MonoBehaviour
{
    private Target target;

    [SerializeField] private GameObject collisionParticle;
    [SerializeField] private GameObject doubleDamageParticle;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip deathClip;

    public double damage;
    public uint speed;

    private float volume;
    private float deathVolume;

    private void Start()
    {
        ParticleDoubleDamage();
        audioSource.volume = Volume();
    }

    private void Update()
    {
        MoveForward();
    }

    public void SetSettings(uint weaponSpeed, double weaponDamage)
    {
        speed = weaponSpeed;
        damage = weaponDamage;
    }

    private void MoveForward()
    {
        transform.position += Time.deltaTime * speed * Vector3.forward;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Target"))
        {
            target = FindObjectOfType<Target>();
            Destroy(gameObject);
            target.TakeDamage(damage);
            SpawnDeathParticle();
        }
    }

    private void ParticleDoubleDamage()
    {
        doubleDamageParticle.SetActive(GUIButtons.Instance.doubleDamage);
    }
    
    private void SpawnDeathParticle()
    {
        GameObject deathParticle = Instantiate(collisionParticle, transform.position, Quaternion.identity);
        AudioSource deathParticleSource = deathParticle.GetComponent<AudioSource>();
        AudioHandler.PlaySounds(deathParticleSource, deathClip, Volume() * 0.5f);
    
        Destroy(deathParticle, 1f);
    }

    private float Volume()
    {
        float volume = AudioHandler.GetVolume("Sounds");
        return volume;
    }
}

using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float explosionForce = 1.0f;
    public float explosionRadius = 1.0f;
    public float upwardsModifier = 3.0f;

    private Rigidbody _rigidbody;
    private AudioSource _audioSource;
    private GameManager _gameManager;
    private bool _hasExploded;

    private void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
        _gameManager = GameManager.GetGameManager();
        _hasExploded = false;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Enemy") && !_hasExploded)
        {
            Collider[] hitColliders = Physics.OverlapSphere(gameObject.transform.position, explosionRadius);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.gameObject.CompareTag("Player"))
                {
                    UnfreezeRotation(hitCollider);
                    _gameManager.LoseGame();
                }
                else if (hitCollider.gameObject.CompareTag("Enemy"))
                {
                    UnfreezeRotation(hitCollider);
                    hitCollider.gameObject.SendMessage("Die");
                }
                Rigidbody colliderRigidbody = hitCollider.attachedRigidbody;
                if (colliderRigidbody != null)
                {
                    colliderRigidbody.AddExplosionForce(explosionForce, gameObject.transform.position, explosionRadius, upwardsModifier, ForceMode.Force);
                }
            }
            _audioSource.Play();
            _hasExploded = true;
            Destroy(gameObject, 3.5f);
        }
    }

    private void UnfreezeRotation(Collider collider)
    {
        Rigidbody colliderRigidbody = collider.attachedRigidbody;
        if (colliderRigidbody != null)
        {
            colliderRigidbody.freezeRotation = false;
        }
    }
}

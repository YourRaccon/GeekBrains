using UnityEngine;

public class GhostController : MonoBehaviour
{
    public float speed;

    private Vector3 _startPoint;
    private Vector3 _endPoint;
    protected Vector3 _direction;
    protected Rigidbody _rigidbody;
    protected AudioSource _audioSource;
    private GameObject _spawner;
    protected GameManager _gameManager;
    private bool _isDead;

    protected void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
        _gameManager = GameManager.GetGameManager();
    }

    protected void Update()
    {
        if (!_isDead && _startPoint != null && _endPoint != null)
        {
            if ((_startPoint - _endPoint).sqrMagnitude > (_startPoint - gameObject.transform.position).sqrMagnitude)
            {
                _rigidbody.MovePosition(gameObject.transform.position + _direction * speed * Time.deltaTime);
            }
            else
            {
                Destroy(gameObject, 0.0f);
            }
        }
    }

    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _gameManager.LoseGame();
        }
    }

    public void SetWay(Vector3 endPoint)
    {
        _startPoint = gameObject.transform.position;
        _endPoint = endPoint;
        _direction = _endPoint - _startPoint;
        _direction.Normalize();
        gameObject.transform.LookAt(_endPoint);
    }

    public void SetSpawner(GameObject spawner)
    {
        _spawner = spawner;
    }

    public void Die()
    {
        _spawner.SendMessage("OnObjectDie");
        _isDead = true;
        Destroy(gameObject, 5.0f);
    }
}

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1;
    public float rotationSpeed = 1;
    public GameObject bombObject;
    public float bombPlantCoolDown = 5;

    private Animator _animator;
    private Rigidbody _rigidbody;
    private AudioSource _audioSource;
    private Vector3 _movement;
    private Quaternion _rotation = Quaternion.identity;
    private GameManager _gameManager;
    private float bombPlantCoolDownTimer;

    private void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
        _rigidbody = gameObject.GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
        _gameManager = GameManager.GetGameManager();
    }

    private void Update()
    {
        if (!_gameManager.IsGameEnded())
        {
            Move();
            if (Input.GetAxis("Fire1") > 0 && bombPlantCoolDownTimer <= 0)
            {
                PlantBomb();
                bombPlantCoolDownTimer = bombPlantCoolDown;
            }
            else if (bombPlantCoolDownTimer > 0)
            {
                bombPlantCoolDownTimer -= Time.deltaTime;
            }
        } else
        {
            _animator.SetBool("IsWalking", false);
            _audioSource.Stop();
        }
    }
    
    private void Move()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        _movement.Set(inputX, 0f, inputY);
        _movement.Normalize();

        if (System.Math.Abs(inputX) > 0.3 || System.Math.Abs(inputY) > 0.3)
        {
            _animator.SetBool("IsWalking", true);

            Vector3 desiredForward = Vector3.RotateTowards(transform.forward, _movement, rotationSpeed * Time.deltaTime, 0f);
            _rotation = Quaternion.LookRotation(desiredForward);
            _rigidbody.MovePosition(_rigidbody.position + _movement * speed * Time.deltaTime);
            _rigidbody.MoveRotation(_rotation);

            if (!_audioSource.isPlaying)
            {
                _audioSource.Play();
            }
        }
        else
        {
            _animator.SetBool("IsWalking", false);
            _audioSource.Stop();
        }
    }

    private void PlantBomb()
    {
        Instantiate(bombObject, gameObject.transform.position, gameObject.transform.rotation);
    }
}

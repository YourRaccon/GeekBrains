using UnityEngine;


public class PlayerController : MonoBehaviour
{
    #region Fields

    public float speed;
    public float rotationSpeed;
    public GameObject bombObject;
    public float bombPlantCoolDown;
    public float jumpForce;
    public float maxJumpTime;

    private Animator _animator;
    private Rigidbody _rigidbody;
    private AudioSource _audioSource;
    private Vector3 _movement;
    private Quaternion _rotation = Quaternion.identity;
    private GameManager _gameManager;
    private float _bombPlantCoolDownTimer;
    private float _jumpTimer;
    private float _previousJump;
    private bool _inJump;

    #endregion


    #region UnityMethods

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
            Jump();
            if (!_inJump)
            {
                PlantBomb();
            }
        }
        else
        {
            _animator.SetBool("IsWalking", false);
            _audioSource.Stop();
        }
    }

    #endregion


    #region Methods

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
        if (Input.GetAxis("Fire1") > 0 && _bombPlantCoolDownTimer <= 0)
        {
            Instantiate(bombObject, gameObject.transform.position, gameObject.transform.rotation);
            _bombPlantCoolDownTimer = bombPlantCoolDown;
        }
        else if (_bombPlantCoolDownTimer > 0)
        {
            _bombPlantCoolDownTimer -= Time.deltaTime;
        }
    }

    private void Jump()
    {
        if (Input.GetAxis("Jump") > 0 && Input.GetAxis("Jump") >= _previousJump && _jumpTimer < maxJumpTime)
        {
            _jumpTimer += Time.deltaTime;
            _previousJump = Input.GetAxis("Jump");
            Vector3 force = new Vector3(0, jumpForce, 0);
            _rigidbody.AddForce(force);
            _inJump = true;
        }
        else if (Mathf.Approximately(_rigidbody.velocity.y, 0.0f))
        {
            _jumpTimer = 0;
            _previousJump = 0;
            _inJump = false;
        }
    }

    #endregion
}

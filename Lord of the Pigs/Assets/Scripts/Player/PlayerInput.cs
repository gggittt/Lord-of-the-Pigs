using UnityEngine;

[RequireComponent(typeof(Player), typeof(Rigidbody2D))]
public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 12f;
    [SerializeField] private Joystick _joystick;

    private Rigidbody2D _rigidbody2D;
    private Player _player;
    [SerializeField] private KeyCode _bombButton = KeyCode.E;


    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _player = GetComponent<Player>();
    }

    private void FixedUpdate()
    {
        Vector2 velocity;
#if UNITY_EDITOR || UNITY_ANDROID
        velocity = new Vector2(
            _joystick.Horizontal,
            _joystick.Vertical
        );
#endif
#if UNITY_STANDALONE
        velocity = new Vector2(
            Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical")
        );
#endif

        _rigidbody2D.velocity = velocity * _moveSpeed;

        if (velocity.x != 0 && velocity.y != 0)
        {
            var lookDirType = CalculateDirection.GetDir(velocity);

            _player.ChangeSpriteByDirection(lookDirType);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(_bombButton))
        {
            _player.TryInstallBomb();
        }
    }
}
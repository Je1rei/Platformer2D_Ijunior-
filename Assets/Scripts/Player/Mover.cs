using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    private const string _horizontal = "Horizontal";
    private const string _jump = "Jump";
    private const string _groundLayer = "Ground";

    [SerializeField] private Transform _groundCheckPoint;
    [SerializeField] private float _radiusOverlap = 0.5f;

    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;

    public bool IsRun { get; private set; }

    private void Awake()
    {
        IsRun = false;
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Move(float speed)
    {
        float horizontal = Input.GetAxis(_horizontal);

        transform.Translate(horizontal * speed * Time.deltaTime, 0, 0);

        IsRun = horizontal != 0;
        _spriteRenderer.flipX = horizontal < 0;
    }

    public void Jump(float jumpForce)
    {
        if (CheckGround())
        {
            float jump = Input.GetAxisRaw(_jump);

            _rigidbody.AddForce(new Vector2(0, jump * jumpForce * Time.deltaTime), ForceMode2D.Impulse);
        }
    }

    private bool CheckGround()
    {
        LayerMask groundLayer = LayerMask.GetMask(_groundLayer);
        return Physics2D.OverlapCircle(_groundCheckPoint.position, _radiusOverlap, groundLayer);
    }
}

using UnityEngine;

public class Player : MonoBehaviour {
    private Rigidbody2D rb2d;
    [SerializeField] private float speed = 10f;
    private float xMove;
    [SerializeField] private float jumpSpeed = 5f;
    private bool spacePressed;
    private BoxCollider2D bc2d;
    private float jumpDetection = .1f;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float fallMultiplier =3f;
    [SerializeField] private float lowJumpMultiplier = 2f;
    [SerializeField] float jumpTime;
    private float jumpTimer;


    // Start is called before the first frame update
    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        bc2d = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update() {
        xMove = Input.GetAxisRaw("Horizontal");
        spacePressed = Input.GetKeyDown(KeyCode.Space);
        if (spacePressed && IsGrounded()) {
            rb2d.velocity = Vector2.up * jumpSpeed;
            jumpTimer = jumpTime; 
        }
        Debug.Log("JumpTimer remaining: " + jumpTimer);
        if (jumpTimer >0)jumpTimer -= Time.deltaTime; 
        if (rb2d.velocity.y < 0 || jumpTimer <= 0) {
            rb2d.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier-1) *Time.deltaTime;
        } else if (rb2d.velocity.y > 0 && !Input.GetKey(KeyCode.Space)) {
            rb2d.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

    }

    private void FixedUpdate() {
        HorizontalMovement();

    }


    //Handles horizontal movement for the player class. Uses player input to change direction and jump
    private void HorizontalMovement() {
        // Debug.Log("Xmove= " + xMove);
        if (Mathf.Abs(xMove) < .001) {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            return;
        }
        rb2d.velocity = new Vector2(speed * xMove, rb2d.velocity.y);
    }

    private bool IsGrounded() {
        //  Debug.Log("IsGrounded: " + Physics2D.BoxCast(bc2d.bounds.center, bc2d.bounds.size, 0f, Vector2.down, jumpDetection, jumpableGround));
        return Physics2D.BoxCast(bc2d.bounds.center, bc2d.bounds.size, 0f, Vector2.down, jumpDetection, jumpableGround);

    }



}
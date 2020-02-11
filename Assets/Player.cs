using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D myR;

    private Animator myAnim; 

    [SerializeField]
    private float moveSpeed;

    private bool facingRight;

    [SerializeField]
    public float jumpV = 50.0f;

   // private int numJump;

    public Transform topleft;
    public Transform botright;
    public LayerMask ground; 

    bool isOnGround;
    // Start is called before the first frame update
    public GameObject EvilCoin;
    private GameObject player;

    void Start()
    {

        isOnGround = true; 
        facingRight = true; 
        myR = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        EvilCoin = GameObject.FindGameObjectWithTag("Coin");
        player = GameObject.FindGameObjectWithTag("Player"); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");

        HandleMovement(horizontal);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            myR.velocity = Vector2.up * jumpV;
        }
    }

    private void HandleMovement(float horizontal)
    {
        myR.velocity = new Vector2(horizontal * moveSpeed, myR.velocity.y);  //x - 1 and y = 0; 

        myAnim.SetFloat("speed", Mathf.Abs(horizontal)); 
    }

    private void Flip(float horizontal)
    {
        if(horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;

            Vector2 theScale = transform.localScale;

            theScale.x *= -1;

            transform.localScale = theScale;
        }

    }

  
}

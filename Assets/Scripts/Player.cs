
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    public float accelerate = 10f;
    public float speed = 10f;
    public float rotation = 100f;

    public float bulletSpeed = 8f;

    public Transform bulletSpawn;
    public GameObject bulletPrefab;

    private float rotateVal;

    private Rigidbody2D rb;
    private bool alive = true;
    private bool isAccelerating = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // if(alive){
        //     playerAccelerator();
        //     playerRotation();
        //     playerShoot();
        // }
        
        //float inputY = Input.GetAxis("Horizontal");
        //float inputX = Input.GetAxis("Vertical");
        //rb.velocity = transform.up * inputX * speed;
        //rb.angularVelocity = -inputY * rotation;


    }

    void FixedUpdate()
    {
        if(isAccelerating)
        {
            rb.AddForce(accelerate * transform.up);
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, speed);
        }else{
            rb.velocity = rb.velocity*.98f;
        }
        transform.Rotate(new Vector3(0,0,-rotation*rotateVal));
    }
    // void playerAccelerator()
    // {
    //     isAccelerating = Input.GetKey(KeyCode.UpArrow);
    // }
    void OnMove(InputValue value)
    {
        isAccelerating = value.Get<float>() > 0f;
    }
    void OnRotate(InputValue value)
    {
        rotateVal = value.Get<float>();
    }
    // void playerRotation()
    // {
    //     if(Input.GetKey(KeyCode.LeftArrow)) 
    //     {
    //         transform.Rotate(rotation * Time.deltaTime * transform.forward);
    //     } else if (Input.GetKey(KeyCode.RightArrow)){
    //         transform.Rotate(-rotation * Time.deltaTime * transform.forward);
    //     }
    // }

    void OnShoot()
    {
        GameObject bullet = Instantiate(bulletPrefab,bulletSpawn.position, Quaternion.identity);

        Vector2 playerVelocity = rb.velocity;
        Vector2 playerDirection = transform.up;
        float playerForwardSpeed = Vector2.Dot(playerVelocity, playerDirection);

        if(playerForwardSpeed < 0)
        {
            playerForwardSpeed = 0;
        }
        Rigidbody2D bulletrb = bullet.GetComponent<Rigidbody2D>();
        bulletrb.velocity = playerDirection * playerForwardSpeed;
        bulletrb.AddForce(bulletSpeed * transform.up, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Asteroid"))
        {
            alive = false;

            GameManager gameManager = FindAnyObjectByType<GameManager>();
            gameManager.GameOver();
            Destroy(gameObject);
        }
    }

}
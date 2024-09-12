using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    
    //public float speed = 2f;
   // public float rotation = 5f;
    public int size = 3;
    public GameManager gameManager;
    // Start is called before the first frame update
    private Rigidbody2D rb; 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Vector2 direction = new Vector2(Random.value, Random.value).normalized;
        float spawnSpeed = Random.Range(4f - size, 5f - size);
        // rb.AddForce(direction * spawnSpeed, ForceMode2D.Impulse);

        gameManager.plusCount();
        rb.velocity = Random.insideUnitCircle * spawnSpeed;
        //rb.angularVelocity = Random.Range(-speed, speed);
    }
    void OnTriggerEnter2D(Collider2D collison)
    {
        if(collison.CompareTag("Bullet"))
        {
            gameManager.minusCount();
            Destroy(collison.gameObject);

            if(transform.localScale.z > .5f)
            {
                for(int i =0; i < 2; i++)
                {
                    Asteroid newAsteroid = Instantiate(this, transform.position, Quaternion.identity);
                    newAsteroid.transform.localScale = transform.localScale * .5f;
                    newAsteroid.gameManager = gameManager;
                }
            }
            Destroy(gameObject);
        }
    }
    
    
}

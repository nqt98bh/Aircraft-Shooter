using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    [SerializeField] int HP = 5;
    [SerializeField] float speed = 5.0f;
    [SerializeField] int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    Camera mainCamera;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        mainCamera = Camera.main;
    }
    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    void Update()
    {
        Moving();
        ConstrainPosition();
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
    void GetHealthUp(int health)
    {
        currentHealth += health;
        healthBar.SetHealth(currentHealth);
    }
    private void Moving()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float moveHorizontal = horizontalInput * speed *Time.deltaTime;

        float verticalInput = Input.GetAxis("Vertical");
        float moveVerticall = verticalInput * speed * Time.deltaTime;

        if(horizontalInput !=0 )
        {
            transform.position = new Vector3(moveHorizontal + transform.position.x, transform.position.y, 10f);
        }
     
        if (verticalInput !=0)
        {
            transform.position = new Vector3( transform.position.x, transform.position.y + moveVerticall, 10f);

        }
        
    }

    void ConstrainPosition()
    {
        // Get camera bounds
        float halfHeight = mainCamera.orthographicSize;
        float halfWidth = halfHeight * mainCamera.aspect;

        // Get the player's current position
        Vector3 pos = transform.position;

        // Clamp the position
        pos.x = Mathf.Clamp(pos.x, -halfWidth, halfWidth);
        pos.y = Mathf.Clamp(pos.y, -halfHeight, halfHeight * 2);

        // Set the new position
        transform.position = pos;
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag ("Meteor") || other.CompareTag("EnemyBullet"))
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            TakeDamage(20);
            if (currentHealth <= 0)
            {
                Destroy(gameObject);
                Debug.Log("Your are dead");
            }
          
        }
        else if (other.CompareTag(GameConstant.POWERUP_TAG))
        {
            BulletSpawner.instance.DoubleFire(1);
        }
        else if (other.CompareTag(GameConstant.SPEEDUP_TAG))
        {
            GameController.instance.BulletSpawner.BulletSpeedUp(1);
            GameController.instance.BulletSpawner.BulletFireUp(0.15f);

        }
        else if (other.CompareTag(GameConstant.HEALTHUP_TAG))
        {
            GetHealthUp(20);
        }
    }

}


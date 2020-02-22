using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class bambang : MonoBehaviour
{
    HealthPoint healthPoint;

    [SerializeField] private UnityEvent onGet, onHit, onDeath;
    Animator animator;
    Rigidbody2D rigidbody;
    Vector2 movement;
    [SerializeField] float speed;

    public GameObject winCondition;
    public GameObject loseCondition;
    public bool isGetKey;
    public Slider healtSlider;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        movement = new Vector2(0, 0);
        healthPoint = FindObjectOfType<HealthPoint>();

    }

    // Update is called once per frame
    void Update()
    {



        if (Input.GetKey(KeyCode.W))
        {
            rigidbody.velocity = transform.up * speed;
            animator.SetBool("move", true);
        }

        else if (Input.GetKey(KeyCode.A))
        {
            rigidbody.angularVelocity = speed * 40;
            animator.SetBool("move", true);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            rigidbody.angularVelocity = -speed * 40;
            animator.SetBool("move", true);
        }
        else
        {
            animator.SetBool("move", false);
            rigidbody.velocity = movement;
            rigidbody.angularVelocity = 0;
        }

        if(healthPoint.currentHp < 1)
        {
            loseCondition.SetActive(true);
            onDeath.Invoke();

            StartCoroutine(MainMenu());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Pintu" && isGetKey)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if(collision.gameObject.name == "Key")
        {
            onGet.Invoke();
            Destroy(collision.gameObject);
            isGetKey = true;
        }

        if(collision.gameObject.name == "Monster")
        {
            onHit.Invoke();
            healthPoint.currentHp -= 20;
        }

        if(collision.gameObject.name == "fireball(Clone)")
        {
            onHit.Invoke();
            healthPoint.currentHp -= 20;
        }
    }

    IEnumerator MainMenu()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
        healthPoint.currentHp = healthPoint.startingHP;
    }
}

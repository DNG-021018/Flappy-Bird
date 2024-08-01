using UnityEngine;
public class Movement : MonoBehaviour
{
    private Vector3 direction;
    float gravity = -9.8f;
    float strength = 5f;
    public Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        BirdMovement();
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0.58f;
        transform.position = position;
        direction = Vector3.zero;
    }

    void BirdMovement()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            direction = Vector3.up * strength;
            transform.rotation = Quaternion.Euler(0f, 0f, 23);
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                direction = Vector3.up * strength;
                transform.rotation = Quaternion.Euler(0f, 0f, 23);
            }
        }

        float targetAngle = -70f;
        float angle = Mathf.LerpAngle(transform.eulerAngles.z, targetAngle, Time.deltaTime);
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            FindObjectOfType<GameManager>().GameOver();
        }
        else if (other.gameObject.tag == "Scoring")
        {
            FindObjectOfType<GameManager>().IncreseScore();
        }
    }
}

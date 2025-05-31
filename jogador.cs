jogador.cs

using UnityEngine;
using UnityEngine.SceneManagement;

public class robotic : MonoBehaviour
{
    public static robotic instance; // Singleton

    public int coins;

    [Header("Áudio")]
    public AudioClip coinSound;
    private AudioSource audioSource;

    private Vector3 escalaOriginal;

    [Header("Pulo e Dash")]
    public float jumpForce = 7f;
    public float dashForce = 10f;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private bool isDashing = false;
    private int jumpCount = 0;

    // Duplo clique para dash
    private float lastLeftTapTime = -1f;
    private float lastRightTapTime = -1f;
    public float doubleTapThreshold = 0.3f;

    void Awake()
    {
        // Singleton anti duplicado
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Reset de posição sempre que carregar nova cena
        transform.position = new Vector3(0, 0, 0); // ajuste para a posição inicial da fase
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        escalaOriginal = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        Vector3 movimento = new Vector3(moveX, 0, 0);

        if (!isDashing && movimento != Vector3.zero)
        {
            transform.position += movimento * Time.deltaTime * moveSpeed;

            if (moveX > 0.01f)
                transform.localScale = new Vector3(Mathf.Abs(escalaOriginal.x), escalaOriginal.y, escalaOriginal.z);
            else if (moveX < -0.01f)
                transform.localScale = new Vector3(-Mathf.Abs(escalaOriginal.x), escalaOriginal.y, escalaOriginal.z);
        }

        // Pulo e Duplo Pulo
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpCount++;
        }

        // Dash
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (Time.time - lastRightTapTime < doubleTapThreshold)
                StartCoroutine(DoDash(1));
            else
                lastRightTapTime = Time.time;
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (Time.time - lastLeftTapTime < doubleTapThreshold)
                StartCoroutine(DoDash(-1));
            else
                lastLeftTapTime = Time.time;
        }
    }

    private System.Collections.IEnumerator DoDash(float direction)
    {
        isDashing = true;
        rb.linearVelocity = Vector2.zero;
        rb.AddForce(new Vector2(direction * dashForce, 0), ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.2f);
        isDashing = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.5f)
        {
            jumpCount = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coins")
        {
            Destroy(collision.gameObject);
            coins++;

            if (coinSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(coinSound);
            }
        }
    }
}



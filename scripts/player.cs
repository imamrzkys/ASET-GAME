using UnityEngine;

public class PlayerMovement : MonoBehaviour
{ 
    [SerializeField] private float speed;
    private Rigidbody2D body;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();

        // Set initial scale to be larger
        transform.localScale = new Vector3(1.5f, 1.5f, 1);
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.linearVelocity = new Vector2(horizontalInput * speed, body.linearVelocity.y);

        // Flip player when facing left/right, keeping the larger scale
        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(1.5f, 1.5f, 1);
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1.5f, 1.5f, 1);

        if (Input.GetKey(KeyCode.Space))
            body.linearVelocity = new Vector2(body.linearVelocity.x, speed);
    }
}

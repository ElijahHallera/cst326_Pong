using UnityEngine;
using UnityEngine.Serialization;

public class Ball : MonoBehaviour {
    public float startSpeed;
    public float step;
    public bool useDebugVisualization;
    public AudioSource audioSource;
    public AudioClip normalSpeedSound;
    public AudioClip fastSpeedSound;
    public AudioClip fastestSpeedSound;
    public PowerUp powerUp;

    private float speed;
    private Rigidbody rb;
    public Vector3 storage;

    //-----------------------------------------------------------------------------
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        rb = gameObject.GetComponent<Rigidbody>();
        speed = startSpeed;
        storage = this.transform.localScale;
    }

    //-----------------------------------------------------------------------------
    // Update is called once per frame
    public void Restart()
    {
        speed = startSpeed;
        rb.MovePosition(Vector3.zero);
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.right * speed; // change to send to losing side
    }

    //-----------------------------------------------------------------------------
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "PaddleLeft" || collision.gameObject.name == "PaddleRight")
        {
            //play sound
            float velocityPlaceholder = 0;
            speed += step;
            float heightAboveOrBelow = transform.position.z - collision.transform.position.z;
            float maxHeight = collision.collider.bounds.extents.z;
            float percentOfMax = heightAboveOrBelow / maxHeight;

            if (useDebugVisualization)
            {
                DebugDraw.DrawSphere(transform.position, 0.5f, Color.green);
                DebugDraw.DrawSphere(collision.transform.position, 0.5f, Color.red);
                Debug.Break();
                Debug.Log($"percent height = {percentOfMax}");
            }

            bool hitLeftPaddle = collision.gameObject.name == "PaddleLeft";
            float newHorizontalSpeed = (hitLeftPaddle) ? speed : -speed;

            Vector3 newVelocity = new Vector3(newHorizontalSpeed, 0f, percentOfMax * 4f).normalized * speed;
            rb.velocity = newVelocity;
            velocityPlaceholder = rb.velocity.magnitude;

            //Check rigibody velocity on collision.
            //Say every 5 speed increase in velocity
            //Play different sound for ball collision.
            if (velocityPlaceholder <= 10)
            {
                audioSource.PlayOneShot(normalSpeedSound);
            }

            if (velocityPlaceholder > 10 && velocityPlaceholder <= 20)
            {
                audioSource.PlayOneShot(fastSpeedSound);
            }

            if (velocityPlaceholder > 20)
            {
                audioSource.PlayOneShot(fastestSpeedSound);
            }
        }
    }

    public void shrink()
    {
        this.transform.localScale -= new Vector3(.7f, .7f, .7f);
    }

    public void resetSize()
    {
        this.transform.localScale = storage;
    }

    public void OMEGASpeed()
    {
        Time.timeScale = 2f;
    }
}

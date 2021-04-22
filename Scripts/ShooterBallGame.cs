using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShooterBallGame : MonoBehaviour
{
    public Transform shootAt;
    public Transform[] shooters;
    public float speed = 5.0f;
    public float interval = 3.0f;

    private float nextBallTime = 2f;
    private ObjectPooler pool;
    private AudioSource soundEffect;
    public int shooterId;

    private bool shootBall = false;

    public Text score;
    public int scoreInt = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (shootAt == null)
        {
            shootAt = Camera.main.transform;
        }

        soundEffect = GetComponent<AudioSource>();
        
        if (soundEffect == null)
        {
            Debug.LogError("Requires AudioSource component");
        }

        pool = GetComponent<ObjectPooler>();

        if (pool == null)
        {
            Debug.LogError("Requires ObjectPooler component");
        }

        Time.fixedDeltaTime = 0.001f;

        AudioProcessor processor = FindObjectOfType<AudioProcessor>();
        processor.onBeat.AddListener(OnBeatDetected);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextBallTime)
        {
            nextBallTime += interval;
            shootBall = true;
        }

        score.text = "Score\n" + scoreInt;
    }

    void OnBeatDetected()
    {
        if (shootBall == true)
        {
            var shooter = shooters[Random.Range(0, shooters.Length)];
            ShootBall(shooter);
            shootBall = false;
        }
    }

    private void ShootBall(Transform shooter)
    {
        GameObject ball = pool.GetPooledObject();

        if (ball != null)
        {
            ball.transform.position = shooter.position;
            ball.transform.rotation = Quaternion.identity;

            Rigidbody rb = ball.GetComponent<Rigidbody>();
            rb.angularVelocity = Vector3.zero;
            shooter.transform.LookAt(shootAt);
            rb.velocity = shooter.forward * speed;

            ball.SetActive(true);
            soundEffect.Play();
        }
    }
}

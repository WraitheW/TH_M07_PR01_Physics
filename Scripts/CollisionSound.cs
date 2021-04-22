using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSound : MonoBehaviour
{
    private AudioSource hitSoundEffect;
    public ShooterBallGame SBG;

    // Start is called before the first frame update
    private void Start()
    {
        hitSoundEffect = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.other.tag == "Ball")
        {
            SBG.scoreInt++;
            hitSoundEffect.Play();
            collision.other.gameObject.SetActive(false);
        }
    }
}

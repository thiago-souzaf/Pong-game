using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ePlayer
{
    Left,
    Right
}
public class Player : MonoBehaviour
{
    private GameController gameController;
    public ePlayer player;
    public float speed = 15f;
    private Rigidbody rb;
    public float inputSpeed = 0f;
    private float timeToRestore = 4f;

    private AudioSource audioSrc;
    public AudioClip sfxPowerUp;

    public Vector3 originalScale;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameController = FindAnyObjectByType<GameController>();
        this.originalScale = this.transform.localScale;
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameController.started)
        {
            if (player == ePlayer.Left)
            {
                inputSpeed = Input.GetAxisRaw("PlayerLeft");
            }
            else if (player == ePlayer.Right)
            {
                inputSpeed = Input.GetAxisRaw("PlayerRight");
            }
            if (transform.position.z < 5f && transform.position.z > -5f)
                rb.velocity = Vector3.forward * inputSpeed * speed;
        }
        
    }

    private IEnumerator RestoreSize(float delay)
    {
        yield return new WaitForSeconds(delay);

        this.transform.localScale = originalScale;
    }

    public void SizePowerUp(float increaseFactor)
    {
        Vector3 currentScale = this.transform.localScale;
        
        this.transform.localScale = new Vector3(currentScale.x, currentScale.y * increaseFactor, currentScale.z);
        audioSrc.clip = sfxPowerUp;
        audioSrc.Play();

        StartCoroutine(this.RestoreSize(timeToRestore));
    }
}

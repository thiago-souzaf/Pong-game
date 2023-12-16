using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public GameObject[] vfxParticle;
    private List<Material> materials;
    public Material defaultMaterial;
    public Material blueMaterial;
    public Material redMaterial;

    private TrailRenderer trail;

    public float initialSpeed = 10f;
    public float speed;
    public float minDirection = 0.5f;
    public float acceleration;
    private Vector3 direction;
    private Rigidbody rb;

    public bool stopped = true;

    private GameController gameController;

    public GameObject downBorder;
    public GameObject upBorder;

    private Vector3 originalSize;
    public float increaseFactor;
    public float increaseSizeTime;
    private bool isScaling = false;

    private AudioSource audioSrc;
    public AudioClip[] sfx;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameController = FindObjectOfType<GameController>();
        trail = GetComponent<TrailRenderer>();
        originalSize = transform.localScale;
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (stopped) return;

        
        if(this.transform.position.z < upBorder.transform.position.z || this.transform.position.z > downBorder.transform.position.z)
        {
            this.rb.MovePosition(this.rb.position + speed * Time.deltaTime * direction);
            this.speed += acceleration * Time.deltaTime;
        }

    }

    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("Wall"))
        {
            direction.z = -direction.z;
            CreateSpark(0);
            PlaySfx(0);
            
        }

        if (other.gameObject.CompareTag("Player"))
        {
            Vector3 newDirection = (transform.position - other.gameObject.transform.position).normalized;


            newDirection.x = Mathf.Sign(newDirection.x) * Mathf.Max(Mathf.Abs(newDirection.x), this.minDirection);
            newDirection.z = Mathf.Sign(newDirection.z) * Mathf.Max(Mathf.Abs(newDirection.z), this.minDirection);

            direction = newDirection;

            CreateSpark(1);

            Debug.Log(other.gameObject.ToString());
            ChangeTrailColor(other.gameObject.ToString());

            PlaySfx(1);

        }

        if (!isScaling)
        {
            StartCoroutine(ScaleUpAndDown());
        }
    }

    private void ChooseDirection()
    {
        float signX = Mathf.Sign(Random.Range(-1f, 1f));
        float signY = Mathf.Sign(Random.Range(-1f, 1f));
        this.direction = new Vector3(0.5f * signX, 0, 0.5f * signY);
    }
    
    public void Stop()
    {
        this.stopped = true;
        trail.emitting = false;
        this.materials = new List<Material> { defaultMaterial };
        trail.SetMaterials(this.materials);
        
    }
    public void Go()
    {
        ChooseDirection();
        this.speed = this.initialSpeed;
        this.stopped = false;
        trail.emitting = true;

    }

    public void CreateSpark(int index)
    {
        GameObject sparks = Instantiate(this.vfxParticle[index], transform.position, Quaternion.identity);
        Destroy(sparks, 4f);
    }

    private void ChangeTrailColor(string player)
    {
        if (player.Contains("Player_Left"))
        {
            this.materials = new List<Material> { blueMaterial };
            trail.SetMaterials(this.materials);
        } else if (player.Contains("Player_Right"))
        {
            this.materials = new List<Material> { redMaterial };
            trail.SetMaterials(this.materials);
        }

    }

    IEnumerator ScaleUpAndDown()
    {
        this.isScaling = false;

        transform.localScale *= increaseFactor;

        yield return new WaitForSeconds(increaseSizeTime);

        transform.localScale = originalSize;

        yield return new WaitForSeconds(increaseSizeTime);

        isScaling = false;
    }

    public void PlaySfx(int index)
    {
        audioSrc.clip = sfx[index];
        audioSrc.Play();
    }
}

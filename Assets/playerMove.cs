using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 0.1f;
    public float horizontalMove;
    public float verticalMove;
    public Rigidbody rb;
    public float turbo = 5;

    public AudioSource audioSource;

    public Light light;

    public ParticleSystem ParticleSystem;

    public int itemsCounter = 0;

    public float jumpForce = 2;

    public bool ground = true;


    public GameObject prefaBala;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = rb.GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");
        jump();

        transform.Rotate(0, Input.GetAxisRaw("Mouse X"), 0);


        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            speed = speed * turbo;

        }

        if (Input.GetButtonDown("Fire1"))
        {
            var aux = Instantiate(prefaBala,transform.position + transform.forward * 2 ,Quaternion.identity);

            aux.GetComponent<Rigidbody>().AddForce(transform.forward * 800);
            Destroy(aux,2);

        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = speed / turbo;

        }
    }

    public void jump() {

        if (Input.GetKeyDown(KeyCode.Space) && ground)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            ground = false;
        }
    }


    public void OnCollisionEnter(Collision collision)
    {
        ground = true;
    }

    private void FixedUpdate()
    {
        transform.Translate(horizontalMove * speed * Time.deltaTime, 0, verticalMove * speed * Time.deltaTime);
       
    }

   
    private void OnTriggerEnter(Collider other)
    {

        itemsCounter++;
        FindAnyObjectByType<PlayerHelth>().ItemConseguido();
        Destroy(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        light.intensity = 0;
        audioSource.Pause();
        ParticleSystem.startLifetime = 0;
    }
}

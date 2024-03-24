using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BamboControl : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    [SerializeField] private float movespeed;
    private bool canshoot;
    private BambooManager LolipopManager;
    public AudioSource audioSource;

    public GameObject vfxPrefab;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        LolipopManager = GameObject.FindObjectOfType<BambooManager>();
    }

    private void Update()
    {
        handleshoot();
    }

    private void FixedUpdate()
    {
        shoot();
    }

    private void handleshoot()
    {
        if(Input.GetMouseButtonDown(0))
        {
            LolipopManager.SetDisableLolipop();
            canshoot = true;
        }
    }

    private void shoot()
    {
        if(canshoot)
        {
            rigidbody.AddForce(Vector2.up * movespeed * Time.fixedDeltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("circle"))
        {
            Vector3 contactPoint = other.contacts[0].point;
            PlayVFXEffect(contactPoint);
            audioSource.Play();

            LolipopManager.SetActiveLolipop();
            canshoot = false;
            rigidbody.isKinematic = true;
            Vector3 newPosition = other.contacts[0].point;
            newPosition.z = transform.position.z;
            transform.position = newPosition;
            transform.SetParent(other.gameObject.transform);
            rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;

        }
        if(other.gameObject.CompareTag("lolipop"))
        {
            SceneManager.LoadScene(1);
        }
    }

    private void PlayVFXEffect(Vector3 position)
    {
        Instantiate(vfxPrefab, position, Quaternion.identity);
    }
}

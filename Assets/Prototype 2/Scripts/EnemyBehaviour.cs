using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float speed;
    private GameObject worldTree;

    private AudioSource audioSource;
    public AudioClip chop;
    public AudioClip portal;
    public AudioClip smite;


    // Start is called before the first frame update
    void Start()
    {
        worldTree = GameObject.Find("EnemyObjective");
        audioSource = GetComponent<AudioSource>();

        PlaySound(portal);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (worldTree.transform.position - transform.position).normalized;
        transform.position += lookDirection * speed * Time.deltaTime;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                PlaySound(smite);
                Destroy(this.gameObject);
            }
            return;
        }

        if (other.gameObject.CompareTag("Tree"))
        {
            speed = 0;
        }
    }

    private void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    private IEnumerator PlaySoundRepeatedly()
    {
        while (true)
        {
            PlaySound(chop);
            yield return new WaitForSeconds(5); // Wait for the specified duration
        }
    }
}

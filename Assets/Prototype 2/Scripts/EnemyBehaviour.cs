using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float speed;
    private GameObject worldTree;


    // Start is called before the first frame update
    void Start()
    {
        worldTree = GameObject.Find("EnemyObjective");
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
            if (Input.GetKey(KeyCode.E))
                Destroy(this.gameObject);
            else
                return;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balaBehaviour : MonoBehaviour
{
    private GameObject player;
    private float speed = 6f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        switch (inimigo_behavior.lTiro)
        {
            case inimigo_behavior.lado.cima:
                transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, 0);
                break;
            case inimigo_behavior.lado.esquerda:
                transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, 90);
                break;
            case inimigo_behavior.lado.direita:
                transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, -90);
                break;
            default:
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D bateu)
    {
        
    }
}

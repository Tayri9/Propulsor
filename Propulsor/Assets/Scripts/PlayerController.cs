using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;
    Vector2 direction;

    [SerializeField]
    float impulse = 50f;

    // Start is called before the first frame update
    void Start()
    {
        //inicializo
        body = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Obtengo datos de movimiento en el mando
        direction.x = Input.GetAxis("Horizontal") * Time.deltaTime * impulse;
        direction.y = Input.GetAxis("Vertical") * Time.deltaTime * impulse;        
    }

    private void FixedUpdate()
    {
        //Empujo hacia donde se mueve
        body.AddForce(direction, ForceMode2D.Impulse);
    }
}
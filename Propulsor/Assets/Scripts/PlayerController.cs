using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;
    Vector2 direction;

    [SerializeField]
    float impulse = 50f;

    [SerializeField]
    TextMeshProUGUI labelFuel;

    float fuel = 100f;

    [SerializeField]
    GameObject prefabParticles;

    [SerializeField]
    GameObject labelGameOver;

    // Start is called before the first frame update
    void Start()
    {
        //inicializo
        body = GetComponent<Rigidbody2D>();
        fuel = 100f;
        
    }

    // Update is called once per frame
    void Update()
    {
        //Obtengo datos de movimiento en el mando
        direction.x = Input.GetAxis("Horizontal") * Time.deltaTime * impulse;
        direction.y = Input.GetAxis("Vertical") * Time.deltaTime * impulse;

        //Fuel
        fuel = fuel - 10f * Time.deltaTime;
        labelFuel.text = ((int)fuel).ToString() + " %"; //fuel.ToString(00.00)

        if(fuel <= 0f)
        {
            this.enabled = false;
            labelGameOver.SetActive(true);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Fuel")
        {            
            //col.gameObject.SetActive(false);
            fuel = fuel + 5f;
            if (fuel > 100f)
            {
                fuel = 100f;
            }

            //crear particulas
            Instantiate(prefabParticles, col.transform.position, col.transform.rotation);

            //Destruir fuel
            Destroy(col.gameObject);
        }
    }


    private void FixedUpdate()
    {
        //Empujo hacia donde se mueve
        body.AddForce(direction, ForceMode2D.Impulse);
    }

    public void ClickEnBoton()
    {
        Debug.Log("Ha clicado");
        SceneManager.LoadScene(0);
    }
}
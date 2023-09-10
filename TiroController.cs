using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroController : MonoBehaviour
{
    private Rigidbody2D meuRB;
   
    [SerializeField] private GameObject impacto;

    // Start is called before the first frame update
    void Start()
    {
        //pegando o meu rigidbody
        meuRB = GetComponent<Rigidbody2D>();

        //indo para cima
        //meuRB.velocity = new Vector2(0f, vel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //pegar o metodo perde vida e aplicar nele o dano (other)
        //isso só deve rodar se ele colidiu com alguem que tem o script inimigo 01 controller
        //checando se a tag de quem eu estou colidindo é inimigo 01
        if (collision.CompareTag("Inimigo"))
        {
            collision.GetComponent<InimigoPai>().PerdeVida(1);
        }

        //checando se eu colidi com o player
        if (collision.CompareTag("Jogador"))
        {
            collision.GetComponent<PlayerController>().PerdeVida(1);
        }


        Destroy(gameObject);
        Instantiate(impacto, transform.position, transform.rotation);
    }
}

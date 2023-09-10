using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D meuRB;
    [SerializeField] private float velocidade = 5f;
    [SerializeField] private GameObject meuTiro;
    [SerializeField] private Transform posicaoTiro;
    [SerializeField] private int vida = 3;
    [SerializeField] private GameObject explosao;
    //velocidade do tiro
    [SerializeField] private float velocidadeTiro = 10f;

    // Start is called before the first frame update
    void Start()
    {
        meuRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movendo();

        Atirando();
    }

    private void Movendo()
    {
        //pegando o input horizontal
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 minhaVelocidade = new Vector2(horizontal, vertical);
        //normalizando
        minhaVelocidade.Normalize();
        //passando a minha velocidade para o meuRB
        meuRB.velocity = minhaVelocidade * velocidade;
    }

    private void Atirando()
    {
        //testando para ver se funcionou a mudança no fire1
        if (Input.GetButtonDown("Fire1"))
        {
           var tiro = Instantiate(meuTiro, posicaoTiro.position, transform.rotation);
            //dar a direção e velocidade para o RB do tiro
            tiro.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, velocidadeTiro);
        }
    }

    public void PerdeVida(int dano)
    {
        vida -= dano;

        if(vida <= 0)
        {
            Destroy(gameObject);
            Instantiate(explosao, transform.position, transform.rotation);
        }
    }
}

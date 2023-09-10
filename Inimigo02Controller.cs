using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo02Controller : InimigoPai
{
    private Rigidbody2D meuRB;
    [SerializeField] private Transform posicaoTiro;
    [SerializeField] private float yMax = 2.5f;
    private bool possoMover = true;
    
    // Start is called before the first frame update
    void Start()
    {
        //pegando ele
        meuRB = GetComponent<Rigidbody2D>();

        //dando a velocidade para o meuRB
        meuRB.velocity = Vector2.up * velocidade;
    }

    // Update is called once per frame
    void Update()
    {
        Atirando();

        //checando se cheguei no meio da tela e posso mover
        if(transform.position.y < yMax && possoMover)
        {
            //checando de que lado eu estou
            //checando se estou na esquerda
            if(transform.position.x < 0)
            {
                //indo para a direita
                meuRB.velocity = new Vector2(-velocidade, velocidade);

                //falando que eu não posso mais mover
                possoMover = false;
            }
            else
            {
                //indo para a esquerda
                meuRB.velocity = new Vector2(velocidade, velocidade);
                
                //falando que eu não posso mais mover
                possoMover = false;
            }
            

        }
    } 

    private void Atirando()
    {
        bool visivel = GetComponentInChildren<SpriteRenderer>().isVisible;


        if (visivel)
        {
            //encontrando o player na cena
            var player = FindObjectOfType<PlayerController>();
            //só fazer qualquer coisa se o player existir
            if (player)
            {

                //diminuir a minha espera, e se ela for menor ou igual a zero, então eu atiro
                esperaTiro -= Time.deltaTime;
                if (esperaTiro <= 0f)
                {
                    //instanciando o meu tiro
                    var tiro = Instantiate(meuTiro, posicaoTiro.position, transform.rotation);
                    //encontrando o valor da direção
                    Vector2 direcao = player.transform.position - tiro.transform.position;
                    //normalizando a velocidade dele
                    direcao.Normalize();
                    //dando a direção e velocidade do meu tiro
                    tiro.GetComponent<Rigidbody2D>().velocity = direcao * velocidadeTiro;

                    //dando o angulo que o tiro tem que estar
                    float angulo = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg;
                    //passando o angulo
                    tiro.transform.rotation = Quaternion.Euler(0, 0, angulo + 90);

                    //reiniciar a nossa espera
                    esperaTiro = Random.Range(1f, 2f);
                }
            }
        }
    }
}

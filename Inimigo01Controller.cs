using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo01Controller : InimigoPai
{
    //pegar meu rigidbody
    private Rigidbody2D meuRB;
   

    //pegando o transform da poscao do meu tiro
    [SerializeField] private Transform posicaoTiro;

    

   

   

    // Start is called before the first frame update
    void Start()
    {
        //pegando ele
        meuRB = GetComponent<Rigidbody2D>();

        //dando a velocidade para o meuRB
        meuRB.velocity = new Vector2(0f, velocidade);

        //deixando a espera aleatoria para o primeiro tiro
        esperaTiro = Random.Range(0.5f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        //vou checar se o meu sprite renderer está visível

        //pegando informaçoes dos meus "filhos"
        Atirando();
    }

    private void Atirando()
    {
        bool visivel = GetComponentInChildren<SpriteRenderer>().isVisible;


        if (visivel)
        {


            //diminuir a minha espera, e se ela for menor ou igual a zero, então eu atiro
            esperaTiro -= Time.deltaTime;
            if (esperaTiro <= 0f)
            {
                //instanciando o meu tiro
                var tiro = Instantiate(meuTiro, posicaoTiro.position, transform.rotation);
                tiro.GetComponent<Rigidbody2D>().velocity = Vector2.down * velocidadeTiro;

                //reiniciar a nossa espera
                esperaTiro = Random.Range(1.5f, 2f);
            }
        }
    }

    //criar um método perde vida que recebe a quantidade de vida que ele deve perder (dano)

}

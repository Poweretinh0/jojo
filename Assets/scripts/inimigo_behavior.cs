using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigo_behavior : MonoBehaviour
{
    //mariana=contagem
    public enum lado {cima, esquerda, direita};
    public static lado lTiro;

    private Rigidbody2D rb;
    private Transform tr;
    private Animator an;
    public Transform verificaChao;
    public Transform verificaParede;

    private float relogio = 1f;
    private float mariana;

    [SerializeField]
    private GameObject pipoco;

    public float velocidade;
    public float raioVchao;
    public float raioVp;

    private bool estaNaParede;
    private bool estaNoChao;
    private bool viradoParaDireita;

    public LayerMask solido;


    void Awake()
    {

        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();
        an = GetComponent<Animator>();


        viradoParaDireita = true;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        EnemyMovements();
    }

    void EnemyMovements()

    {

        estaNoChao = Physics2D.OverlapCircle(verificaChao.position, raioVchao, solido);
        estaNaParede = Physics2D.OverlapCircle(verificaParede.position, raioVp, solido);

        if ((!estaNoChao || estaNaParede) && viradoParaDireita)
            Flip();
        else if ((!estaNoChao || estaNaParede) && !viradoParaDireita)
            Flip();

        if (estaNoChao)
            rb.velocity = new Vector2(velocidade, rb.velocity.y);




    }

    void Flip()

    {

        viradoParaDireita = !viradoParaDireita;
        tr.localScale = new Vector2(-tr.localScale.x, tr.localScale.y);

        velocidade *= -1; 
    }

    void OnDrawGizmosSelected()

    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(verificaChao.position, raioVchao);
        Gizmos.DrawWireSphere(verificaParede.position, raioVp);
    }

    void OnTriggerStay2D(Collider2D bateu)
    {
        if(bateu.tag == "Player")
        {
            if (bateu.transform.position.y > transform.position.y+1)
            {
                lTiro = lado.cima;
            }
            else if(bateu.transform.position.x > transform.position.x)
            {
                lTiro = lado.direita;
            }
            else if (bateu.transform.position.x < transform.position.x)
            {
                lTiro = lado.esquerda;
            }

            if(Time.time > mariana)
            {
                mariana = Time.time + relogio;
                Instantiate(pipoco, transform.position, Quaternion.identity);
            }
        }

    }
    
}

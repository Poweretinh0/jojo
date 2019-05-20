using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Behaviour : MonoBehaviour
{

    private Rigidbody2D rb;
    private Transform tr;
    private Animator an;

    public Transform verificaChao;
    public Transform verificaParede;

    private bool estaAndando;
    public bool estaPulando;
    private bool estaNoChao;
    private bool estaNaParede;
    private bool estaVivo;
    private bool viradoParaDireita;


    private float axis;

    public static int pontos;
    public float velocidade;
    public float forcaPulo;
    public float raioVchao;
    public float raioVp;

    public float doubleJump;

    public LayerMask solido;

    // Start is called before the first frame update
    void Start()

    {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();
        an = GetComponent<Animator>();

        estaVivo = true;
        viradoParaDireita = true;
    }

    // Update is called once per frame
    void Update()
    {

        estaNoChao = Physics2D.OverlapCircle(verificaChao.position, raioVchao, solido);
        estaNaParede = Physics2D.OverlapCircle(verificaParede.position, raioVp, solido);



        if (estaVivo)
        {

            axis = Input.GetAxisRaw("Horizontal");

            estaAndando = Mathf.Abs(axis) > 0f;

            if (axis > 0f && !viradoParaDireita)
                flip();

            else if (axis < 0f && viradoParaDireita)

                flip();




            if (Input.GetButtonDown("Jump") && estaNoChao)
            {
                rb.AddForce(tr.up * forcaPulo);

                estaPulando = true;

                estaNoChao = false;

            }

            else if (Input.GetButtonDown("Jump") && estaPulando)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0f);
                rb.AddForce(tr.up * forcaPulo);


                estaPulando = false;

            }




            Animations();
        }

    }
    void FixedUpdate()
    {


        if (estaAndando && !estaNaParede)
        {


            if (viradoParaDireita)
                rb.velocity = new Vector2(velocidade, rb.velocity.y);
            else
                rb.velocity = new Vector2(-velocidade, rb.velocity.y);


        }


    }

    void flip()
    {
        viradoParaDireita = !viradoParaDireita;

        tr.localScale = new Vector2(-tr.localScale.x, tr.localScale.y);


    }

    void Animations()

    {
        an.SetBool("Andando", (estaNoChao && estaAndando));
        an.SetBool("Pulando", !estaNoChao);
        an.SetFloat("VelVertical", rb.velocity.y);
        an.SetBool("Atacando", (estaNoChao && estaAndando));

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "cristal")
        {
            pontos++;
        }

    }



}



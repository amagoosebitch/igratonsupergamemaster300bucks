using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Unit
{
    [SerializeField]
    private int lives = 5;

    public GameObject player;
    public Animator animator;
    public float speed;
    public int Lives
    {
        get { return lives; }
        set
        {
            if (value < 5) lives = value;
        }
    }
   /* private Bullet bullet;*/
    /*    private HPBar hpbar;
    */
    /*
        [SerializeField]
        private float speed = 3.0F;*/

    /*    private CharState State
        {
            get { return (CharState)animator.GetInteger("State"); }
            set { animator.SetInteger("State", (int)value); }
        }
    */
    private Rigidbody2D rigidbody;
/*    private Animator animator;
*/    private SpriteRenderer sprite;

    private void Awake()
    {
/*        hpbar = FindObjectOfType<HPBar>();
*/      rigidbody = GetComponent<Rigidbody2D>();
/*        animator = GetComponent<Animator>();
*/        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    void Start()
    {
    }

    public bool isDead
    {
        get
        {
            return Lives <= 0;
        }
    }

    void Update()
    {
        var h = Input.GetAxis("Horizontal") * speed;
        var v = Input.GetAxis("Vertical") * speed;

        var current1 = Mathf.Abs(h);
        var current2 = Mathf.Abs(v);
        if (h > 0)
            player.transform.localScale = new Vector3(5, 5, 1);
        else if (h < 0)
            player.transform.localScale = new Vector3(-5, 5, 1);
        animator.SetFloat("Speed", current1 > 0 ? current1 : current2);
        /*        State = CharState.Idle;
        */
        player.transform.Translate(
            new Vector3(h * Time.deltaTime, v * Time.deltaTime, 0));
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl)) Bite();
        if (Input.GetKeyDown(KeyCode.L))
            ReceiveDamage();
/*        hpbar.Refresh();
*/        /*        var h = Input.GetAxis("Horizontal");
                var v = Input.GetAxis("Vertical");
                player.transform.Translate(
                    new Vector3(h*speed*Time.deltaTime, v*speed*Time.deltaTime, 0));
        */
    }

  

    private void Bite()
    {
        
        Vector3 position = transform.position;
        position.y += 1.75f;
        position.x += 2.3f * (sprite.flipX ? -1.0f : 1.0f);
     /*   Bullet newBullet = Instantiate(bullet, position, bullet.transform.rotation) as Bullet;

        newBullet.Parent = gameObject;
        newBullet.speed = 0.0f;
        newBullet.Direction = newBullet.transform.right * (sprite.flipX ? -1.0f : 1.0f);*/
        /*        State = CharState.Bite;
        */
    }

    public override void ReceiveDamage()
    {
        if (Lives == 1)
        {
            animator.SetTrigger("Death");
            //Destroy(gameObject);
/*            Instantiate(blood, transform.position, Quaternion.identity);
*/          //Time.timeScale = 0f;
/*            GameOverMenu.GameIsOver = true;
*/        }
        Lives--;

        //rigidbody.velocity = Vector3.zero;
        //rigidbody.AddForce(transform.up * 10.0F, ForceMode2D.Impulse);
    }
}
/*
public enum CharState
{
    Idle,
    Run,
    Bite;
}
*/
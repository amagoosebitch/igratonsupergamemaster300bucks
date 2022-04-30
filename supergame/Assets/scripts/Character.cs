using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Unit
{
    [SerializeField]
    private int lives = 5;

    public GameObject player;
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

    void Update()
    {
/*        State = CharState.Idle;
*/       if (Input.GetButton("Horizontal") || Input.GetButton("Vertical")) Run();
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl)) Bite();
/*        hpbar.Refresh();
*/        /*        var h = Input.GetAxis("Horizontal");
                var v = Input.GetAxis("Vertical");
                player.transform.Translate(
                    new Vector3(h*speed*Time.deltaTime, v*speed*Time.deltaTime, 0));
        */
    }

    private void Run()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        player.transform.Translate(
            new Vector3(h * speed * Time.deltaTime, v * speed * Time.deltaTime, 0));

        //transform.Rotate(0f, 180f, 0f);

        /*        State = CharState.Run;
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
        if (lives == 1)
        {
            Destroy(gameObject);
/*            Instantiate(blood, transform.position, Quaternion.identity);
*/            Time.timeScale = 0f;
/*            GameOverMenu.GameIsOver = true;
*/        }
        Lives--;

        rigidbody.velocity = Vector3.zero;
        rigidbody.AddForce(transform.up * 10.0F, ForceMode2D.Impulse);
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
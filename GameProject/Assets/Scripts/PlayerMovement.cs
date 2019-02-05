using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float runspeed = 40f;
    float screenTop = 0f;
    float screenBot = 0f;
    float screenRight = 0f;
    float screenLeft = 0f;
    public GameObject levelEdges;
    float horizontalMove = 0f;
    float verticalMove = 0f;
    private bool m_FacingRight = true;  // For determining which way the player is currently facing.
    private BoxCollider2D edges;
    private BoxCollider2D body;
    public GameObject weapon;
    bool attacking = false;
    Animator animator;
    private SpriteRenderer head;
    public Sprite testSprite;
    public Sprite old;

    private void Start()
    {
        //head = this.transform.Find("/DragonWomen/Dragonwoman (Sprite)/bone_1/bone_17/bone_18/bone_19/bone_20/bone_21/Tail").GetComponent<SpriteRenderer>();
        //old = head.sprite;
        weapon = transform.GetChild(0).gameObject;
        body = GetComponent<BoxCollider2D>();
        edges = levelEdges.GetComponent<BoxCollider2D>();
        Vector3 worldPos = edges.bounds.center;
        animator = GetComponentInChildren<Animator>();

        screenBot = worldPos.y - (edges.bounds.size.y / 2f);
        screenTop = worldPos.y + (edges.bounds.size.y / 2f);
        screenRight = worldPos.x + (edges.bounds.size.x / 2) - (body.size.x / 2f) + (body.offset.x);
        screenLeft = worldPos.x - (edges.bounds.size.x / 2) + (body.size.x / 2f) + (body.offset.x ); ;
        Debug.Log(weapon.name);
    }

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runspeed;
        verticalMove = Input.GetAxisRaw("Vertical") * runspeed;
    }

    private void LateUpdate()
    {
        if(!animator.GetCurrentAnimatorStateInfo(0).IsName("OverhandAttack"))
            animator.SetFloat("Speed", Mathf.Abs(horizontalMove) + Mathf.Abs(verticalMove));

        animator.SetBool("Attacking", attacking);
        if (Input.GetButtonDown("Fire1"))
        {
            //head.sprite = testSprite;
            StartCoroutine(attack());
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("OverhandAttack"))
        {
            attacking = false;
        }
    }

    private void FixedUpdate()
    {
        Debug.Log(attacking);
        if(!animator.GetCurrentAnimatorStateInfo(0).IsName("OverhandAttack"))
            Move(horizontalMove * Time.fixedDeltaTime, verticalMove * Time.fixedDeltaTime);
    }
    
    // Update is called once per frame
    public void Move(float horz, float vert)
    {
        //Debug.Log(horz);
        //Debug.Log(vert);


        float newX = transform.position.x + horz;
        float newY = transform.position.y + vert;

        newY = Mathf.Clamp(newY, screenBot, screenTop);
        newX = Mathf.Clamp(newX, screenLeft, screenRight);
        

        transform.position = new Vector3(newX, newY, 0);

        // If the input is moving the player right and the player is facing left...
        if (horz > 0 && !m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (horz < 0 && m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
    }

    public IEnumerator attack()
    {
         if (!attacking)
        {
            attacking = true;

            yield return new WaitForSeconds(.5f);
            /*Vector3 temp;
            attacking = true;
            for (int i = 0; i < 60; i++)
            {
                CircleCollider2D rotpoint = GetComponent<CircleCollider2D>();
                if (m_FacingRight)
                    temp = new Vector3(rotpoint.offset.x, rotpoint.offset.y, 0);
                else
                    temp = new Vector3(-rotpoint.offset.x, rotpoint.offset.y, 0);
                Vector3 point = transform.position + temp;
                if (m_FacingRight)
                    weapon.transform.RotateAround(point, Vector3.forward, -90 * Time.deltaTime);
                else
                    weapon.transform.RotateAround(point, Vector3.forward, 90 * Time.deltaTime);
                yield return new WaitForSeconds(.001f);
            }
            for (int i = 0; i < 60; i++)
            {
                CircleCollider2D rotpoint = GetComponent<CircleCollider2D>();
                if (m_FacingRight)
                    temp = new Vector3(rotpoint.offset.x, rotpoint.offset.y, 0);
                else
                    temp = new Vector3(-rotpoint.offset.x, rotpoint.offset.y, 0);
                Vector3 point = transform.position + temp;
                if (m_FacingRight)
                    weapon.transform.RotateAround(point, Vector3.forward, 90 * Time.deltaTime);
                else
                    weapon.transform.RotateAround(point, Vector3.forward, -90 * Time.deltaTime);
                yield return new WaitForSeconds(.001f);
            }*/
         }
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}

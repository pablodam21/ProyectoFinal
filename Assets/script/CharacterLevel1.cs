using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterLevel1 : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed = 0.0f;
    
    public float lateralMovement = 5.0f;
    
    public float jumpMovement = 400.0f;

	float movementButton = 0.0f;
    
    public Transform groundCheck;
    
    private Rigidbody2D rigidbody;
    
    private Animator animator;
    
    public bool grounded = true;

    private int life = 1;

    void Start()
    {
        animator = GetComponent<Animator> ();
        rigidbody = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update()
    { 
        grounded = Physics2D.Linecast (transform.position,
            groundCheck.position,
            LayerMask.GetMask("Ground"));
        
        if (grounded && Input.GetButtonDown ("Jump"))
            rigidbody.AddForce (Vector2.up * jumpMovement);
        
        if (grounded)
        {
            animator.SetTrigger("Grounded");
        }
        else
        {
            animator.SetTrigger("Jump");
        } 
        
        Speed = lateralMovement * movementButton * 3;
        
        transform.Translate (Vector2.right * Speed * Time.deltaTime);
        
        animator.SetFloat("Speed", Mathf.Abs(Speed));
        
        if (Speed < 0)
            transform.localScale = new Vector3 (28, 29, 1);
        else
            transform.localScale = new Vector3 (28, 29, 1);

    }
    void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.tag == "Door")
        {
            SceneManager.LoadScene("FinalBueno");
        }

        if (collider.tag == "EnemyBlock")
        {
            life--;
            
            if (life == 0)
            {
                SceneManager.LoadScene("FinalMalo");
            }
        }

		if (collider.tag == "EnemyFlying"){
			life--;
            if (life == 0)
            {
                SceneManager.LoadScene("FinalMalo");
            }
		}

		if (collider.tag == "EnemyWalker"){
			life--;
            if (life == 0)
            {
                SceneManager.LoadScene("FinalMalo");
            }
		}

		if (collider.tag == "MagicStone"){
			Destroy(collider.gameObject);
		}

		if (collider.tag == "EndLife"){
			 SceneManager.LoadScene("FinalMalo");
		}
        
    }

    void OnTriggerExit2D(Collider2D collider)
    {

    }
public void Jump()
    {
        if (grounded)
            rigidbody.AddForce(Vector2.up * jumpMovement);
    }
    public void Move(float amount)
    {
        movementButton = amount;
    }
}
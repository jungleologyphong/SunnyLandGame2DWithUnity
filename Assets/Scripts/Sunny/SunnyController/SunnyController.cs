using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
public class SunnyController : MonoBehaviour
{
    //Scores
    public int score;
    // Tốc độ, tốc độ cao nhất, mức độ nhảy.
    public float speed = 1f, maxspeed = 2f, jumpPow = 10f;
    // Kiểm tra ZeroX đứng dưới đất.
    public bool grounded = true, die = true, faceright = true, doubleJump = true, dieFX = true;
    //Rigibody
    public Rigidbody2D rb2;
    //Animator
    public Animator anim;
    //Health
    public int currentHealth;
    public int maxHealth = 5;
    public GameObject panelPause, panelGameOver;
    public Text txtGold;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip jumpClip,waterClip;
    // Start is called before the first frame update
    void Start(){
        rb2 = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        currentHealth = maxHealth;
    }
    // Update is called once per frame
    void Update(){
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
        if(Input.GetAxis("Horizontal") < -0.1f){
            transform.localScale = new Vector3(-4,5,0);
        }
        if(Input.GetAxis("Horizontal") > 0.1f){
            transform.localScale =  new Vector3(4,5,0);
        }
        //Nhảy 1 lần
        if(Input.GetKeyDown(KeyCode.Space)){
            if(grounded){
                grounded = false;
                doubleJump = true;
                rb2.AddForce(Vector2.up * jumpPow);
                audioSource.PlayOneShot(jumpClip);
            }else{
                // Nhảy 2 lần
                if(doubleJump){
                    doubleJump = false;
                    rb2.velocity = new Vector2(rb2.velocity.x,0);
                    rb2.AddForce(Vector2.up * jumpPow * 0.5f);
                    audioSource.PlayOneShot(jumpClip);
                }
            }
        //Sang phải và nhảy
        }else if(Input.GetKeyDown(KeyCode.RightArrow)){
            if(grounded == false){
                grounded = true;
                if(Input.GetKeyDown(KeyCode.Space)){
                    if(grounded == true){
                        grounded = false;
                    }
                }
            }
        //Sang trái và nhảy
        }else if(Input.GetKeyDown(KeyCode.LeftArrow)){
            if (grounded == false){
                grounded = true;
                if(Input.GetKeyDown(KeyCode.Space)){
                    if(grounded == true){
                        grounded = false;
                    }
                }
            }
        // Chạy và nhảy
        }else if(Input.GetKeyDown(KeyCode.RightArrow) && Input.GetKeyDown(KeyCode.Space)){
            if(grounded == true){
                grounded = false;
                rb2.AddForce(Vector2.up * jumpPow);
            }
        //Chảy và nhảy
        }else if(Input.GetKeyDown(KeyCode.LeftArrow) && Input.GetKeyDown(KeyCode.Space)){
            if(grounded == true){
                grounded = false;
                rb2.AddForce(Vector2.up * jumpPow);
            }
        }

        if(currentHealth > maxHealth){
            currentHealth = maxHealth;
        }
        if(currentHealth <= 0){
            anim.SetBool("Die", die);
            if(die){
                die = true;
                // audioSource.PlayOneShot(deathClip);
                
                StartCoroutine("OneDieSeconds");
                
            }
        }
    }

    void FixedUpdate(){
        float height = Input.GetAxis("Horizontal");
        //Di chuyển ZeroX
        rb2.AddForce((Vector2.right * speed) * height); 
        //Giới hạn tốc độ ZeroX
        if(rb2.velocity.x > maxspeed){
            rb2.velocity = new Vector2(maxspeed, rb2.velocity.y);
        }   
        if(rb2.velocity.x < -maxspeed){
            rb2.velocity = new Vector2(-maxspeed, rb2.velocity.y);
        }
        if(height > 0 && !faceright){
            Flip();
        }
        if(height < 0 && faceright){
            Flip();
        }
        if(grounded){
            rb2.velocity = new Vector2(rb2.velocity.x * 0.01f, rb2.velocity.y);
        }
    }
    public void Flip(){
        faceright = !faceright;
        Vector3 scale;
        scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    void Die(){
        panelPause.SetActive(true);
        panelGameOver.SetActive(true);
        Time.timeScale = 0;
    }
    public void Damage(int dmg){
        currentHealth -= dmg;
    }
     IEnumerator OneDieSeconds(){
         yield return new WaitForSeconds(1);
         Die();
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("NPCShopItem")){
            SceneManager.LoadScene("ShopItem");
        }  
        if(collision.CompareTag("Water")){
            audioSource.PlayOneShot(waterClip);
            currentHealth = 0;
        }
    }
}

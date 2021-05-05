using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EnemyScripts : MonoBehaviour
{
    public static EnemyScripts instance;
    private const string HIGH_SCORE = "HIGH SCORE";
    private int health = 10;
    public Transform leftLimit;
    public Transform rightLimit;
    private Transform targer;
    public float moveSpeed;
    public bool lookingLeft = true, die = true;
    private Material matWhite;
    private Material matDefault;
    private UnityEngine.Object shootingParticleSystem;    
    SpriteRenderer spriteRenderer;
    public Animator anim;
    private SunnyController sunnyController;
    public Text txtGold;
    public int parseString;
    public int totalGold;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip deadClip;
    void Awake(){
        anim = gameObject.GetComponent<Animator>();
        _MakeInstance();
    }

    void _MakeInstance(){
        if(instance == null){
            instance = this;
        }
    }
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); 
        matWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        matDefault = spriteRenderer.material;
        shootingParticleSystem = Resources.Load("ShootingParticleSystem");
        sunnyController = GameObject.FindGameObjectWithTag("Sunny").GetComponent<SunnyController>();
        SelectTarget();
    }
    void Update()
    {
        Move();
        if (!InsideofLimit() )
        {
            SelectTarget();
        }
        anim.SetBool("LookingLeft", lookingLeft);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Bullet")){
            Destroy(collision.gameObject);
            health--;
            spriteRenderer.material = matWhite;
            GameObject shootingParticle = (GameObject) Instantiate(shootingParticleSystem);
            shootingParticle.transform.position = new Vector3(transform.position.x, transform.position.y +.3f, transform.position.z);
            if(health <= 0){
                KillSelf();
            }else{
                Invoke("ResetMaterial",.1f);
            }
        }
        if(collision.CompareTag("Sunny")){
            sunnyController.Damage(1);
        }
    }

    void ResetMaterial(){
        spriteRenderer.material = matDefault;
    }

    private void KillSelf(){
        ResetMaterial();
        anim.SetBool("Die", die);
        StartCoroutine("OneDieSeconds");
        parseString = Int32.Parse(txtGold.text);
        totalGold = parseString + 100;
        txtGold.text = ""+totalGold;
        print(totalGold);
        GoldManager.instance.SetHighScore(totalGold);
        audioSource.PlayOneShot(deadClip);
    }

    private bool InsideofLimit() {
        return transform.position.x > leftLimit.position.x && transform.position.x < rightLimit.position.x;
    }
    private void SelectTarget() {
        float distenceToLeft = Vector2.Distance(transform.position,leftLimit.position);
        float distenceToright = Vector2.Distance(transform.position, rightLimit.position);
        if (distenceToLeft > distenceToright)
        {
            targer = leftLimit;
        }
        else {
            targer = rightLimit;    
        }
        Flip();
    }

    private void Flip() {
        Vector3 rotation = transform.eulerAngles;
        lookingLeft =!lookingLeft;
        Vector3 scale;
        scale = transform.localScale;
        scale.x*=1;
        transform.localScale = scale;
        if (transform.position.x > targer.position.x)
        {
            rotation.y = 0f;
        }
        else {
            rotation.y = 180f;
        }
        transform.eulerAngles = rotation;
    }   

    void Move(){
        Vector2 targetPosition = new Vector2(targer.position.x, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
    void Die(){
        
        Destroy(gameObject);
    }

    IEnumerator OneDieSeconds(){
         yield return new WaitForSeconds(2);
         Die();
    }
    public void SetHighScore(int score){
        PlayerPrefs.SetInt(HIGH_SCORE,score);
    }

    public int GetHighScore(){
        return PlayerPrefs.GetInt(HIGH_SCORE);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : MonoBehaviour
{   
    [SerializeField] 
    private Object bulletRefLeft;
    [SerializeField] 
    private Object bulletRefRight;

    [SerializeField]
    private float positionXBulletLeft = 0,positionYBulletLeft = 0;
    [SerializeField]
    private float positionXBulletRight = 0,positionYBulletRight = 0;
    public bool faceright = true;
    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip attackClip;
    void Start(){
        bulletRefLeft = Resources.Load("BulletLeft");
        bulletRefRight = Resources.Load("BulletRight");
    }
    void Update(){

        if(Input.GetKeyDown("z")){
            GameObject bulletLeft = (GameObject)Instantiate(bulletRefLeft);
            bulletLeft.transform.position = new Vector3(transform.position.x - positionXBulletLeft, transform.position.y - positionYBulletLeft, 1);
            audioSource.PlayOneShot(attackClip);
        }

        if(Input.GetKeyDown("x")){
            faceright = !faceright;
            if(faceright == true){
                Vector3 scale;
                scale = transform.localScale;
                scale.x *= -1;
                transform.localScale = scale;
            }else{
                Vector3 scale;
                scale = transform.localScale;
                scale.x *= -1;
                transform.localScale = scale;
            }
            GameObject bulletRight = (GameObject)Instantiate(bulletRefRight);
            bulletRight.transform.position = new Vector3(transform.position.x + positionXBulletRight, transform.position.y + positionYBulletRight, -1);
            audioSource.PlayOneShot(attackClip);
        }
    }
}

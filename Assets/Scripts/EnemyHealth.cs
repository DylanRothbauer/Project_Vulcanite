using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    public delegate void EnemyHealthDelegate();
    public EnemyHealthDelegate takeDamage;
    public float maxHealth = 45.0f;
    public float currentHealth;
    public float visualDamageTimer = 1;
    public Color dmgColor = new Color(0 / 255, 0 / 255, 0 / 255);
    public AudioSource src;
    public AudioClip hurtClip;
    public string SceneToLoad = "Win Screen";
    public AudioClip enemyDefeated;

    private float horizontalMovement = .001f;
    private int cycles = 5;
    private int completedCycles = 0;
    private int speed = 10;
    private float timer = 0;
    private Color normColor = new Color(255 / 255f, 255 / 255f, 255 / 255f);

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //visualizeDamageHorizontal(timer);
        visualizeDamageColor(timer, dmgColor, normColor);
        if (timer > 0) {
            timer -= Time.deltaTime*speed;
        }
        if (timer < 0) {
            timer = 0;
        }

    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        //Debug.Log(currentHealth);
        if (takeDamage != null) {
            takeDamage();
        }
        if (currentHealth <= 0.0f)
        {
            //Destroy(gameObject);
            Dead();
            //playerController.enemyDead();
            if (gameObject.CompareTag("Boss")) {
                SceneManager.LoadScene(SceneToLoad);
            }
        }
        else
        {
            completedCycles = 0;
            src.clip = hurtClip;
            src.Play();
            timer = 2;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("WeaponBullet"))
        {
            Destroy(collision.gameObject);
        }
    }


    public void visualizeDamageHorizontal(float timer) {
        float horizontalMovement = .01f;
        float floaterVar = Mathf.Sin(4*timer * Mathf.PI) * horizontalMovement;
        transform.position += new Vector3(floaterVar, 0, 0);
        if (timer <= 0 && completedCycles < cycles)
        {
            timer = 2;
            completedCycles += 1;
        }
    }

    public void visualizeDamageColor(float timer, Color colorDam, Color colorNorm) {
        if (timer >= 0.5){
            gameObject.GetComponent<SpriteRenderer>().color = colorDam;
        }
        else if (timer >= 0){
            gameObject.GetComponent<SpriteRenderer>().color = colorNorm;
        }
    }

    private void Dead()
    {
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<PolygonCollider2D>().enabled = false; // Enemies MUST have polygon colliders,
        src.clip = enemyDefeated;                              //  or will throw error
        src.Play();
        Invoke("Kill", 0.2f); // Time for audio to play, then destroy
    }

    private void Kill()
    {
        Destroy(gameObject);
    }

}

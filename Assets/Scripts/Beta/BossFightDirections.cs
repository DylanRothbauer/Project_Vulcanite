/*
 * Zachary Speckan
 * 04/01/24
 * Makes the boss perform a random attack
 * 
 * player - The player
 * queen - The queen
 * 
 * fireAndMove - The FireAndMove script
 * teleport - The Teleport script
 * random - The IceSpikesRandom script
 * wave - The IceSpikes script
 * melee - The MeleeAttack script
 * whichAttack - A number that decides which attack will be performed
 * numOfSpikes - The number of spikes that will be summoned during the IceSpikesRandom attack
 * 
 * CHANGE LOG
 * Zach - 04/08/24 - Attacks speed up when boss is at half health
 * Zach - 04/12/24 - Boss does not perform the same two attacks in a row
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightDirections : MonoBehaviour
{
    private GameObject player;
    private GameObject queen;

    FireAndMove fireAndMove;
    Teleport teleport;
    IceSpikesRandom random;
    IceSpikes wave;
    MeleeAttack melee;
    EnemyHealth health;
    int whichAttack;
    int lastAttack;
    int numOfSpikes;
    public float speedUp;

    public AudioSource src;
    public AudioClip laugh;
    public AudioClip taunt;
    private bool hasTaunted = false;
    private Animator anim;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        queen = GameObject.FindGameObjectWithTag("Boss");
        anim = GetComponent<Animator>();

        fireAndMove = GetComponent<FireAndMove>();
        teleport = GetComponent<Teleport>();
        random = GetComponent<IceSpikesRandom>();
        wave = GetComponent<IceSpikes>();
        melee = GetComponent<MeleeAttack>();
        health = GetComponent<EnemyHealth>();
        speedUp = 0.0f;
        lastAttack = 0;

        src.clip = laugh;
        src.Play();
        yield return new WaitForSeconds(1.0f);

        StartCoroutine(LetsStartTheFight());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LetsStartTheFight()
    {
        if (health.currentHealth <= health.maxHealth / 2)
        {
            if(!hasTaunted)
            {
                src.clip = taunt;
                src.Play();
                hasTaunted = true;
            }
            speedUp = 0.5f;
        }

        do
        {
            whichAttack = Random.Range(1, 5);
        } while (whichAttack == lastAttack);
        
        Debug.Log("Last attack: " + lastAttack);
        Debug.Log("This attack: " + whichAttack);

        if (whichAttack == 1)
        {
            Vector3 dir = animationDirection(queen.transform.position, player.transform.position); 
            //Teleport repeat single fire attack 
            lastAttack = whichAttack;
            StartCoroutine(fireAndMove.TeleSpam());
            yield return new WaitForSeconds(8.0f - (speedUp * 4));
            anim.SetFloat("Horizontal", dir.x);
            anim.SetFloat("Verticle", dir.y);

        }

        if (whichAttack == 2)
        {
            //Spike attack random positions
            Vector3 dir = animationDirection(queen.transform.position, player.transform.position);
            lastAttack = whichAttack;
            enemyTeleportAndAnimation();
            yield return new WaitForSeconds(2.0f);
            numOfSpikes = Random.Range(5, 8);
            StartCoroutine(random.PrepareWarnings(numOfSpikes));
            yield return new WaitForSeconds(3.0f - (speedUp * 2));
            anim.SetFloat("Horizontal", dir.x);
            anim.SetFloat("Verticle", dir.y);
            Invoke("SpikeAttack", 1f);
        }

        if (whichAttack == 3)
        {
            Vector3 dir = animationDirection(queen.transform.position, player.transform.position);
            //Falling Spikes, Lines of spikes attacks
            lastAttack = whichAttack;
            enemyTeleportAndAnimation();
            yield return new WaitForSeconds(2.0f - speedUp);
            StartCoroutine(wave.SendTheSpikes());
            yield return new WaitForSeconds(3.0f - speedUp);
            anim.SetFloat("Horizontal", dir.x);
            anim.SetFloat("Verticle", dir.y);
            Invoke("SpikeAttack", 1f);

        }

        if (whichAttack == 4)
        {
            //Melee Attack close range
            Debug.Log("Melee");
            if (Mathf.Abs(player.transform.position.x - queen.transform.position.x) < 3 && Mathf.Abs(player.transform.position.y - queen.transform.position.y) < 3)
            {
                Vector3 dir = animationDirection(queen.transform.position, player.transform.position);
                //
                anim.SetFloat("Horizontal", dir.x);
                anim.SetFloat("Verticle", dir.y);
                anim.SetTrigger("Blasting");

                //Hate everything

                lastAttack = whichAttack;
                yield return new WaitForSeconds(1.5f - speedUp);
                melee.BlastIt();
                yield return new WaitForSeconds(3.0f - speedUp);
            }
        }

        StartCoroutine(LetsStartTheFight());
    }

    //Animation position
    Vector3 animationDirection(Vector3 self, Vector3 target) {
        Vector3 targetVector = target - self;
        return targetVector.normalized;
    }

    //Enemy single teleport animation
    void enemyTeleportAndAnimation()
    {
        anim.SetTrigger("Teleporting");
        StartCoroutine(teleport.MoveIt());
        //anim.ResetTrigger("Teleporting");
    }
    void SpikeAttack()
    {
        anim.SetTrigger("Spikes");
    }
}

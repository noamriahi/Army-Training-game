using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 15;
    [SerializeField] int hitPoint = 4;

    ScoreBoard scoreBoard;

    void Start(){
        scoreBoard= FindObjectOfType<ScoreBoard>();
    }
    void OnParticleCollision(GameObject other) 
    {
        
        ProcessHit();
        if(hitPoint < 1)
        {
            KillEnemy();
        }
    }
    void ProcessHit()
    {
        GameObject vfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        hitPoint--;
        scoreBoard.IncreaseScore(scorePerHit);
    }
    void KillEnemy()
    {        
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        Destroy(gameObject);
    }
}

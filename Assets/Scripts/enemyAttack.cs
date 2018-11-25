﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyAttack : MonoBehaviour {

    public float speed;
    private Transform player;
    private Vector2 target;
    public GameObject bulletDeathRespawn;




    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position.x == target.x)
        {

            DestroyEnemyAttack();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = bulletDeathRespawn.transform.position;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            DestroyEnemyAttack();
        }
    }

    void DestroyEnemyAttack()
    {
        Destroy(gameObject);
    }
}

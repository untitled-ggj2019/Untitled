﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Dousing : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb2d;
    private BoxCollider2D boxCollide;
    private PlayerController pcl;

    public CatnipUI catnipUI;
    
    
    public bool dousing = false;

    // Start is called before the first frame update
    void Start()
    {
        
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        boxCollide = GetComponent<BoxCollider2D>();
        pcl = GetComponent<PlayerController>();
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (pcl.catNip > 0 && other.gameObject.tag == "NPC" && other.GetComponent<NPC_Doused>().isDoused == false)
        { 
            anim.SetTrigger("Player_Dousing");
            rb2d.velocity = new Vector2(0, 0);
            anim.SetFloat("Speed", 0);
            anim.SetFloat("SpeedY", 0);
            pcl.catNip -= 1;
            catnipUI.UpdateUI(pcl.catNip);
            Debug.Log("Catnip: " + pcl.catNip);
            dousing = true;
            StartCoroutine(Undouse());

            other.GetComponent<NPC_Doused>().TriggerDoused();
        }
    }

    public IEnumerator Undouse()
    {
        yield return new WaitForSeconds(0.5f);
        dousing = false;
    }
}

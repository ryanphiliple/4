using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class fightController : MonoBehaviour
{
    public GameObject hero_GO, monster_GO;
    public TextMeshPro hero_hp_TMP, monster_hp_TMP;
    private GameObject currentAttacker;
    private Animator theCurrentAnimator;
    private Monster theMonster;
    private bool shouldAttack = true;
    private Monster monster;
    
    // Start is called before the first frame update
    void Start()
    {
        this.theMonster = new Monster("Pink Ghost");
        this.hero_hp_TMP.text = "Current HP: " + MySingleton.thePlayer.getHP() + " AC: " + MySingleton.thePlayer.getAC();
        this.monster_hp_TMP.text = "Current HP: " + this.theMonster.getHP() + " AC: " + this.theMonster.getAC();

        int num = Random.Range(0, 2);
        if(num == 0)
        {
            this.currentAttacker = hero_GO;
        }
        else
        {
            this.currentAttacker = monster_GO;
        }
        StartCoroutine(fight());
        
    }

    

    private void tryAttack(Inhabitant attacker, Inhabitant defender)
    {
        int attackRoll = Random.Range(0, 20) + 1;
        if(attackRoll >= defender.getAC())
        {
            int damageRoll = Random.Range(0, 4) + 2;
            defender.takeDamage(damageRoll);

        }
        else
        {
            print("Attacker missed");
        }
    }

    IEnumerator fight()
    {
        yield return new WaitForSeconds(2);
        if(this.shouldAttack)
        {
            this.theCurrentAnimator = this.currentAttacker.GetComponent<Animator>();
            this.theCurrentAnimator.SetTrigger("attack");
            this.monster_hp_TMP.text = "CUrrent HP: " + this.theMonster.getHP() + " AC: " + this.theMonster.getAC();

            if(this.theMonster.getHP() <= 0)
            {
                print("hero wins!");
                this.shouldAttack = false;

            }
            else
            {
                StartCoroutine(fight());
            }
            
        }
        else
        {
            this.currentAttacker = this.hero_GO;
            this.tryAttack(this.theMonster, MySingleton.thePlayer);
            this.hero_hp_TMP.text = "current hp: " + MySingleton.thePlayer.getHP() + " ac: " + MySingleton.thePlayer.getAC();
            if (MySingleton.thePlayer.getHP() <= 0)
            {
                print("monster wins!");
                this.shouldAttack = false;

            }
            else
            {
                StartCoroutine(fight());
            }
        }
    }

    // Update is called once per frame
    void Update()
    {    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LookState : IEnemyState

{
    private readonly StatePatternEnemy enemy;


    public LookState(StatePatternEnemy statePatternEnemy)
    {
        enemy = statePatternEnemy;
    }

    public void UpdateState()
    {
        Look();

    }

    public void OnTriggerEnter(Collider other)
    {

    }

    public void ToPatrolState()
    {
        enemy.currentState = enemy.patrolState;

    }

    public void ToKillState()
    {
        enemy.currentState = enemy.killState;
    }

    public void ToLookState()
    {
        Debug.Log("Can't transition to same state");
    }
    private void Look()
    {
        RaycastHit hit;
        if (Physics.Raycast(enemy.eyes.transform.position, enemy.eyes.transform.forward, out hit, enemy.sightRange))
        {
            enemy.chaseTarget = hit.transform;
            Vector3 targetPostition = new Vector3(enemy.chaseTarget.position.x,
                                       this.enemy.transform.position.y,
                                      enemy.chaseTarget.position.z);
            this.enemy.transform.LookAt(targetPostition);


            ToKillState();

        }


    }


 


}
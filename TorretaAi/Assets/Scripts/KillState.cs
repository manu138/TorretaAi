using UnityEngine;
using System.Collections;
using System;

public class KillState : IEnemyState

{
    private readonly StatePatternEnemy enemy;
 

    public KillState(StatePatternEnemy statePatternEnemy)
    {
        enemy = statePatternEnemy;
    }

    public void UpdateState()
    {
        Kill();
        
     
    }

    public void OnTriggerEnter(Collider other)
    {

    }

    public void ToPatrolState()
    {
        enemy.currentState = enemy.patrolState;
        enemy.Ispatrol = true;
       
    }

    public void ToKillState()
    {
        Debug.Log("Can't transition to same state");
    }
    public void ToLookState()
    {
        enemy.currentState = enemy.lookState;
    }

    private void Look()
    {
      
     

    }
  

    private void Kill()
    {
      
                Disparar();
            
            enemy.meshRendererFlag.material.color = Color.yellow;
          
                  
     
        ToPatrolState();
    

    }
    public void Disparar()
    {
        enemy.Disparar();
        
    }


}
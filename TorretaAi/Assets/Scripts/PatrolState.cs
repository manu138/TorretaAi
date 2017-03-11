using UnityEngine;
using System.Collections;

public class PatrolState : IEnemyState

{
    private readonly StatePatternEnemy enemy;
    private int nextWayPoint;
    private float searchTimer;


    public PatrolState(StatePatternEnemy statePatternEnemy)
    {
        enemy = statePatternEnemy;
    }

    public void UpdateState()
    {
        Look();
        if(enemy.Ispatrol)
        {
            Patrol();
           
        }
     
       
    }


    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
           
        }
    
                    
    }
    private void Look()
    {
        RaycastHit hit;
        if (Physics.Raycast(enemy.eyes.transform.position, enemy.eyes.transform.right, out hit, enemy.sightRange) && hit.collider.CompareTag("Player"))
        {
            enemy.chaseTarget = hit.transform;
            // Vector3 targetPostition = new Vector3(0,this.enemy.transform.position.y,0);
           //  this.enemy.transform.LookAt(targetPostition*-1,Vector3.up);

            enemy.transform.Rotate(0, 0, 0);

            ToKillState();
         enemy.Ispatrol = false;

        }
      
       


    }
    public void ToLookState()
    {
        enemy.currentState = enemy.lookState;
    }

    public void ToPatrolState()
    {
        Debug.Log("Can't transition to same state");
    }

    public void ToKillState()
    {
        enemy.currentState = enemy.killState;
        searchTimer = 0f;
    }
    
    
    void Patrol()
    {
        enemy.meshRendererFlag.material.color = Color.green;
     
        enemy.transform.Rotate(0, enemy.searchingTurnSpeed * Time.deltaTime, 0);
        searchTimer += Time.deltaTime;

       


    }
}
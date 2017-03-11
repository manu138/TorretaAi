using UnityEngine;
using System.Collections;

public class StatePatternEnemy : MonoBehaviour
{
    public float searchingTurnSpeed = 120f;
    public float searchingDuration = 4f;
    public float sightRange = 20f;
    public Transform[] wayPoints;
    public Transform eyes;
    public Vector3 offset = new Vector3(0, .5f, 0);
    public MeshRenderer meshRendererFlag;

    public Transform player;
    [SerializeField]
    private float force=10f;
    public Transform shotSpawn;

    [SerializeField]
    private Rigidbody bullet;

    public bool Ispatrol = true;


    [HideInInspector]
    public Transform chaseTarget;
    [HideInInspector]
    public IEnemyState currentState;

    [HideInInspector]
    public KillState killState;
    [HideInInspector]
    public PatrolState patrolState;
    [HideInInspector]
    public LookState lookState;

    [HideInInspector]
    public UnityEngine.AI.NavMeshAgent navMeshAgent;

    private void Awake()
    {

        killState = new KillState(this);
        patrolState = new PatrolState(this);
        lookState = new LookState(this);

    }

    // Use this for initialization
    void Start()
    {
        currentState = patrolState;
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState();
    }

    private void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(other);
    }
    public void Disparar()
    {
        StartCoroutine(Example());
   
    }
    IEnumerator Example()
    {
             Rigidbody shot = Instantiate(bullet, shotSpawn.position, shotSpawn.rotation);

        shot.velocity = transform.right * force;
        yield return new WaitForSeconds(5);

    }
}
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class NPCMovement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private GameObject[] Waypoints;
    [SerializeField] private NPCState State;  
    [SerializeField] private Transform Player;     
    private Vector3 Destination;
    private int index;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        State = NPCState.patroll;
        Waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        if(Waypoints.Length <= 0) {return;}
        index = Random.Range(0, Waypoints.Length);
        agent.destination = Destination = Waypoints[index].transform.position;
    }

    void Update()
    {
        switch(State)
        {
            case NPCState.patroll:
                   if(Waypoints.Length <= 0) {return;}
                    float distance = Vector3.Distance(transform.position, Destination);
                    //Debug.Log("Distance to destination: " + distance);
                    if(distance < 2.0f)
                    {
                        index = Random.Range(0, Waypoints.Length);
                        agent.destination = Destination = Waypoints[index].transform.position;
                    }
            break;
            case NPCState.chase:
                agent.destination = Destination = Player.position;
            break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
         if(!other.CompareTag("Player"))
        {
            return;
        }
        State = NPCState.chase;
        Player = other.gameObject.transform;
        agent.destination = Destination;
    }

    private void OnTriggerStay(Collider other)
    {
        if(!other.CompareTag("Player"))
        {
            return;
        }
        State = NPCState.chase;
    }

    private void OnTriggerExit(Collider other)
    {
        if(!other.CompareTag("Player"))
        {
            return;
        }
        State = NPCState.patroll;
        agent.destination = Destination;
    }
}

enum NPCState
{
    patroll,
    chase
}

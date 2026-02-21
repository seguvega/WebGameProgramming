using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class NPCMovement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private GameObject[] Waypoints;
    private Vector3 Destination;
    private int index;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        if(Waypoints.Length <= 0) {return;}
        index = Random.Range(0, Waypoints.Length);
        agent.destination = Destination = Waypoints[index].transform.position;
    }

    void Update()
    {
        if(Waypoints.Length <= 0) {return;}
        float distance = Vector3.Distance(transform.position, Destination);
        //Debug.Log("Distance to destination: " + distance);
        if(distance < 2.0f)
        {
            index = Random.Range(0, Waypoints.Length);
            agent.destination = Destination = Waypoints[index].transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(!other.CompareTag("Player"))
        {
            return;
        }
        Destination = other.gameObject.transform.position;
        agent.destination = Destination;
    }

    private void OnTriggerExit(Collider other)
    {
        if(!other.CompareTag("Player"))
        {
            return;
        }
        index = Random.Range(0, Waypoints.Length);
        agent.destination = Destination = Waypoints[index].transform.position;
    }
}

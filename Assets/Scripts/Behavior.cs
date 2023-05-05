using System.Collections;
using System.Collections.Generic;
using System.Security;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Behavior : MonoBehaviour
{

    //VARIABLES


    //[SerializeField] private Transform movePositionTransform;
    //[SerializeField] private Transform Loc1, Loc2, Loc3;
    [SerializeField] private NavMeshAgent enemy;
    [SerializeField] private Transform eLoc;
    [SerializeField] private State currentstate;
    [SerializeField] private float speed;
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private int currentWaypointIndex = 0;
    [SerializeField] private bool Alone;
    [SerializeField] private GameObject ally;




    public enum State
    {
        Behavior1,//idle
        Behavior2,//run
        Behavior3 //enter
    }

    private State currentState;

    void Awake()
    {
        
        
        currentState = State.Behavior1;
        enemy = GetComponent<NavMeshAgent>();
        Alone = true;



    }

    void Update()
    {
        switch (currentState)
        {
            case State.Behavior1:
                Behavior1();
                break;
            case State.Behavior2:
                Behavior2();
                break;
            case State.Behavior3:
                Behavior3();
                break;
            default:
                Debug.LogError("Invalid state: " + currentState);
                break;
        }
    }

    void Behavior1()
    {
        if (!enemy.pathPending && enemy.remainingDistance < 0.5f)
        {
            runtobarricade();
        }
        //runtobarricade();




        currentState = State.Behavior2; // Change state when done with this behavior
    }

    void Behavior2()
    {
        // Code for Behavior 2

        currentState = State.Behavior3; // Change state when done with this behavior
    }

    void Behavior3()
    {
        // Code for Behavior 3
        currentState = State.Behavior1; // Change state when done with this behavior
    }

    private bool CheckforReinforcements()
    {


        

        GameObject newally = ally;

        OnTriggerEnter ally = ;

        
        
        
       











    }


    void runtobarricade()
    {
        if (Alone == false)
        {
            // Move towards the current waypoint
            if (waypoints.Length == 0)
                return;


            enemy.destination = waypoints[currentWaypointIndex].position;
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
        
    }

}  












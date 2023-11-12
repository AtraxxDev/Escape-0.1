using UnityEngine;

public class NPCController : MonoBehaviour
{
    public Transform[] waypoints;  
    public float moveSpeed = 3f;   
    public float rotationSpeed = 5f; 
    public float waitTime = 2f;    
    public Animator animator;
    public AudioSource grwol;
    private int currentWaypointIndex = 0;
    private float waitTimer = 0f;
    private bool isWaiting = false;  

    void Start()
    {
        currentWaypointIndex = Random.Range(0, waypoints.Length);
        MoveToWaypoint();
    }

    void Update()
    {
        if (isWaiting)
        {
            SetShoutAnimation(true);
            

            waitTimer -= Time.deltaTime;
            if (waitTimer <= 0f)
            {
                isWaiting = false;
                if (isWaiting == false)
                {
                    grwol.Stop();
                }
                SetShoutAnimation(false);
                SwitchWaypoint();  
                MoveToWaypoint();  
            }
        }

        else
        {
            MoveToWaypoint();
        }
    }

    void MoveToWaypoint()
    {
        Vector3 direction = waypoints[currentWaypointIndex].position - transform.position;

        Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, moveSpeed * Time.deltaTime);
        SetWalkAnimation(true);

        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f && !isWaiting)
        {
            SetWalkAnimation(false);
            StartWaitTimer();
        }
    }

    void StartWaitTimer()
    {
        grwol.Play();
        waitTimer = waitTime;
        isWaiting = true;
    }

    void SwitchWaypoint()
    {
        int newWaypointIndex;
        do
        {
            newWaypointIndex = Random.Range(0, waypoints.Length);
        } while (newWaypointIndex == currentWaypointIndex);



        currentWaypointIndex = newWaypointIndex;
    }



    void SetWalkAnimation(bool isWalking)
    {
        if (animator != null)
        {
            animator.SetBool("Walk", isWalking);  
        }
    }

    void SetShoutAnimation(bool isShouting)
    {
        if (animator != null)
        {
            animator.SetBool("Shout", isShouting);  
        }
    }
}

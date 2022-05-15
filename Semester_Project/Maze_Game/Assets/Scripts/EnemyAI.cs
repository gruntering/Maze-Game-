using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class EnemyAI : MonoBehaviour
{
    [Header("Pathfinding")]
    public Transform target;
    public float activateDistance = 50f;
    public float pathUpdateSeconds = 0.5f;

    [Header("Physics")]
    public float speed = 200f;
    public float nextWaypointDistance = 3f;

    [Header("Custom Behaviour")]
    public bool followEnabled = true;
    public bool directionLookEnabled = true;

    private Path path;
    private int currentWaypoing = 0;
    bool isGrounded = false;
    Seeker seeker;
    Rigidbody2D rb;

    public void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("UpdatePath", 0f, pathUpdateSeconds);
    }
    
    private void FixedUpdate()
    {
        if (TargetInDistance() && followEnabled)
        {
            PathFollow();
            
        }
    }

    
    private void UpdatePath()
    {
        if (followEnabled && TargetInDistance() && seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }
    private void PathFollow()
    {
        if (path == null)
        {
            return;
        }
        if (currentWaypoing >= path.vectorPath.Count)
        {
            return;
        }

        Vector3 startOffset = transform.position - new Vector3(0f, GetComponent<Collider2D>().bounds.extents.y);
        isGrounded = Physics2D.Raycast(startOffset,-Vector3.up,0.05f);

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoing] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;


        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoing]);
        if (distance < nextWaypointDistance)
        {
            currentWaypoing++;
        }
    }

    private bool TargetInDistance()
    {
        return Vector2.Distance(transform.position, target.transform.position) < activateDistance;
    }

    private void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoing = 0;
        }
    }
}
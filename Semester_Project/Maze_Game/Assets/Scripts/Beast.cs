using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beast : MonoBehaviour
{

    public Movement movement { get; private set; }

    //public BeastResidence residence { get; private set; }
    //public BeastChase chase { get; private set; }
    //public BeastScatter scatter { get; private set; }

    //public BeastBehaviour initialBehaviour;

    public Transform target;

    private void Awake()
    {
        this.movement = GetComponent<Movement>();
        //this.residence = GetComponent<BeastResidence>();
        //this.chase = GetComponent<BeastChase>();
        //this.scatter = GetComponent<BeastScatter>();
    }

    public void Start()
    {
        ResetState();
    }

    public void ResetState()
    {
        this.gameObject.SetActive(true);
        this.movement.ResetState();
        //this.chase.Disable();
        //this.scatter.Enable();
        //this.residence.Disable();

        //if(this.residence != this.initialBehaviour)
        //{
        //    this.residence.Disable();
        //}

        //if(this.initialBehaviour != null)
        //{
        //    this.initialBehaviour.Enable();
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Hero"))
        {
            FindObjectOfType<GameManager>().HeroDied();
        }
    }
}

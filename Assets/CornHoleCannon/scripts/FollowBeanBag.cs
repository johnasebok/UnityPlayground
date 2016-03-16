using UnityEngine;
using System.Collections;

public class FollowBeanBag : MonoBehaviour
{

    public GameObject targetToHit;
    public GameObject targetToFollow;
    public Vector3 distanceToFollowFrom;

    public Transform Cannon;
    // Use this for initialization
    void Start()
    {
        transform.transform.position = Cannon.transform.position + distanceToFollowFrom;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FixedUpdate()
    {

        transform.transform.position = targetToFollow.transform.position+distanceToFollowFrom;
        transform.LookAt(targetToHit.transform);

    }

    
}

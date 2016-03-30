using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FollowBeanBag : MonoBehaviour
{

    public GameObject targetToHit;
    public GameObject targetToFollow;
    public Vector3 distanceToFollowFrom;
    public float lerpSpeed = 1.0f;
    public Transform Cannon;
    //where to move the camera back to
    private Vector3 startPos;
    private Vector3 returnRotation;

    public float maxCameraHeight = 4.5f;
    public float minCameraHeight = 2.5f;
    // Use this for initialization
    void Start()
    {
        distanceToFollowFrom = transform.position - Cannon.transform.position;
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.resetCamera)
        {
            targetToHit = null;
            targetToFollow = null;
            transform.position = startPos;
            transform.eulerAngles = returnRotation;
            GameManager.resetCamera = false;
        }
        else if(!GameManager.isFired)
        {
            returnRotation = transform.eulerAngles;
            startPos = transform.position;
            distanceToFollowFrom = transform.position - Cannon.transform.position;
        }

    }

    public void FixedUpdate()
    {
        if (targetToHit != null && targetToFollow != null)
        {
            Vector3 newposition = targetToFollow.transform.position + distanceToFollowFrom;
            if (newposition.y > maxCameraHeight)
            {
                newposition.y = maxCameraHeight;
            }
            else if (newposition.y < minCameraHeight)
            {
                newposition.y = minCameraHeight;
            }
             transform.transform.position = Vector3.Lerp(transform.transform.position, newposition, lerpSpeed);
            transform.LookAt(targetToHit.transform);
            
        }
    }


}

using UnityEngine;
using System.Collections;

public class CannonBallScript : MonoBehaviour
{
    public bool isSleeping;

    // Use this for initialization
    void Start()
    {
        isSleeping = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        if (GetComponent<Rigidbody>().IsSleeping())
        {
            GameManager.isFired = false;
            GameManager.canFired = true;
            GameManager.resetCamera = true;       
            isSleeping = true;
            Component.Destroy(this);
        }
    }



}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class followCannon : MonoBehaviour
{
    private Vector3 baseRotation;
    public Slider sliderRotation;

    // Use this for initialization
    void Start()
    {
    
        baseRotation = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        //do this if not fired, camera stays behind cannon
        if (GameManager.isFired == false)
        {
           
            camFollowCannon();
        }
    }

    public void camFollowCannon()
    {
        Vector3 RotationAdjustedForCannon = new Vector3(baseRotation.x, baseRotation.y + sliderRotation.value, baseRotation.z);
       // transform.RotateAround(cannonLocation.position, cannonLocation.forward, baseRotation.y + sliderRotation.value);
        transform.eulerAngles = RotationAdjustedForCannon;
        
    }


}

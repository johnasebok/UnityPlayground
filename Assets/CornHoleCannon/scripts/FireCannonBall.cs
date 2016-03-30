using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FireCannonBall : MonoBehaviour
{
    public float explosiveForce;
    public GameObject cannonBall;
    public GameObject loadedCannonBall;
    public float reloadTime;
    public Slider TurnSlider;
    public Slider PowerSlider;
    public Slider HeightAngle;
    public Transform ProjectileSpawnVector;
    public FollowBeanBag FBB;
    private Vector3 SpawnVector;
    public GameObject explosion;
    // Use this for initialization
    void Start()
    {
        SpawnVector = ProjectileSpawnVector.localPosition; 
    }

    // Update is called once per frame
    void Update()
    {
        //tilt and turn cannon
        transform.localEulerAngles = new Vector3(HeightAngle.value, TurnSlider.value,0 );
    }

    public void fireCannon()
    {
        if (!GameManager.canFired)
        {
            return;
        }
        loadedCannonBall = (GameObject)Instantiate(cannonBall);
        loadedCannonBall.transform.parent = transform;
        loadedCannonBall.transform.localPosition = SpawnVector;
        loadedCannonBall.transform.localRotation = ProjectileSpawnVector.localRotation;
        Rigidbody rbCannonBall = loadedCannonBall.GetComponentInChildren<Rigidbody>();
        rbCannonBall.AddForce(ProjectileSpawnVector.forward * explosiveForce * PowerSlider.value,ForceMode.Impulse);
        rbCannonBall.AddTorque(new Vector3(0, 0, Random.Range(-45.0f, 45.0f)), ForceMode.Acceleration);
        FBB.targetToFollow = rbCannonBall.gameObject;
        FBB.targetToHit = rbCannonBall.gameObject;
        loadedCannonBall.transform.parent = null;
        GameManager.isFired = true;
        GameManager.resetCamera = false;
        explosion.SetActive(false);
        explosion.SetActive(true);
        GameObject life=GameObject.FindGameObjectWithTag("Lives");
        if (life != null)
        {
            GameObject.Destroy(life);
        }
      
    }


}

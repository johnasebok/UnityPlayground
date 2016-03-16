using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FireCannonBall : MonoBehaviour
{
    public float explosiveForce = 200.0f;
    public GameObject cannonBall;
    public GameObject loadedCannonBall;
    public Transform explosionPointer;
    public float reloadTime;

    public Slider TurnSlider;
    public Slider PowerSlider;
    public Slider HeightAngle;
    public Transform ProjectileSpawnVector;

    public FollowBeanBag FBB;
    private Vector3 SpawnVector;
    // Use this for initialization
    void Start()
    {
        SpawnVector = ProjectileSpawnVector.localPosition;
        
        loadedCannonBall = (GameObject)Instantiate(cannonBall);
        loadedCannonBall.transform.parent = transform;
        loadedCannonBall.transform.localPosition = SpawnVector;
        FBB.targetToFollow = loadedCannonBall;
        FBB.targetToHit = loadedCannonBall;
        Debug.Log(loadedCannonBall.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        //tilt and turn cannon
        transform.localEulerAngles = new Vector3(HeightAngle.value, TurnSlider.value,0 );
    }

    public void fireCannon()
    {
        Rigidbody rb = loadedCannonBall.GetComponent<Rigidbody>();
        rb.AddExplosionForce(explosiveForce * PowerSlider.value, explosionPointer.position, 20.0f, 0.0f, ForceMode.Force);
        FBB.targetToFollow = loadedCannonBall;
        FBB.targetToHit = loadedCannonBall;
        Debug.Log("fire! " + explosionPointer.position);
        GameObject life=GameObject.FindGameObjectWithTag("Lives");
        if (life != null)
        {
            GameObject.Destroy(life);
        }
        StartCoroutine(reload());
    }

    public IEnumerator reload()
    {
        yield return new WaitForSeconds(reloadTime);
        loadedCannonBall = (GameObject)Instantiate(cannonBall);
        loadedCannonBall.transform.parent = transform;
        loadedCannonBall.transform.localPosition=SpawnVector;
       

    } 
}
